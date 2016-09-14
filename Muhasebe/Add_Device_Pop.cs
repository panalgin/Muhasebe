using Muhasebe.Custom;
using Newtonsoft.Json;
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
    public partial class Add_Device_Pop : Form
    {
        public Add_Device_Pop()
        {
            InitializeComponent();
        }

        private void Add_Device_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {

                var m_DeviceTypes = m_Context.DeviceTypes.ToList();

                this.Device_Type_Combo.DataSource = m_DeviceTypes;
                this.Device_Type_Combo.DisplayMember = "Name";
                this.Device_Type_Combo.ValueMember = "ID";


                var m_ConnectionTypes = m_Context.ConnectionTypes.ToList();
                this.Connection_Type_Combo.DataSource = m_ConnectionTypes;
                this.Connection_Type_Combo.DisplayMember = "Name";
                this.Connection_Type_Combo.ValueMember = "ID";
            }

            this.Device_Type_Combo.SelectedIndexChanged += Device_Type_Combo_SelectedIndexChanged;
            this.Connection_Type_Combo.SelectedIndexChanged += Connection_Type_Combo_SelectedIndexChanged;

            this.Connection_Type_Combo.Invalidate();
        }

        private void Device_Type_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateView();
        }


        private void Connection_Type_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateView();
        }

        private void PopulateView()
        {
            ConnectionType m_Type = this.Connection_Type_Combo.SelectedItem as ConnectionType;

            switch(m_Type.Name)
            {
                case "USB":
                    {
                        this.RS232_Group.Visible = false;
                        this.NETWORK_Group.Visible = false;
                        this.USB_Group.Visible = true;

                        break;
                    }

                case "RS-232":
                    {
                        this.RS232_Group.Visible = true;
                        this.NETWORK_Group.Visible = false;
                        this.USB_Group.Visible = false;
                        break;
                    }

                case "NETWORK":
                    {
                        this.RS232_Group.Visible = false;
                        this.NETWORK_Group.Visible = true;
                        this.USB_Group.Visible = false;
                        break;
                    }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            DeviceType m_DeviceType = this.Device_Type_Combo.SelectedItem as DeviceType;
            ConnectionType m_ConnectionType = this.Connection_Type_Combo.SelectedItem as ConnectionType;

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Device m_Device = new Device();
                m_Device.TypeID = m_DeviceType.ID;
                m_Device.ConnectionTypeID = m_ConnectionType.ID;

                m_Device.OwnerID = Program.User.WorksAtID.Value;


                switch(m_ConnectionType.Name)
                {
                    case "USB":
                        {
                            UsbConnectionParameters m_Parameters = new UsbConnectionParameters();
                            m_Parameters.ProductID = this.ProductID_Box.Text;
                            m_Parameters.VendorID = this.VendorID_Box.Text;

                            m_Device.Parameters = JsonConvert.SerializeObject(m_Parameters);

                            break;
                        }

                    case "RS-232":
                        {
                            SerialConnectionParameters m_Parameters = new SerialConnectionParameters();
                            m_Parameters.Port = this.Com_Port_Combo.SelectedItem.ToString();
                            m_Parameters.BaudRate = Convert.ToInt32(this.Baud_Rate_Combo.SelectedItem.ToString());

                            m_Device.Parameters = JsonConvert.SerializeObject(m_Parameters);

                            break;
                        }

                    case "NETWORK":
                        {
                            NetworkConnectionParameters m_Parameters = new NetworkConnectionParameters();
                            m_Parameters.Alias = this.Alias_Box.Text;

                            m_Device.Parameters = JsonConvert.SerializeObject(m_Parameters);

                            break;
                        }
                }

                m_Context.Devices.Add(m_Device);
                m_Context.SaveChanges();
                
            }
        }
    }
}
