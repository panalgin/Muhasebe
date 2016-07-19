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
    public partial class Add_Reminder_Pop : Form
    {
        public delegate void OnReminderAdded(PropertyReminder Reminder);
        public event OnReminderAdded ReminderAdded;

        public Add_Reminder_Pop()
        {
            InitializeComponent();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();
            PropertyReminder m_Existing = m_Context.PropertyReminders.Where(q => q.OwnerID == Program.User.WorksAtID && q.Item.Product.Barcode == this.Product_Barcode_Box.Text).FirstOrDefault();

            if (m_Existing == null)
            {
                PropertyReminder m_Reminder = new PropertyReminder();
                var m_Product = m_Context.Products.Where(q => q.Barcode == this.Product_Barcode_Box.Text).FirstOrDefault();
                var m_Item = m_Context.Items.Where(q => q.Inventory.OwnerID == Program.User.WorksAtID && q.Product.Barcode == this.Product_Barcode_Box.Text).FirstOrDefault();

                if (m_Item != null)
                {
                    m_Reminder.ItemID = m_Item.ID;
                    m_Reminder.Maximum = this.Max_Num.Value;
                    m_Reminder.Minimum = this.Min_Num.Value;
                    m_Reminder.OwnerID = Program.User.WorksAtID;
                    m_Reminder.ResponsibleID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
                    m_Reminder.PropertyReminderMethodID = Convert.ToInt32(this.ReminderWidth_Combo.SelectedValue);

                    m_Context.PropertyReminders.Add(m_Reminder);
                    m_Context.SaveChanges();
                    InvokeReminderAdded(m_Reminder);
                    this.Close();
                }
                else
                    MessageBox.Show("Üzgünüz bu ürün envanterinizde bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bu hatırlatma listede zaten mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Add_Reminder_Pop_Load(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();

            var m_Users = m_Context.Users.Where(q => q.WorksAtID == Program.User.WorksAtID).ToList();
            this.Responsible_Combo.DataSource = m_Users;
            this.Responsible_Combo.ValueMember = "ID";
            this.Responsible_Combo.DisplayMember = "FullName";

            var m_Reminder = m_Context.PropertyRemindingMethods.ToList();

            this.ReminderWidth_Combo.DataSource = m_Reminder;
            this.ReminderWidth_Combo.ValueMember = "ID";
            this.ReminderWidth_Combo.DisplayMember = "Name";
        }

        private void InvokeReminderAdded(PropertyReminder Reminder)
        {
            if (ReminderAdded != null)
                ReminderAdded(Reminder);
        }

        private void Product_Barcode_Box_TextChanged(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();
            string m_Barcode = this.Product_Barcode_Box.Text;

            Product m_Product = m_Context.Products.Where(q => q.Barcode == m_Barcode).FirstOrDefault();
           
            if (m_Product != null)
            {
                this.Product_Barcode_Box.Text = m_Product.Barcode;
                this.Product_Name_Box.Text = m_Product.Name;

                this.Product_Barcode_Box.ReadOnly = true;
                this.Product_Name_Box.ReadOnly = true;

                Item m_Item = m_Context.Items.Where(q => q.Product.Barcode == m_Barcode).FirstOrDefault();
                int m_ID = m_Item.UnitTypeID;
                
                UnitType m_Type = m_Context.UnitTypes.Where(q => q.ID == m_ID).FirstOrDefault();

                if (m_Type != null)
                {
                    this.Min_Num.DecimalPlaces = m_Type.DecimalPlaces;
                    this.Max_Num.DecimalPlaces = m_Type.DecimalPlaces;
                }
                this.Min_UnitType_Label.Text = m_Item.UnitType.Abbreviation;
                this.Max_UnitType_Label.Text = m_Item.UnitType.Abbreviation;
            }
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
