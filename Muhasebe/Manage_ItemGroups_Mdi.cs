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
    public partial class Manage_ItemGroups_Mdi : Form
    {
        public Manage_ItemGroups_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_ItemGroups_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_ItemGroups = m_Context.ItemGroups.ToList();

                    this.listView1.BeginUpdate();
                    this.listView1.Items.Clear();

                    m_ItemGroups.ForEach(delegate (ItemGroup m_Group)
                    {
                        if (this == null)
                            return;

                        ListViewItem m_Item = new ListViewItem();
                        m_Item.Tag = m_Group.ID;
                        m_Item.Text = m_Group.Name;

                        if (m_Group.Items != null)
                            m_Item.SubItems.Add(m_Group.Items.Count.ToString());
                        else
                            m_Item.SubItems.Add("-");

                        m_Item.SubItems.Add(m_Group.ID.ToString());

                        this.listView1.Items.Add(m_Item);

                    });

                    this.listView1.EndUpdate();

                }

            });
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_ItemGroup_Mdi m_Mdi = new Add_ItemGroup_Mdi();
            m_Mdi.ShowDialog();
            this.PopulateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if(this.listView1.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Selected = this.listView1.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Selected.Tag);

                if (m_ItemID > 0)
                {
                    ItemGroup m_Group = m_Context.ItemGroups.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Group != null)
                    {
                        Edit_ItemGroup_Pop m_Pop = new Edit_ItemGroup_Pop();
                        m_Pop.ItemGroup = m_Group;
                        m_Pop.ItemGroupEdited += Pop_ItemGroupEdited;
                        m_Pop.ShowDialog(); 
                    }
                    else
                        MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pop_ItemGroupEdited(ItemGroup group)
        {
            this.PopulateListView();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Seçili ürün grubunu silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    ListViewItem m_Select = this.listView1.SelectedItems[0];
                    int m_ItemGroupID = Convert.ToInt32(m_Select.Tag);

                    if (m_Select.Tag != null && m_ItemGroupID > 0)
                    {
                        
                        ItemGroup m_Group = m_Context.ItemGroups.Where(q => q.ID == m_ItemGroupID).FirstOrDefault();

                        if (m_Group != null)
                        {
                            m_Context.ItemGroups.Remove(m_Group);
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
    }
}
