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
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Income m_Income = new Income();
                m_Income.CreatedAt = this.Revenue_Date_Picker.Value;
                m_Income.Amount = this.Revenue_Amount_Num.Value;
                m_Income.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
                m_Income.Description = this.Description_Box.Text;
                m_Income.IncomeTypeID = Convert.ToInt32(this.Revenue_Type_Combo.SelectedValue);
                m_Income.OwnerID = Program.User.WorksAtID;

                m_Context.Incomes.Add(m_Income);
                m_Context.SaveChanges();

                if (this.Account_Box.SelectedValue != null)
                {
                    int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);
                    m_Income.AccountID = m_AccountID;

                    AccountMovement m_Movement = new AccountMovement();
                    m_Movement.CreatedAt = this.Revenue_Date_Picker.Value;
                    m_Movement.AccountID = m_AccountID;
                    m_Movement.AuthorID = Program.User.ID;
                    m_Movement.ContractID = m_Income.ID;
                    m_Movement.MovementTypeID = 2; //Alacak tahsilatı
                    m_Movement.OwnerID = Program.User.WorksAtID.Value;
                    m_Movement.PaymentTypeID = 1; //Nakit
                    m_Movement.Value = m_Income.Amount.Value;

                    m_Context.AccountMovements.Add(m_Movement);
                    m_Context.SaveChanges();
                }


                InvokeRevenueAdded(m_Income);
            }

            this.Close();
        }

        private void InvokeRevenueAdded(Income income)
        {
            if (RevenueAdded != null)
                RevenueAdded(income);
        }

        private void Add_Revenue_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_RevenueTypes = m_Context.IncomeTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                this.Revenue_Type_Combo.DataSource = m_RevenueTypes;
                this.Revenue_Type_Combo.ValueMember = "ID";
                this.Revenue_Type_Combo.DisplayMember = "Name";

                var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();
                this.Responsible_Combo.DataSource = m_Users;
                this.Responsible_Combo.ValueMember = "ID";
                this.Responsible_Combo.DisplayMember = "FullName";
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}