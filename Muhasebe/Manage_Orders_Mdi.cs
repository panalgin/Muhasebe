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
    public partial class Manage_Orders_Mdi : Form
    {
        public Manage_Orders_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Orders_Mdi_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Order_Mdi m_Mdi = new Add_Order_Mdi();
            m_Mdi.ShowDialog();
            PopulateListView();
        }

        private void PopulateListView()
        {

        }
    }
}
