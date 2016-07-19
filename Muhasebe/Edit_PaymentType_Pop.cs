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
    public partial class Edit_PaymentType_Pop : Form
    {
        public delegate void OnPaymentTypeEdited(PaymentType PaymentType);
        public event OnPaymentTypeEdited PaymentTypeEdited;
        public PaymentType PaymentType { get; set; }

        public Edit_PaymentType_Pop()
        {
            InitializeComponent();
        }

        private void Edit_PaymentType_Pop_Load(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();

            this.Name_Box.Text = this.PaymentType.Name;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.PaymentType != null)
            {
                MicroEntities m_Context = new MicroEntities();
                PaymentType m_Actual = m_Context.PaymentTypes.Where(q => q.ID == this.PaymentType.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Name = this.Name_Box.Text;

                    m_Context.SaveChanges();
                    InvokePaymentTypeEdited(m_Actual);

                    this.Close();
                }
            }
        }

        private void InvokePaymentTypeEdited(PaymentType PaymentType)
        {
            if (PaymentTypeEdited != null)
                PaymentTypeEdited(PaymentType);
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Name_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Save_Button_Click(sender ,e);
            }
        }
    }
}
