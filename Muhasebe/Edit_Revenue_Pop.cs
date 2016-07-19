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

        public Income Item { get; set; }

        public Edit_Revenue_Pop()
        {
            InitializeComponent();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            if (this.Item != null)
            {
                MicroEntities m_Context = new MicroEntities();

                Income m_Actual = m_Context.Incomes.Where(q => q.ID == this.Item.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.CreatedAt = this.Revenue_Date_Picker.Value;
                    m_Actual.Amount = this.Revenue_Amount_Num.Value;
                    m_Actual.IncomeTypeID = Convert.ToInt32(this.Revenue_Type_Combo.SelectedValue);
                    m_Actual.PaymentTypeID = Convert.ToInt32(this.Payment_Type_Combo.SelectedValue);
                    m_Actual.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
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
            MicroEntities m_Context = new MicroEntities();
            var m_RevenueTypes = m_Context.IncomeTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            this.Revenue_Type_Combo.DataSource = m_RevenueTypes;
            this.Revenue_Type_Combo.ValueMember = "ID";
            this.Revenue_Type_Combo.DisplayMember = "Name";

            var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            this.Payment_Type_Combo.DataSource = m_PaymentTypes;
            this.Payment_Type_Combo.ValueMember = "ID";
            this.Payment_Type_Combo.DisplayMember = "Name";

            var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();
            this.Responsible_Combo.DataSource = m_Users;
            this.Responsible_Combo.ValueMember = "ID";
            this.Responsible_Combo.DisplayMember = "FullName";

            if (this.Item != null)
            {
                this.Revenue_Amount_Num.Value = this.Item.Amount.Value;
                this.Revenue_Date_Picker.Value = this.Item.CreatedAt.Value;
                this.Revenue_Type_Combo.SelectedValue = this.Item.IncomeTypeID;
                this.Payment_Type_Combo.SelectedValue = this.Item.PaymentTypeID;
                this.Responsible_Combo.SelectedValue = this.Item.AuthorID;
                this.Description_Box.Text = this.Item.Description;
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}