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

            var m_Payments = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            this.PaymentType_Combo.DataSource = m_Payments;
            this.PaymentType_Combo.ValueMember = "ID";
            this.PaymentType_Combo.DisplayMember = "Name";

            var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();

            this.Responsible_Combo.DataSource = m_Users;
            this.Responsible_Combo.ValueMember = "ID";
            this.Responsible_Combo.DisplayMember = "FullName";
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            Expenditure m_Expenditure = new Expenditure();

            m_Expenditure.CreatedAt = this.CreatedAt_Picker.Value;
            m_Expenditure.ExpenditureTypeID = Convert.ToInt32(this.Expenditure_Combo.SelectedValue);
            m_Expenditure.Amount = this.Cost_Num.Value;
            m_Expenditure.PaymentTypeID = Convert.ToInt32(this.PaymentType_Combo.SelectedValue);
            m_Expenditure.AuthorID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
            m_Expenditure.OwnerID = Program.User.WorksAtID;
            m_Expenditure.Description = this.ExpenditureDesc_Text.Text;

            m_Context.Expenditures.Add(m_Expenditure);
            m_Context.SaveChanges();

            InvokeExpenditureAdded(m_Expenditure);
            this.Close();
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
