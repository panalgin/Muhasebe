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
    public partial class Edit_Reminder_Pop : Form
    {
        public delegate void OnReminderEdited(PropertyReminder PropertyReminder);
        public event OnReminderEdited PropertyReminderEdited;
        public PropertyReminder PropertyReminder { get; set; }

        public Edit_Reminder_Pop()
        {
            InitializeComponent();
        }

        private void Edit_Reminder_Pop_Load(object sender, EventArgs e)
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

            this.ProductBarcode_Box.ReadOnly = true;
            this.ProductName_Box.ReadOnly = true;
            this.ProductName_Box.Text = this.PropertyReminder.Item.Product.Name;
            this.ProductBarcode_Box.Text = this.PropertyReminder.Item.Product.Barcode;
            this.Min_Num.Value = this.PropertyReminder.Minimum.Value;
            this.Max_Num.Value = this.PropertyReminder.Maximum.Value;
            this.Responsible_Combo.SelectedValue = this.PropertyReminder.ResponsibleID;
            this.ReminderWidth_Combo.SelectedValue = this.PropertyReminder.PropertyReminderMethodID;

            string m_Barcode = this.ProductBarcode_Box.Text;
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

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            if (this.PropertyReminder != null)
            {
                MicroEntities m_Context = new MicroEntities();

                PropertyReminder m_Actual = m_Context.PropertyReminders.Where(q => q.ItemID == this.PropertyReminder.Item.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.ItemID = this.PropertyReminder.Item.ID;
                    m_Actual.Minimum = this.Min_Num.Value;
                    m_Actual.Maximum = this.Max_Num.Value;
                    m_Actual.ResponsibleID = Convert.ToInt32(this.Responsible_Combo.SelectedValue);
                    m_Actual.PropertyReminderMethodID = Convert.ToInt32(this.ReminderWidth_Combo.SelectedValue);

                    m_Context.SaveChanges();
                    PropertyReminders(m_Actual);

                    this.Close();
                }
            }
        }

        private void PropertyReminders(PropertyReminder PropertyReminder)
        {
            if (PropertyReminderEdited != null)
                PropertyReminderEdited(PropertyReminder);
        }
    }
}
