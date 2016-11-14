using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muhasebe.Events;
using Muhasebe.Custom;
using AutoMapper;

namespace Muhasebe
{
    public static class DeviceManager
    {
        public static void Initialize()
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (Program.User != null)
                {
                    var m_Devices = m_Context.Devices.Where(q => q.OwnerID == Program.User.WorksAtID && q.ConnectionTypeID == 2).ToList();

                    m_Devices.All(delegate (Device m_Device)
                    {
                        Connect(m_Device.ID);

                        return true;
                    });
                }
            }
        }

        public static bool DoConnectionTest(string port, int baudrate)
        {
            SerialPort m_Connection = new SerialPort();
            m_Connection.PortName = port;
            m_Connection.BaudRate = baudrate;

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
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                try
                {
                    var m_Devices = m_Context.Devices.Where(q => q.OwnerID == Program.User.WorksAtID && q.ConnectionTypeID == 2).ToList(); // only rs-232

                    m_Devices.All(delegate (Device m_Device)
                    {
                        SerialDevice m_Serial = m_Device as SerialDevice;
                        m_Serial.Disconnect();

                        return true;
                    });
                }
                catch (Exception ex)
                {
                    Logger.Enqueue(ex);
                }
            }
        }

        public static void Disconnect(int deviceid)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            Device m_Device = m_Context.Devices.Where(q => q.ID == deviceid).FirstOrDefault();

            if (m_Device != null && m_Device.Type != null && m_Device.ConnectionTypeID == 2) // if serial device
            {
                SerialDevice m_SerialDevice = m_Device as SerialDevice;
                m_SerialDevice.Disconnect();
            }
        }

        public static void Connect(int deviceid)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Device m_Device = m_Context.Devices.Where(q => q.ID == deviceid).FirstOrDefault();

                if (m_Device != null && m_Device.Type != null && m_Device.ConnectionTypeID == 2) // if serial device
                {
                    switch (m_Device.Type.Universal)
                    {
                        case "Barcode Scanner":
                            {
                                SerialBarcodeScanner m_Scanner = null;
                                var config = new MapperConfiguration(cfg => cfg.CreateMap<Device, SerialBarcodeScanner>());
                                var mapper = config.CreateMapper();

                                m_Scanner = mapper.Map<SerialBarcodeScanner>(m_Device);
                                m_Scanner.Connect();

                                break;
                            }
                    }
                }
            }
        }

        private static void M_Serial_DataReceived(string data)
        {
            throw new NotImplementedException();
        }
    }
}
