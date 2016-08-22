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
    public partial class Manage_PaymentType_Mdi : Form
    {
        public Manage_PaymentType_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_PaymentType_Mdi_Load(object sender, EventArgs e)
        {
            PopulateList();
        }
        private void PopulateList()
        {
            this.Payment_List.Items.Clear();
            MuhasebeEntities m_Context = new MuhasebeEntities();

            var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            m_PaymentTypes.All(delegate(PaymentType m_Type)
            {
                ListViewItem m_Item = new ListViewItem();
                m_Item.Tag = m_Type.ID;
                m_Item.Text = m_Type.Name;

                this.Payment_List.Items.Add(m_Item);

                return true;
            });
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_PaymentType_Pop m_Pop = new Add_PaymentType_Pop();
            m_Pop.PaymentTypeAdded += Pop_PaymentTypeAdded;
            m_Pop.ShowDialog();
        }

        void Pop_PaymentTypeAdded(PaymentType PaymentType)
        {
            this.PopulateList();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Payment_List.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Select = this.Payment_List.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Select.Tag);

                if (m_ItemID > 0)
                {
                    PaymentType m_Item = m_Context.PaymentTypes.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Item.OwnerID != null && m_Item.OwnerID == Program.User.WorksAtID)
                    {
                        Edit_PaymentType_Pop m_Pop = new Edit_PaymentType_Pop();
                        m_Pop.PaymentType = m_Item;
                        m_Pop.PaymentTypeEdited += Pop_PaymentTypeEdited;
                        m_Pop.ShowDialog();
                    }
                    else
                        MessageBox.Show("Bu nesneyi düzenlemek için yetkiniz yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Pop_PaymentTypeEdited(PaymentType PaymentType)
        {
            this.PopulateList();
        }

        private void Payment_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Payment_List.SelectedItems.Count > 0)
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

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Payment_List.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.Payment_List.SelectedItems[0];

                if (m_Item.Tag != null)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    int m_ItemID = Convert.ToInt32(m_Item.Tag);
                    PaymentType m_Type = m_Context.PaymentTypes.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Type.OwnerID != null && m_Type.OwnerID == Program.User.WorksAtID)
                    {
                        m_Context.PaymentTypes.Remove(m_Type);
                        m_Context.SaveChanges();
                        m_Item.Remove();

                        PopulateList();
                    }
                    else
                        MessageBox.Show("Bu nesneyi silmek için yetkiniz yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Silme işlemi başarısız, bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
