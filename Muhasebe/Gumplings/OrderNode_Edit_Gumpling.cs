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
    public partial class OrderNode_Edit_Gumpling : Form
    {
        public OrderNode OrderNode { get; set; }
        public OrderNode_Edit_Gumpling()
        {
            InitializeComponent();
        }

        private void OrderNode_Edit_Gumpling_Load(object sender, EventArgs e)
        {
            if (this.OrderNode != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Item m_Item = m_Context.Items.Where(q => q.ID == this.OrderNode.ItemID).FirstOrDefault();

                    if (m_Item != null)
                    {
                        this.Unit_Label.Text = m_Item.UnitType.Name;
                        this.Amount_Num.DecimalPlaces = m_Item.UnitType.DecimalPlaces;

                        this.Amount_Num.Value = this.OrderNode.Amount;
                        this.Description_Box.Text = this.OrderNode.Description;
                    }
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.OrderNode.Amount = this.Amount_Num.Value;
            this.OrderNode.Description = this.Description_Box.Text;

            this.Close();
        }
    }
}
