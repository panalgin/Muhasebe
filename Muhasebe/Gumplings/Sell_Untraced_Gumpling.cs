using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe.Gumplings
{
    public partial class Sell_Untraced_Gumpling : Form
    {
        public Manage_Sales_Mdi SalesForm { get; set; }
        public int NextID { get; set; }

        public Sell_Untraced_Gumpling()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.SalesForm != null)
            {
                InvoiceNode m_Node = new InvoiceNode();
                m_Node.Amount = 1;
                m_Node.BasePrice = this.Price_Num.Value;
                m_Node.FinalPrice = this.Price_Num.Value;
                m_Node.Tax = 18;
                m_Node.UseCustomPricing = true;
                m_Node.ItemID = this.NextID;
                m_Node.Description = this.Description_Box.Text;

                this.SalesForm.Append(m_Node);
            }

            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
