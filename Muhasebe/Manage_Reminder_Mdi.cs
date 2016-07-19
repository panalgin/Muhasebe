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
    public partial class Manage_Reminder_Mdi : Form
    {
        public Manage_Reminder_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Reminder_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            MicroEntities m_Context = new MicroEntities();

            var m_Items = m_Context.PropertyReminders.Where(q => q.Owner.ID == Program.User.WorksAtID).ToList();

            int i = 0;
            Color m_Shaded = Color.FromArgb(240, 240, 240);


            m_Items.All(delegate(PropertyReminder m_Reminder)
            {
                string m_Minimum = "";
                string m_Maximum = "";

                m_Minimum = m_Reminder.Item.GetFormattedAmount(m_Reminder.Minimum.Value);
                m_Maximum = m_Reminder.Item.GetFormattedAmount(m_Reminder.Maximum.Value);

                ListViewItem m_ViewItem = new ListViewItem();
                m_ViewItem.Text = m_Reminder.Item.Product.Name;
                m_ViewItem.SubItems.Add(m_Reminder.Item.Product.Barcode);
                m_ViewItem.SubItems.Add(m_Minimum);
                m_ViewItem.SubItems.Add(m_Maximum);
                m_ViewItem.SubItems.Add(m_Reminder.Responsible.FullName);
                m_ViewItem.SubItems.Add(m_Reminder.Item.UnitType.Name);
                m_ViewItem.SubItems.Add(m_Reminder.PropertyRemindingMethod.Name);
                m_ViewItem.Tag = m_Reminder.ID;

                if (i++ % 2 == 1)
                {
                    m_ViewItem.BackColor = m_Shaded;
                    m_ViewItem.UseItemStyleForSubItems = true;
                }

                this.listView1.Items.Add(m_ViewItem);
                return true;
            });
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MicroEntities m_Context = new MicroEntities();
                ListViewItem m_Select = this.listView1.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Select.Tag);

                if (m_ItemID > 0)
                {
                    PropertyReminder m_Item = m_Context.PropertyReminders.Where(q => q.ID == m_ItemID).FirstOrDefault();
                    Edit_Reminder_Pop m_Pop = new Edit_Reminder_Pop();
                    m_Pop.PropertyReminder = m_Item;
                    m_Pop.PropertyReminderEdited += Pop_PropertyReminderEdited;
                    m_Pop.ShowDialog();
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Pop_PropertyReminderEdited(PropertyReminder PropertyReminder)
        {
            this.PopulateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Seçili nesne(leri) silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    MicroEntities m_Context = new MicroEntities();
                    ListViewItem m_Select = this.listView1.SelectedItems[0];
                    int m_ItemID = Convert.ToInt32(m_Select.Tag);

                    if (m_Select.Tag != null && m_ItemID > 0)
                    {
                        PropertyReminder m_Item = m_Context.PropertyReminders.Where(q => q.ID == m_ItemID).FirstOrDefault();

                        if (m_Item != null)
                        {
                            m_Context.PropertyReminders.Remove(m_Item);
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

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Reminder_Pop m_Pop = new Add_Reminder_Pop();
            m_Pop.ReminderAdded += Pop_ReminderAdded;
            m_Pop.ShowDialog();
        }

        void Pop_ReminderAdded(PropertyReminder Reminder)
        {
            this.PopulateListView();
        }
    }
}
