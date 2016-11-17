using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Add_Expenditure_Pop : Form
    {
        public delegate void OnExpenditureAdded(Expenditure expenditure);
        public event OnExpenditureAdded ExpenditureAdded;

        public Add_Expenditure_Pop()
        {
            InitializeComponent(); 
        }

        private void Add_Expenditure_Pop_Load(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            var m_ExpenditureTypes = m_Context.ExpenditureTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            this.Expenditure_Combo.DataSource = m_ExpenditureTypes;
            this.Expenditure_Combo.ValueMember = "ID";
            this.Expenditure_Combo.DisplayMember = "Name";

            var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();

            this.Responsible_Combo.DataSource = m_Users;
            this.Responsible_Combo.ValueMember = "ID";
            this.Responsible_Combo.DisplayMember = "FullName";
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities()) {
                Expenditure m_Expenditure = new Expenditure();

                m_Expenditure.CreatedAt = this.CreatedAt_Picker.Value;
                m_Expenditure.ExpenditureTypeID = Convert.ToInt32(this.Expenditure_Combo.SelectedValue);
                m_Expenditure.Amount = this.Cost_Num.Value;
                m_Expenditure.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
                m_Expenditure.OwnerID = Program.User.WorksAtID;
                m_Expenditure.Description = this.ExpenditureDesc_Text.Text;

                m_Context.Expenditures.Add(m_Expenditure);
                m_Context.SaveChanges();

                if (this.Account_Box.SelectedValue != null)
                {
                    int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);
                    Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();

                    if (m_Account != null)
                    {
                        m_Expenditure.AccountID = m_Account.ID;

                        AccountMovement m_Movement = new AccountMovement();
                        m_Movement.AccountID = m_AccountID;
                        m_Movement.AuthorID = Program.User.ID;
                        m_Movement.MovementTypeID = 4; // Borç ödemesi yapıldı.
                        m_Movement.OwnerID = Program.User.WorksAtID.Value;
                        m_Movement.PaymentTypeID = 1; //Peşin haliyle
                        m_Movement.Value = m_Expenditure.Amount.Value;
                        m_Movement.ContractID = m_Expenditure.ID;
                        m_Movement.CreatedAt = this.CreatedAt_Picker.Value;

                        m_Context.AccountMovements.Add(m_Movement);
                        m_Expenditure.MovementID = m_Movement.ID;
                    }
                }

                m_Context.SaveChanges();

                InvokeExpenditureAdded(m_Expenditure);
                this.Close();
            }
        }

        private void InvokeExpenditureAdded(Expenditure Expenditure)
        {
            if (ExpenditureAdded != null)
                ExpenditureAdded(Expenditure);
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
