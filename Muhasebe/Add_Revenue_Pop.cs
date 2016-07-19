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
    public partial class Add_Revenue_Pop : Form
    {
        public delegate void OnRevenueAdded(Income income);
        public event OnRevenueAdded RevenueAdded;

        public Add_Revenue_Pop()
        {
            InitializeComponent();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();

            Income m_Income = new Income();
            m_Income.CreatedAt = this.Revenue_Date_Picker.Value;
            m_Income.Amount = this.Revenue_Amount_Num.Value;
            m_Income.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
            m_Income.Description = this.Description_Box.Text;
            m_Income.IncomeTypeID = Convert.ToInt32(this.Revenue_Type_Combo.SelectedValue);
            m_Income.PaymentTypeID = Convert.ToInt32(this.Payment_Type_Combo.SelectedValue);
            m_Income.OwnerID = Program.User.WorksAtID;

            m_Context.Incomes.Add(m_Income);
            m_Context.SaveChanges();

            InvokeRevenueAdded(m_Income);
            this.Close();
        }

        private void InvokeRevenueAdded(Income income)
        {
            if (RevenueAdded != null)
                RevenueAdded(income);
        }

        private void Add_Revenue_Pop_Load(object sender, EventArgs e)
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
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}