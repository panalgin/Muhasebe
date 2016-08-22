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
    public partial class Add_PaymentType_Pop : Form
    {
        public delegate void OnPaymentTypeAdded(PaymentType PaymentType);
        public event OnPaymentTypeAdded PaymentTypeAdded;

        public Add_PaymentType_Pop()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            PaymentType m_PaymentType = new PaymentType();
            m_PaymentType.Name = this.Name_Box.Text;
            m_PaymentType.OwnerID = Convert.ToInt32(Program.User.WorksAtID.ToString());

            MuhasebeEntities m_Context = new MuhasebeEntities();
            m_Context.PaymentTypes.Add(m_PaymentType);
            m_Context.SaveChanges();

            InvokePaymentTypeAdded(m_PaymentType);
            this.Close();
        }

        private void InvokePaymentTypeAdded(PaymentType PaymentType)
        {
            if (PaymentTypeAdded != null)
                PaymentTypeAdded(PaymentType);
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Name_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Save_Button_Click(sender, e);
            }
        }
    }
}
