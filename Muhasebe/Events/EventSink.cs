using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Events
{
    public static class EventSink
    {
        public static event OnErrorEventHandler Error;
        public static event OnBarcodeScannedEventHandler BarcodeScanned;
        public static event OnUserLogonEventHandler UserLogon;

        public static void InvokeError(object sender, ErrorEventArgs args)
        {
            if (Error != null)
                Error(sender, args);
        }

        public static void InvokeBarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            if (BarcodeScanned != null)
            {
                if (Properties.Settings.Default.PlaySoundOnScanned)
                {
                    string m_File = Properties.Settings.Default.SoundFileLocation;

                    if (File.Exists(m_File))
                    {
                        SoundPlayer m_Player = new SoundPlayer(m_File);
                        m_Player.Play();
                    }
                }

                BarcodeScanned(sender, args);
            }
        }

        public static void InvokeUserLogon(object sender, UserLogonEventArgs args)
        {
            if (UserLogon != null)
                UserLogon(sender, args);
        }
    }
}
