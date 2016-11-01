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
    public partial class Manage_Users_Mdi : Form
    {
        public Manage_Users_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Users_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();

        }

        private void PopulateListView()
        {
            this.Users_List.Items.Clear();

            MuhasebeEntities m_Context = new MuhasebeEntities();
            var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();

            m_Users.All(delegate(User m_User)
            {
                ListViewItem m_Item = new ListViewItem();
                m_Item.Tag = m_User.ID;
                m_Item.Text = m_User.Name;
                m_Item.SubItems.Add(m_User.Surname);
                m_Item.SubItems.Add(m_User.Email);

                if (m_User.Position != null)
                    m_Item.SubItems.Add(m_User.Position.Name);
                else
                    m_Item.SubItems.Add("-");

                if (m_User.BornAt != null)
                    m_Item.SubItems.Add(m_User.BornAt.Value.ToShortDateString());
                else
                    m_Item.SubItems.Add("-");

                this.Users_List.Items.Add(m_Item);

                return true;
            });
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_User_Mdi m_Pop = new Add_User_Mdi();
            m_Pop.UserAdded += Pop_UserAdded;
            m_Pop.ShowDialog();
        }

        void Pop_UserAdded(User user)
        {
            this.PopulateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Users_List.SelectedItems.Count > 0)
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
            if (this.Users_List.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Select = this.Users_List.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Select.Tag);

                if (m_ItemID > 0)
                {
                    User m_User = m_Context.Users.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_User != null)
                    {
                        Edit_User_Pop m_Pop = new Edit_User_Pop();
                        m_Pop.User = m_User;
                        m_Pop.UserEdited += Pop_UserEdited;
                        m_Pop.ShowDialog();
                    }
                    else
                        MessageBox.Show("Düzenleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void Pop_UserEdited(User User)
        {
            this.PopulateListView();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Users_List.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Seçili Kullanıcıyı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    ListViewItem m_Select = this.Users_List.SelectedItems[0];
                    int m_ItemID = Convert.ToInt32(m_Select.Tag);

                    if (m_Select.Tag != null && m_ItemID > 0)
                    {
                        User m_User = m_Context.Users.Where(q => q.ID == m_ItemID).FirstOrDefault();

                        if (m_User != null)
                        {
                            m_Context.Users.Remove(m_User);
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
