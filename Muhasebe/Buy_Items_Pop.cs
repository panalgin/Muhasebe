using Muhasebe.Events;
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
    public partial class Buy_Items_Pop : Form
    {
        public Buy_Items_Pop()
        {
            InitializeComponent();
        }

        private void Buy_Items_Pop_Load(object sender, EventArgs e)
        {
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;

            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                this.PaymentType_Combo.DataSource = m_PaymentTypes;
                this.PaymentType_Combo.ValueMember = "ID";
                this.PaymentType_Combo.DisplayMember = "Name";

                this.PaymentType_Combo.Invalidate();
            }
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
