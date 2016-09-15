using Muhasebe.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Muhasebe.Custom;

namespace Muhasebe
{
    public partial class Manage_Devices_Mdi : Form
    {
        public Manage_Devices_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Devices_Mdi_Load(object sender, EventArgs e)
        {
            PopulateDeviceList();

            EventSink.BarcodeScanned += EventSink_BarcodeScanned;
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            string m_Barcode = args.Barcode;
            this.Output_Box.Text = string.Format("Son okutulan barkod: {0}", args.Barcode) + Environment.NewLine + this.Output_Box.Text.Replace("Son okutulan barkod:", "Barkod:");
        }

        private void PopulateDeviceList()
        {
            this.Device_List.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Devices = m_Context.Devices.Where(q => q.OwnerID == Program.User.WorksAtID);

                m_Devices.All(delegate (Device device)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = device.ID;
                    m_Item.Text = device.Type.Name;
                    m_Item.Group = this.Device_List.Groups[0] as ListViewGroup;
                    var m_RawParam = device.GetConnectionParameters();
                    string m_Details = "";

                    if (m_RawParam is UsbConnectionParameters)
                    {
                        UsbConnectionParameters m_Parameters = m_RawParam as UsbConnectionParameters;
                        m_Details = string.Format("ProductID: {0}, VendorID: {1}", m_Parameters.ProductID, m_Parameters.VendorID);
                    }
                    else if (m_RawParam is SerialConnectionParameters)
                    {
                        SerialConnectionParameters m_Parameters = m_RawParam as SerialConnectionParameters;
                        m_Details = string.Format("Port: {0}, BaudRate: {1}", m_Parameters.Port, m_Parameters.BaudRate.ToString());
                    }
                    else if (m_RawParam is NetworkConnectionParameters)
                    {
                        NetworkConnectionParameters m_Parameters = m_RawParam as NetworkConnectionParameters;
                        m_Details = string.Format("Alias: {0}", m_Parameters.Alias);
                    }



                    switch (device.Type.Universal)
                    {
                        case "Barcode Scanner":
                            {
                                m_Item.ImageIndex = 0;
                                break;
                            }
                        case "Barcode Printer":
                            {
                                m_Item.ImageIndex = 2;
                                break;
                            }
                    }

                    m_Item.SubItems.Add(m_Details);
                    this.Device_List.Items.Add(m_Item);

                    return true;
                });
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Device_List.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Item = this.Device_List.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Item.Tag);

                if (m_Item.Tag != null && m_ItemID > 0)
                {
                    Device m_Device = m_Context.Devices.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Device != null)
                    {
                        DeviceManager.Disconnect(m_Device.ID);
                        m_Context.Devices.Remove(m_Device);
                        m_Context.SaveChanges();
                        m_Item.Remove();
                        PopulateDeviceList();
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

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Device_List.SelectedItems.Count > 0)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    ListViewItem m_Item = this.Device_List.SelectedItems[0];
                    int m_ItemID = Convert.ToInt32(m_Item.Tag);

                    if (m_ItemID > 0)
                    {
                        Device m_Device = m_Context.Devices.Where(q => q.ID == m_ItemID).FirstOrDefault();

                        if (m_Device != null)
                        {
                            Edit_Device_Pop m_Pop = new Edit_Device_Pop();
                            m_Pop.Device = m_Device;
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

        void Pop_ItemEdited(Device device)
        {
            this.PopulateDeviceList();
        }

        private void Device_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Device_List.SelectedItems.Count > 0)
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

        private void Add_Device_Button_Click(object sender, EventArgs e)
        {
            Add_Device_Pop m_Pop = new Add_Device_Pop();
            m_Pop.ShowDialog();

            this.PopulateDeviceList();
        }
    }
}