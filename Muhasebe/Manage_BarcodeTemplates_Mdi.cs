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
    public partial class Manage_BarcodeTemplates_Mdi : Form
    {
        public Manage_BarcodeTemplates_Mdi()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_BarcodeTemplate_Mdi m_Mdi = new Add_BarcodeTemplate_Mdi();
            m_Mdi.ShowDialog();
            this.PopulateListView();
        }

        private void Manage_BarcodeTemplates_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {

                var m_Templates = m_Context.BarcodeTemplates.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.listView1.BeginUpdate();
                    this.listView1.Items.Clear();

                    m_Templates.ForEach(delegate (BarcodeTemplate m_Template)
                    {
                        if (this == null)
                            return;

                        ListViewItem m_Item = new ListViewItem();
                        m_Item.Tag = m_Template.ID;
                        m_Item.Text = m_Template.Name;
                        m_Item.SubItems.Add(m_Template.Path);
                        m_Item.SubItems.Add(m_Template.CreatedAt.ToString());
                        m_Item.SubItems.Add(m_Template.Width.ToString());
                        m_Item.SubItems.Add(m_Template.Height.ToString());
                        m_Item.SubItems.Add(m_Template.ID.ToString());

                        if (m_Template.IsDefault.HasValue)
                            m_Item.SubItems.Add(m_Template.IsDefault.Value == true ? "Evet" : "Hayır");
                        else
                            m_Item.SubItems.Add("-");
                            

                        this.listView1.Items.Add(m_Item);

                    });

                    this.listView1.EndUpdate();
                });
            }
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
            if (this.listView1.SelectedItems.Count > 0)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    ListViewItem m_Item = this.listView1.SelectedItems[0];
                    int m_ItemID = Convert.ToInt32(m_Item.Tag);

                    if (m_ItemID > 0)
                    {
                        BarcodeTemplate m_Template = m_Context.BarcodeTemplates.Where(q => q.ID == m_ItemID).FirstOrDefault();
                        if (m_Template != null)
                        {
                            Edit_BarcodeTemplate_Pop m_Pop = new Edit_BarcodeTemplate_Pop();
                            m_Pop.Template = m_Template;
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
        }

        private void Pop_ItemEdited(BarcodeTemplate template)
        {
            this.PopulateListView();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    ListViewItem m_Item = this.listView1.SelectedItems[0];
                    int m_ItemID = Convert.ToInt32(m_Item.Tag);

                    if (m_Item.Tag != null && m_ItemID > 0)
                    {
                        if (MessageBox.Show("Bu tasarım kalıcı olarak silinecek, emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            BarcodeTemplate m_Template = m_Context.BarcodeTemplates.Where(q => q.ID == m_ItemID).FirstOrDefault();

                            if (m_Template != null)
                            {
                                m_Context.BarcodeTemplates.Remove(m_Template);
                                m_Context.SaveChanges();
                                m_Item.Remove();
                                PopulateListView();
                            }
                            else
                            {
                                MessageBox.Show("Silme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Silme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
