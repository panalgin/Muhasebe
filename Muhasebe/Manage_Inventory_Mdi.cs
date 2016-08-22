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
    public partial class Manage_Inventory_Mdi : Form
    {
        public Manage_Inventory_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Inventory_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateList();
        }

        void PopulateList()
        {
            this.listView1.Items.Clear();

            MuhasebeEntities m_Context = new MuhasebeEntities();

            var m_Inventories = m_Context.Inventories.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

            m_Inventories.All(delegate(Inventory m_Inventory)
            {
                ListViewItem m_ListView = new ListViewItem();
                m_ListView.Tag = m_Inventory.ID;
                m_ListView.Text = m_Inventory.Name;
                m_ListView.SubItems.Add(m_Inventory.Owner.Name);
                m_ListView.SubItems.Add(m_Inventory.Address);
                m_ListView.SubItems.Add(m_Inventory.Items.Count.ToString() + " Kalem");
                m_ListView.SubItems.Add(m_Inventory.Description);

                this.listView1.Items.Add(m_ListView);
                return true;
            });
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            Add_Inventory_Pop m_Pop = new Add_Inventory_Pop();
            m_Pop.InventoryAdded += Pop_InventoryAdded;
            m_Pop.ShowDialog();
        }

        void Pop_InventoryAdded(Inventory Inventory)
        {
            this.PopulateList();
        }

        private void Edit_Btn_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Select = this.listView1.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Select.Tag);

                if (m_ItemID > 0)
                {
                    Inventory m_Inventory = m_Context.Inventories.Where(q => q.ID == m_ItemID).FirstOrDefault();
                    Edit_Inventory_Pop m_Pop = new Edit_Inventory_Pop();
                    m_Pop.Inventory = m_Inventory;
                    m_Pop.InventoryEdited += Pop_InventoryEdited;
                    m_Pop.ShowDialog();
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Pop_InventoryEdited(Inventory Inventory)
        {
            this.PopulateList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.Edit_Btn.Enabled = true;
                this.Delete_Btn.Enabled = true;
            }
            else
            {
                this.Edit_Btn.Enabled = false;
                this.Delete_Btn.Enabled = false;
            }
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];

                if (m_Item.Tag != null)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    int m_ItemID = Convert.ToInt32(m_Item.Tag);
                    Inventory m_Inventory = m_Context.Inventories.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    m_Context.Inventories.Remove(m_Inventory);
                    m_Context.SaveChanges();
                    m_Item.Remove();

                    this.PopulateList();
                }
                else
                    MessageBox.Show("Silme işlemi başarısız, bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
