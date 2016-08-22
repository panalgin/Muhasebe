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
    public partial class Manage_Items_Mdi : Form
    {
        public Manage_Items_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Items_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void PopulateListView(List<Item> list)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            if (list == null)
                list = m_Context.Items.Where(q => q.Inventory.Owner.ID == Program.User.WorksAtID).OrderByDescending(q => q.CreatedAt).Take(100).ToList();

            DoPopulateListView(list);
        }

        private void PopulateListView()
        {
            PopulateListView(null);
        }

        private void DoPopulateListView(List<Item> m_Items)
        {
            this.listView1.Items.Clear();

            int i = 0;
            Color m_Shaded = Color.FromArgb(240, 240, 240);

            int m_Distinct = 0;
            decimal m_Cost = 0.00M;
            decimal m_Final = 0.00M;

            m_Items.All(delegate(Item m_Item)
            {
                string m_Amount = m_Item.GetFormattedAmount();

                ListViewItem m_ViewItem = new ListViewItem();
                m_ViewItem.Text = m_Item.Product.Name;
                m_ViewItem.SubItems.Add(m_Item.Product.Barcode);
                m_ViewItem.SubItems.Add(m_Amount);
                m_ViewItem.SubItems.Add(m_Item.BasePrice.ToString() + " TL");
                m_ViewItem.SubItems.Add("%" + m_Item.Tax.ToString());
                m_ViewItem.SubItems.Add(m_Item.FinalPrice.ToString() + " TL");
                m_ViewItem.SubItems.Add(m_Item.Inventory.Name);
                m_ViewItem.SubItems.Add((i + 1).ToString());
                m_ViewItem.Tag = m_Item.ID;

                m_Distinct++;
                m_Cost += m_Item.BasePrice.Value * m_Item.Amount;
                m_Final += m_Item.FinalPrice.Value * m_Item.Amount;

                if (i++ % 2 == 1)
                {
                    m_ViewItem.BackColor = m_Shaded;
                    m_ViewItem.UseItemStyleForSubItems = true;
                }

                this.listView1.Items.Add(m_ViewItem);
                return true;
            });

            this.Total_Distinct_Item_Label.Text = string.Format("Toplam: {0} kalem ürün", m_Distinct);
            this.Total_Cost_Label.Text = string.Format("Toplam Maliyet: {0:0.00} TL", m_Cost);
            this.Potential_Final_Label.Text = string.Format("Potansiyel Satış Değeri: {0:0.00} TL", m_Final);
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Item_Pop m_Pop = new Add_Item_Pop();
            m_Pop.ItemAdded += Pop_ItemAdded;
            m_Pop.ShowDialog();
        }

        void Pop_ItemAdded(Item item)
        {
            this.PopulateListView();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Seçili ürün(leri) silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    ListViewItem m_Select = this.listView1.SelectedItems[0];
                    int m_ItemID = Convert.ToInt32(m_Select.Tag);

                    if (m_Select.Tag != null && m_ItemID > 0)
                    {
                        Item m_Item = m_Context.Items.Where(q => q.ID == m_ItemID).FirstOrDefault();

                        if (m_Item != null)
                        {
                            m_Context.Items.Remove(m_Item);
                            m_Context.SaveChanges();
                            PopulateListView();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Silme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.Delete_Button.Enabled = true;
                this.Edit_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.Edit_Button.Enabled = false;
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Select = this.listView1.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Select.Tag);

                if (m_ItemID > 0)
                {
                    Item m_Item = m_Context.Items.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Item != null)
                    {
                        Edit_Item_Pop m_Pop = new Edit_Item_Pop();
                        m_Pop.Item = m_Item;
                        m_Pop.ItemEdited += Pop_ItemEdited;
                        m_Pop.ShowDialog();
                    }
                    else
                        MessageBox.Show("Düzenleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Pop_ItemEdited(Item Item)
        {
            this.PopulateListView();
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            if (this.Search_Box.Text.Length > 0)
            {
                string m_Keyword = this.Search_Box.Text.Trim();

                MuhasebeEntities m_Context = new MuhasebeEntities();

                var m_Result = m_Context.Items.Where(q => q.Inventory.Owner.ID == Program.User.WorksAtID && q.Product.Name.Contains(m_Keyword) || q.Product.Barcode == m_Keyword).ToList();
                this.PopulateListView(m_Result);
            }
        }

        private void Search_Box_TextChanged(object sender, EventArgs e)
        {
            if (this.Search_Box.Text == string.Empty || this.Search_Box.Text == null)
            {
                this.PopulateListView();
            }
        }
    }
}
