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
    public partial class Edit_Inventory_Pop : Form
    {
        public delegate void OnInventoryEdited(Inventory Inventory);
        public event OnInventoryEdited InventoryEdited;
        public Inventory Inventory { get; set; }

        public Edit_Inventory_Pop()
        {
            InitializeComponent();
        }

        private void Edit_Inventory_Pop_Load(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();

            this.Storge_Name_Box.Text = this.Inventory.Name;
            this.Storge_Adress_Box.Text = this.Inventory.Address;
            this.Storge_Description_Box.Text = this.Inventory.Description;

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (Inventory != null)
            {
                MicroEntities m_Context = new MicroEntities();
                Inventory m_Actual = m_Context.Inventories.Where(q => q.ID == this.Inventory.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Name = this.Storge_Name_Box.Text;
                    m_Actual.Address = this.Storge_Adress_Box.Text;
                    m_Actual.Description = this.Storge_Description_Box.Text;

                    m_Context.SaveChanges();
                    InvokeInventoryEdited(m_Actual);

                    this.Close();
                }
            }
        }

        private void InvokeInventoryEdited(Inventory Inventory)
        {
            if (InventoryEdited != null)
                InventoryEdited(Inventory);
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
