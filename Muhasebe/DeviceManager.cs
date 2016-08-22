using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muhasebe.Events;

namespace Muhasebe
{
    public static class DeviceManager
    {
        private static SerialPort m_BarcodeReader;
        private static SerialPort m_LcdTransreceiver;

        public static void Initialize()
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            if (Program.User != null)
            {
                var m_Devices = m_Context.Devices.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

                m_Devices.All(delegate(Device m_Device)
                {
                    Connect(m_Device.ID);

                    return true;
                });
            }
        }

        private static void BarcodeReader_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] m_Buffer = new byte[32];
            m_BarcodeReader.Read(m_Buffer, 0, m_Buffer.Length);

            string m_Barcode = Encoding.UTF8.GetString(m_Buffer);
            BarcodeScannedEventArgs m_Args = new BarcodeScannedEventArgs();
            m_Args.Barcode = m_Barcode.Split('\r')[0];
            m_Args.ScannedAt = DateTime.Now;

            EventSink.InvokeBarcodeScanned(sender, m_Args);
        }

        private static void LcdTransreceiver_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }

        public static bool DoConnectionTest(string port, int baudrate)
        {
            SerialPort m_Connection = new SerialPort();
            m_Connection.PortName = port;
            m_Connection.BaudRate = baudrate;

            MuhasebeEntities m_Context = new MuhasebeEntities();

            if (m_Connection.IsOpen)
                return false;
            else
            {
                try
                {
                    m_Connection.Open();
                    m_Connection.Close();
                    m_Connection.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Enqueue(ex);
                    return false;
                }
            }
        }

        public static void DisconnectAll()
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            try
            {
                var m_Devices = m_Context.Devices.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

                m_Devices.All(delegate(Device m_Device)
                {
                    Disconnect(m_Device.ID);
                    return true;
                });
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }
        }

        public static void Disconnect(int deviceid)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            Device m_Device = m_Context.Devices.Where(q => q.ID == deviceid).FirstOrDefault();

            if (m_Device != null && m_Device.Type != null)
            {
                switch (m_Device.Type.Universal)
                {
                    case "Barcode Scanner":
                        {
                            if (m_BarcodeReader != null)
                            {
                                m_BarcodeReader.DataReceived -= BarcodeReader_DataReceived;
                                m_BarcodeReader.Dispose();
                            }

                            break;
                        }

                    case "Lcd Display":
                        {
                            if (m_LcdTransreceiver != null || m_LcdTransreceiver.IsOpen)
                            {
                                m_LcdTransreceiver.Close();
                                m_LcdTransreceiver.DataReceived -= LcdTransreceiver_DataReceived;
                            }

                            break;
                        }
                }
            }
        }

        public static void Connect(int deviceid)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            Device m_Device = m_Context.Devices.Where(q => q.ID == deviceid).FirstOrDefault();

            if (m_Device != null && m_Device.Type != null)
            {
                switch (m_Device.Type.Universal)
                {
                    case "Barcode Scanner":
                        {
                            if (m_BarcodeReader != null && m_BarcodeReader.IsOpen)
                            {
                                m_BarcodeReader.Close();
                                m_BarcodeReader.DataReceived -= BarcodeReader_DataReceived;
                            }

                            m_BarcodeReader = new SerialPort();
                            m_BarcodeReader.PortName = m_Device.Port;
                            m_BarcodeReader.BaudRate = Convert.ToInt32(m_Device.BaudRate);

                            try
                            {
                                m_BarcodeReader.Open();
                                m_BarcodeReader.DataReceived += BarcodeReader_DataReceived;
                            }
                            catch (Exception ex)
                            {
                                Logger.Enqueue(ex);
                            }

                            break;
                        }

                    case "Lcd Display":
                        {
                            if (m_LcdTransreceiver != null && m_LcdTransreceiver.IsOpen)
                            {
                                m_LcdTransreceiver.Close();
                                m_LcdTransreceiver.DataReceived -= LcdTransreceiver_DataReceived;
                            }

                            m_LcdTransreceiver = new SerialPort();
                            m_LcdTransreceiver.PortName = m_Device.Port;
                            m_LcdTransreceiver.BaudRate = Convert.ToInt32(m_Device.BaudRate);

                            try
                            {
                                m_LcdTransreceiver.Open();
                                m_LcdTransreceiver.DataReceived += LcdTransreceiver_DataReceived;
                            }
                            catch (Exception ex)
                            {
                                Logger.Enqueue(ex);
                            }

                            break;
                        }
                }
            }
        }
    }
}
