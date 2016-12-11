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
    public partial class Edit_Revenue_Pop : Form
    {
        public delegate void OnRevenueEdited(Income income);
        public event OnRevenueEdited RevenueEdited;

        public Income Income { get; set; }

        public Edit_Revenue_Pop()
        {
            InitializeComponent();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            if (this.Income != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Income m_Actual = m_Context.Incomes.Where(q => q.ID == this.Income.ID).FirstOrDefault();

                    if (m_Actual != null)
                    {
                        m_Actual.CreatedAt = this.Revenue_Date_Picker.Value;
                        m_Actual.Amount = this.Revenue_Amount_Num.Value;
                        m_Actual.IncomeTypeID = Convert.ToInt32(this.Revenue_Type_Combo.SelectedValue);
                        m_Actual.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
                        m_Actual.OwnerID = Program.User.WorksAtID;
                        m_Actual.Description = this.Description_Box.Text;

                        if (m_Actual.Account != null)
                        {
                            AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.MovementTypeID == 2 && q.ContractID == m_Actual.ID).FirstOrDefault();

                            if (m_Movement != null)
                            {
                                m_Movement.Value = m_Actual.Amount.Value;
                            }
                        }

                        m_Context.SaveChanges();
                        InvokeRevenueEdited(m_Actual);

                        this.Close();
                    }
                }
            }
        }

        private void InvokeRevenueEdited(Income income)
        {
            if (RevenueEdited != null)
                RevenueEdited(income);
        }

        private void Edit_Revenue_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_RevenueTypes = m_Context.IncomeTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                this.Revenue_Type_Combo.DataSource = m_RevenueTypes;
                this.Revenue_Type_Combo.ValueMember = "ID";
                this.Revenue_Type_Combo.DisplayMember = "Name";

                if (this.Income.AccountID != null)
                {
                    this.Account_Box.SelectedText = this.Income.Account.Name;
                }

                this.Account_Box.Enabled = false;

                var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();

                this.Responsible_Combo.DataSource = m_Users;
                this.Responsible_Combo.ValueMember = "ID";
                this.Responsible_Combo.DisplayMember = "FullName";

                if (this.Income != null)
                {
                    this.Revenue_Amount_Num.Value = this.Income.Amount.Value;
                    this.Revenue_Date_Picker.Value = this.Income.CreatedAt.Value;
                    this.Revenue_Type_Combo.SelectedValue = this.Income.IncomeTypeID;
                    this.Responsible_Combo.SelectedValue = this.Income.AuthorID;
                    this.Description_Box.Text = this.Income.Description;

                    this.Account_Box.Enabled = false;
                }
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}