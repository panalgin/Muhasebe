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
    public partial class Add_Inventory_Pop : Form
    {
        public delegate void OnInventoryAdded(Inventory Inventory);
        public event OnInventoryAdded InventoryAdded;

        public Add_Inventory_Pop()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();
            Inventory m_Inventory = new Inventory();

            m_Inventory.Name = this.Storge_Name_Box.Text;
            m_Inventory.Address = this.Storge_Adress_Box.Text;
            m_Inventory.Description = this.Storge_Description_Box.Text;
            m_Inventory.OwnerID = Program.User.WorksAt.ID;

            m_Context.Inventories.Add(m_Inventory);
            m_Context.SaveChanges();

            InvokeInventoryAdded(m_Inventory);
            this.Close();
        }

        private void InvokeInventoryAdded(Inventory Inventory)
        {
            if (InventoryAdded != null)
                InventoryAdded(Inventory);
        }
    }
}
