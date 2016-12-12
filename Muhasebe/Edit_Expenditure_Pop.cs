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
    public partial class Edit_Expenditure_Pop : Form
    {
        public delegate void OnExpenditureEdited(Expenditure Expenditure);
        public event OnExpenditureEdited ExpenditureEdited;
        public Expenditure Expenditure { get; set; }

        public Edit_Expenditure_Pop()
        {
            InitializeComponent();
        }

        private void Edit_Expenditure_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.Expenditure = m_Context.Expenditures.Where(q => q.ID == this.Expenditure.ID).FirstOrDefault();

                var m_ExpenditureType = m_Context.ExpenditureTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                this.CreatedAt_Picker.Value = this.Expenditure.CreatedAt.Value;

                this.Expenditure_Type_Combo.DataSource = m_ExpenditureType;
                this.Expenditure_Type_Combo.ValueMember = "ID";
                this.Expenditure_Type_Combo.DisplayMember = "Name";

                var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();

                this.Responsible_Combo.DataSource = m_Users;
                this.Responsible_Combo.ValueMember = "ID";
                this.Responsible_Combo.DisplayMember = "FullName";

                this.CreatedAt_Picker.Value = this.Expenditure.CreatedAt.Value;
                this.Expenditure_Type_Combo.SelectedValue = this.Expenditure.ExpenditureTypeID;
                this.Expenditure_Amount_Num.Value = this.Expenditure.Amount.Value;
                this.Responsible_Combo.SelectedValue = this.Expenditure.AuthorID;
                this.ExpenditureDesc_Text.Text = this.Expenditure.Description;

                this.Account_Box.Enabled = false;

                if (this.Expenditure.Account != null)
                {
                    this.Account_Box.SelectedText = this.Expenditure.Account.Name;
                }
            }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            if (this.Expenditure != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Expenditure m_Actual = m_Context.Expenditures.Where(q => q.ID == this.Expenditure.ID).FirstOrDefault();

                    if (m_Actual != null)
                    {
                        m_Actual.CreatedAt = this.CreatedAt_Picker.Value;
                        m_Actual.Amount = this.Expenditure_Amount_Num.Value;
                        m_Actual.ExpenditureTypeID = Convert.ToInt32(this.Expenditure_Type_Combo.SelectedValue);
                        m_Actual.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
                        m_Actual.OwnerID = Program.User.WorksAtID;
                        m_Actual.Description = this.ExpenditureDesc_Text.Text;

                        if (m_Actual.Account != null)
                        {
                            AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.MovementTypeID == 4 && q.ContractID == m_Actual.ID).FirstOrDefault();

                            if (m_Movement != null)
                            {
                                m_Movement.Value = m_Actual.Amount.Value;
                            }
                        }

                        m_Context.SaveChanges();
                        InvokeExpenditureEdited(m_Actual);

                        this.Close();
                    }
                }
            }
        }

        private void InvokeExpenditureEdited(Expenditure Expenditure)
        {
            if (ExpenditureEdited != null)
            {
                ExpenditureEdited(Expenditure);
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
