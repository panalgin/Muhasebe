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
    public partial class Add_Sales_Mdi : Form
    {
        public delegate void OnInvoiceNodeCreated(InvoiceNode node);
        public event OnInvoiceNodeCreated InvoiceNodeCreated;

        private Item Item { get; set; }

        public Add_Sales_Mdi()
        {
            InitializeComponent();
        }

        private void Add_Sales_Mdi_Load(object sender, EventArgs e)
        {
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            if (args.Barcode != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Item m_Item = m_Context.Items.Where(q => q.Product.Barcode == args.Barcode).FirstOrDefault();

                    if (m_Item != null)
                        this.Barcode_Box.Text = args.Barcode;
                }
            }
        }

        private void Sale_Button_Click(object sender, EventArgs e)
        {
            if (this.Item != null)
            {
                InvoiceNode m_Node = new InvoiceNode(this.Item);
                m_Node.Amount = this.Amount_Num.Value;
                m_Node.BasePrice = this.PerPrice_Num.Value;
                m_Node.FinalPrice = this.TotalPrice_Num.Value;

                if (this.UseCustumPricing_Check.Checked)
                    m_Node.UseCustomPrice = true;

                InvoiceNodeCreated?.Invoke(m_Node);
            }

            this.Close();
        }

        private void UseCustumPricing_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (this.UseCustumPricing_Check.Checked)
                this.PerPrice_Num.ReadOnly = false;
            else
            {
                this.PerPrice_Num.ReadOnly = true;

                if (this.Item != null)
                    this.PerPrice_Num.Value = this.Item.FinalPrice.Value;
            }
        }

        private void PerPrice_Num_ValueChanged(object sender, EventArgs e)
        {
            if (this.Item != null)
            {
                this.TotalPrice_Num.Value = this.PerPrice_Num.Value * this.Amount_Num.Value;
            }
        }

        private void Amount_Num_ValueChanged(object sender, EventArgs e)
        {
            if (this.Item != null)
            {
                this.TotalPrice_Num.Value = this.PerPrice_Num.Value * this.Amount_Num.Value;
            }
        }

        private void Barcode_Box_TextChanged(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                string m_Barcode = this.Barcode_Box.Text;
                Product m_Product = m_Context.Products.Where(q => q.Barcode == m_Barcode).FirstOrDefault();

                if (m_Product != null)
                {
                    this.Item = m_Context.Items.Where(q => q.ProductID == m_Product.ID && q.Inventory.OwnerID == Program.User.WorksAtID).FirstOrDefault();
                    this.Barcode_Box.Text = m_Product.Barcode;
                    this.Name_Box.Text = m_Product.Name;
                    this.Abbreviation_Label.Text = this.Item.UnitType.Name;
                    this.Amount_Num.Value = 1;
                    this.PerPrice_Num.Value = Item.FinalPrice.Value;


                    this.Barcode_Box.ReadOnly = true;
                    this.Name_Box.ReadOnly = true;
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
