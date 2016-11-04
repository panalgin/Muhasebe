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
                MuhasebeEntities m_Context = new MuhasebeEntities();

                Income m_Actual = m_Context.Incomes.Where(q => q.ID == this.Income.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.CreatedAt = this.Revenue_Date_Picker.Value;
                    m_Actual.Amount = this.Revenue_Amount_Num.Value;
                    m_Actual.IncomeTypeID = Convert.ToInt32(this.Revenue_Type_Combo.SelectedValue);
                    m_Actual.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);

                    if (this.Account_Box.SelectedValue != null)
                    {
                        int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);
                        m_Actual.AccountID = m_AccountID;
                    }

                    m_Actual.OwnerID = Program.User.WorksAtID;
                    m_Actual.Description = this.Description_Box.Text;

                    m_Context.SaveChanges();
                    InvokeRevenueEdited(m_Actual);

                    this.Close();
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
            MuhasebeEntities m_Context = new MuhasebeEntities();
            var m_RevenueTypes = m_Context.IncomeTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            this.Revenue_Type_Combo.DataSource = m_RevenueTypes;
            this.Revenue_Type_Combo.ValueMember = "ID";
            this.Revenue_Type_Combo.DisplayMember = "Name";

            this.Account_Box.SelectedValue = this.Income.AccountID;

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
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}