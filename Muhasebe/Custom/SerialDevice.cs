using System;
using System.IO.Ports;
using System.Text;

namespace Muhasebe.Custom
{
    public class SerialDevice : Device
    {
        public delegate void OnDataReceived(string data);
        public event OnDataReceived DataReceived;

        private SerialPort m_Connection { get; set; }
        public bool IsConnected
        {
            get
            {
                if (m_Connection != null)
                    return m_Connection.IsOpen;
                else
                    return false;
            }
        }

        public SerialDevice()
        {
            GC.KeepAlive(this);
        }

        public void Connect()
        {
            if (m_Connection == null)
            {
                SerialConnectionParameters m_Parameters = this.GetConnectionParameters() as SerialConnectionParameters;
                m_Connection = new SerialPort(m_Parameters.Port, m_Parameters.BaudRate);
            }

            try
            {
                m_Connection.Open();
                m_Connection.DataReceived += Connection_DataReceived;
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }
        }

        public void Disconnect()
        {
            if (m_Connection != null)
            {
                m_Connection.DataReceived -= Connection_DataReceived;
                m_Connection.Dispose();
            }

        }

        private void Connection_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] m_Buffer = new byte[32];
            m_Connection.Read(m_Buffer, 0, m_Buffer.Length);
            string m_Data = Encoding.UTF8.GetString(m_Buffer);
            DataReceived?.Invoke(m_Data);
        }
    }
}