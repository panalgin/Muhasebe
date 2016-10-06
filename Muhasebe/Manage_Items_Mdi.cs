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
            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Groups = m_Context.ItemGroups.OrderBy(q => q.Name).ToList();

                m_Groups.ForEach(delegate (ItemGroup group)
                {
                    RadioButton m_Button = new RadioButton();
                    m_Button.Text = group.Name;
                    m_Button.AutoSize = true;
                    m_Button.UseVisualStyleBackColor = true;
                    m_Button.Tag = group.ID;
                    m_Button.CheckedChanged += All_Radio_CheckedChanged;

                    this.flowLayoutPanel1.Controls.Add(m_Button);
                });
            }

            this.PopulateListView();
        }

        private class Faker
        {
            public int ID { get; set; }
            public string Barcode { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public string GroupName { get; set; }
            public string InventoryName { get; set; }
            public decimal? BasePrice { get; set; }
            public decimal? FinalPrice { get; set; }
            public int? Tax { get; set; }
            public int DecimalPlaces { get; set; }
            public string Abbreviation { get; set; }
        }

        private void PopulateListView(List<Item> list = null)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            if (list == null)
            {
                var result = from item in m_Context.Items
                             join product in (from pr in m_Context.Products select new { pr.ID, pr.Name, pr.Barcode }) on item.ProductID equals product.ID
                             join inventory in (from iv in m_Context.Inventories where iv.OwnerID == Program.User.WorksAtID select new { iv.ID, iv.Name }) on item.InventoryID equals inventory.ID
                             join unittype in (from ut in m_Context.UnitTypes where ut.OwnerID == null || ut.OwnerID == Program.User.WorksAtID select new { ut.ID, ut.DecimalPlaces, ut.Abbreviation }) on item.UnitTypeID equals unittype.ID
                             join _group in (from gp in m_Context.ItemGroups select new { gp.ID, gp.Name}) on item.GroupID equals _group.ID orderby item.CreatedAt descending
                             select new Faker
                             {
                                 ID = item.ID,
                                 Barcode = product.Barcode,
                                 Name = product.Name,
                                 Amount = item.Amount,
                                 GroupName = _group.Name,
                                 InventoryName = inventory.Name,
                                 BasePrice = item.BasePrice,
                                 FinalPrice = item.FinalPrice,
                                 Tax = item.Tax,
                                 DecimalPlaces = unittype.DecimalPlaces,
                                 Abbreviation = unittype.Abbreviation
                             };

                DoPopulateListViewFast(result.ToList());
            }
            else
            {
                DoPopulateListView(list);
            }
        }

        private string GetFormattedAmount(decimal amount, int decimalPlaces, string abbreviation)
        {
            string m_Amount = "";

            try
            {
                if (decimalPlaces == 0)
                {
                    if (amount == 0.0000M)
                        m_Amount = string.Format("0 {0}", abbreviation);
                    else
                        m_Amount = string.Format("{0} {1}", amount.ToString("#"), abbreviation);
                }

                else
                {
                    string m_Format = "#." + "".PadRight(decimalPlaces, '#');
                    m_Amount = amount.ToString(m_Format) + " " + abbreviation;
                }
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }

            return m_Amount;
        }

        private void DoPopulateListViewFast(List<Faker> m_Items)
        {
            this.listView1.Items.Clear();

            int i = 0;
            Color m_Shaded = Color.FromArgb(240, 240, 240);

            int m_Distinct = 0;
            decimal m_Cost = 0.00M;
            decimal m_Final = 0.00M;

            m_Items.All(delegate (Faker m_Field)
            {
                string m_Amount = GetFormattedAmount(m_Field.Amount, m_Field.DecimalPlaces, m_Field.Abbreviation);

                ListViewItem m_ViewItem = new ListViewItem();
                m_ViewItem.Text = m_Field.Name;
                m_ViewItem.SubItems.Add(m_Field.Barcode);
                m_ViewItem.SubItems.Add(m_Amount);
                m_ViewItem.SubItems.Add(m_Field.BasePrice.ToString() + " TL");
                m_ViewItem.SubItems.Add("%" + m_Field.Tax.ToString());
                m_ViewItem.SubItems.Add(m_Field.FinalPrice.ToString() + " TL");
                m_ViewItem.SubItems.Add(m_Field.InventoryName);

                if (m_Field.GroupName != null)
                    m_ViewItem.SubItems.Add(m_Field.GroupName);
                else
                    m_ViewItem.SubItems.Add("-");

                m_ViewItem.SubItems.Add((i + 1).ToString());
                m_ViewItem.Tag = m_Field.ID;

                m_Distinct++;
                m_Cost += m_Field.BasePrice.Value * m_Field.Amount;
                m_Final += m_Field.FinalPrice.Value * m_Field.Amount;

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

                if (m_Item.Group != null)
                    m_ViewItem.SubItems.Add(m_Item.Group.Name);
                else
                    m_ViewItem.SubItems.Add("-");

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

        private void All_Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton m_Button = sender as RadioButton; ;

            if (m_Button.Checked)
            {
                int m_ID = Convert.ToInt32(m_Button.Tag);

                if (m_ID > 0)
                {
                    using(MuhasebeEntities m_Context = new MuhasebeEntities())
                    {
                        var m_Result = m_Context.Items.Where(q => q.Inventory.OwnerID == Program.User.WorksAtID && q.GroupID == m_ID).OrderBy(q => q.Product.Name).ToList();
                        this.PopulateListView(m_Result);
                    }
                }
                else
                {
                    using (MuhasebeEntities m_Context = new MuhasebeEntities())
                    {
                        this.PopulateListView();
                    }
                }
            }
        }
    }
}
