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
    public partial class Item_Set_Amount_Gumpling : Form
    {
        public delegate void OnItemAmountChanged(InvoiceNode node);
        public event OnItemAmountChanged ItemAmountChanged;

        public InvoiceNode Node { get; set; }
        public Item_Set_Amount_Gumpling()
        {
            InitializeComponent();
        }

        private void Item_Set_Amouınt_Gumpling_Load(object sender, EventArgs e)
        {
            if (Node == null)
                this.Close();

            this.Amount_Num.Value = this.Node.Amount.Value;
            this.Amount_Num.Focus();
            this.Amount_Num.Select(0, this.Amount_Num.Value.ToString().Length);
        }

        private void InvokeItemAmountChanged()
        {
            if (ItemAmountChanged != null)
                ItemAmountChanged(this.Node);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.Node.Amount = this.Amount_Num.Value;
            InvokeItemAmountChanged();
            this.Close();
        }
    }
}
