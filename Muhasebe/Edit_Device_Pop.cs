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
    public partial class Edit_Device_Pop : Form
    {
        public delegate void OnItemEdited(Device device);
        public event OnItemEdited ItemEdited;

        public Device Device { get; set; }

        public Edit_Device_Pop()
        {
            InitializeComponent();
        }

        private void Edit_Device_Pop_Load(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            var m_DeviceTypes = m_Context.DeviceTypes.ToList();

            this.Device_Type_Combo.DataSource = m_DeviceTypes;
            this.Device_Type_Combo.DisplayMember = "Name";
            this.Device_Type_Combo.ValueMember = "ID";
            this.Device_Type_Combo.Invalidate();

            this.Device_Type_Combo.SelectedValue = this.Device.Type.ID;


            var m_ConnectionTypes = m_Context.ConnectionTypes.ToList();
            this.Connection_Type_Combo.DataSource = m_ConnectionTypes;
            this.Connection_Type_Combo.DisplayMember = "Name";
            this.Connection_Type_Combo.ValueMember = "ID";

            this.Connection_Type_Combo.SelectedValue = this.Device.ConnectionType.ID;

           /* if (!this.Com_Port_Combo.Items.Contains(this.Device.Port))
                this.Com_Port_Combo.Items.Add(this.Device.Port);

            if (this.Device.BaudRate.HasValue && !this.Baud_Rate_Combo.Items.Contains(this.Device.BaudRate.ToString()))
                this.Baud_Rate_Combo.Items.Add(this.Device.BaudRate.ToString());

            this.Com_Port_Combo.SelectedItem = this.Device.Port;

            if (this.Device.BaudRate.HasValue)
                this.Baud_Rate_Combo.SelectedItem = this.Device.BaudRate.ToString();*/
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Device != null)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                Device m_Actual = m_Context.Devices.Where(q => q.ID == this.Device.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    DeviceManager.Disconnect(this.Device.ID);

                    m_Actual.TypeID = Convert.ToInt32(this.Device_Type_Combo.SelectedValue);
                    /*m_Actual.Port = this.Com_Port_Combo.SelectedItem.ToString();
                    m_Actual.BaudRate = Convert.ToInt32(this.Baud_Rate_Combo.SelectedItem.ToString());

                    if (DeviceManager.DoConnectionTest(m_Actual.Port, m_Actual.BaudRate.Value))
                    {
                        m_Context.SaveChanges();
                        DeviceManager.Connect(m_Actual.ID);
                        InvokeItemEdited(m_Actual);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Belirttiğiniz kriterlere uygun bağlı bir cihaz bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvokeItemEdited(Device device)
        {
            if (ItemEdited != null)
                ItemEdited(device);
        }
    }
}
