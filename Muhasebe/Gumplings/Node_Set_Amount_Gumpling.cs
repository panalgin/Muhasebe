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
    public partial class Node_Set_Amount_Gumpling : Form
    {
        public delegate void OnNodeAmountChanged(dynamic node);
        public event OnNodeAmountChanged NodeAmountChanged;

        public dynamic Node { get; set; }
        public Node_Set_Amount_Gumpling()
        {
            InitializeComponent();
        }

        private void Node_Set_Amount_Gumpling_Load(object sender, EventArgs e)
        {
            if (this.Node == null)
                this.Close();

            if (this.Node is InvoiceNode)
            {
                InvoiceNode m_Temp = this.Node as InvoiceNode;

                if (m_Temp.Item != null)
                    this.Name_Label.Text = m_Temp.Item.Product.Name;
                else
                    this.Name_Label.Text = m_Temp.Description;

                this.Amount_Num.Value = m_Temp.Amount.Value;
                this.UnitPrice_Num.Value = m_Temp.BasePrice.Value;
            }
            else if (this.Node is StockMovementNode)
            {
                StockMovementNode m_Temp = this.Node as StockMovementNode;
                this.Name_Label.Text = m_Temp.Item.Product.Name;
                this.Amount_Num.Value = m_Temp.Amount;
                this.UnitPrice_Num.Value = m_Temp.BasePrice.Value;
            }

            if (this.Node.Item != null)
            {
                this.Amount_Num.DecimalPlaces = this.Node.Item.UnitType.DecimalPlaces;

                if (this.Amount_Num.DecimalPlaces == 0)
                    this.Amount_Num.Minimum = 1m;
                else if (this.Amount_Num.DecimalPlaces == 2)
                    this.Amount_Num.Minimum = 0.01m;
                else if (this.Amount_Num.DecimalPlaces == 4)
                    this.Amount_Num.Minimum = 0.0001m;

                this.UnitPrice_Num.Minimum = 0.01m;
            }

            this.Amount_Num.Focus();
            this.Amount_Num.Select(0, this.Amount_Num.Value.ToString().Length);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.Node.Amount = this.Amount_Num.Value;

            if (this.UnitPrice_Num.Value != this.Node.BasePrice)
            {
                this.Node.BasePrice = this.UnitPrice_Num.Value;

                if (this.Node is InvoiceNode)
                {
                    this.Node.FinalPrice = this.Node.BasePrice * this.Node.Amount;
                    this.Node.UseCustomPrice = true;
                }
            }

            NodeAmountChanged?.Invoke(this.Node);

            this.Close();
        }
    }
}
