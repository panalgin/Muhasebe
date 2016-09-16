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

            this.PopulateView(true); // show initial values

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

        private void PopulateView(bool showInitialValues = false)
        {
            ConnectionType m_Type = this.Connection_Type_Combo.SelectedItem as ConnectionType;

            switch (m_Type.Name)
            {
                case "USB":
                    {
                        this.RS232_Group.Visible = false;
                        this.NETWORK_Group.Visible = false;
                        this.USB_Group.Visible = true;

                        if (showInitialValues)
                        {
                            UsbConnectionParameters m_Parameters = this.Device.GetConnectionParameters() as UsbConnectionParameters;
                            this.VendorID_Box.Text = m_Parameters.VendorID;
                            this.ProductID_Box.Text = m_Parameters.ProductID;
                        }

                        break;
                    }

                case "RS-232":
                    {
                        this.RS232_Group.Visible = true;
                        this.NETWORK_Group.Visible = false;
                        this.USB_Group.Visible = false;

                        if (showInitialValues)
                        {
                            SerialConnectionParameters m_Parameters = this.Device.GetConnectionParameters() as SerialConnectionParameters;

                            this.Com_Port_Combo.SelectedItem = m_Parameters.Port;
                            this.Baud_Rate_Combo.SelectedItem = m_Parameters.BaudRate.ToString();
                        }


                        break;
                    }

                case "NETWORK":
                    {
                        this.RS232_Group.Visible = false;
                        this.NETWORK_Group.Visible = true;
                        this.USB_Group.Visible = false;

                        if (showInitialValues)
                        {
                            NetworkConnectionParameters m_Parameters = this.Device.GetConnectionParameters() as NetworkConnectionParameters;
                            this.Alias_Box.Text = m_Parameters.Alias;
                        }

                        break;
                    }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Device != null)
            {
                DeviceType m_DeviceType = this.Device_Type_Combo.SelectedItem as DeviceType;
                ConnectionType m_ConnectionType = this.Connection_Type_Combo.SelectedItem as ConnectionType;

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Device m_Actual = m_Context.Devices.Where(q => q.ID == this.Device.ID).FirstOrDefault();
                    m_Actual.TypeID = m_DeviceType.ID;
                    m_Actual.ConnectionTypeID = m_ConnectionType.ID;

                    m_Actual.OwnerID = Program.User.WorksAtID.Value;

                    switch (m_ConnectionType.Name)
                    {
                        case "USB":
                            {
                                UsbConnectionParameters m_Parameters = new UsbConnectionParameters();

                                if (this.ProductID_Box.Text == string.Empty || this.VendorID_Box.Text == string.Empty)
                                {
                                    MessageBox.Show("Üretici ve ürün kimliği doğru girilmeli.", "Hata", MessageBoxButtons.OK);
                                    return;
                                }


                                m_Parameters.ProductID = this.ProductID_Box.Text;
                                m_Parameters.VendorID = this.VendorID_Box.Text;

                                m_Actual.Parameters = JsonConvert.SerializeObject(m_Parameters);

                                break;
                            }

                        case "RS-232":
                            {
                                SerialConnectionParameters m_Parameters = new SerialConnectionParameters();
                                m_Parameters.Port = this.Com_Port_Combo.SelectedItem.ToString();
                                m_Parameters.BaudRate = Convert.ToInt32(this.Baud_Rate_Combo.SelectedItem.ToString());

                                m_Actual.Parameters = JsonConvert.SerializeObject(m_Parameters);

                                break;
                            }

                        case "NETWORK":
                            {
                                NetworkConnectionParameters m_Parameters = new NetworkConnectionParameters();

                                if (this.Alias_Box.Text == string.Empty)
                                {
                                    MessageBox.Show("Ürünün ağdaki adı girilmeli.", "Hata", MessageBoxButtons.OK);
                                    return;
                                }

                                m_Parameters.Alias = this.Alias_Box.Text;
                                m_Actual.Parameters = JsonConvert.SerializeObject(m_Parameters);

                                break;
                            }
                    }

                    m_Context.SaveChanges();
                    InvokeItemEdited(m_Actual);

                    this.Close();

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
