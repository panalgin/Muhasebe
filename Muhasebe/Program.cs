using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public static class Program
    {
        public static User User { get; set; }
        public static string BasePath { get; set; }
        public static bool AutoLoginEnabled { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] param)
        {
            using (Mutex mutex = new Mutex(false, "Muhasebe"))
            {
                if (!mutex.WaitOne(0, true))
                {
                    if (Application.OpenForms.Count > 0)
                        Application.OpenForms[0].BringToFront();

                    MessageBox.Show("Program şuan zaten çalışmakta.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BasePath = Application.StartupPath;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (param.Length > 0)
                    {
                        if (param[0] == "/auto")
                        {
                            AutoLoginEnabled = true;
                        }
                    }

                    Application.EnterThreadModal += Application_EnterThreadModal;
                    Application.LeaveThreadModal += Application_LeaveThreadModal;

                    Application.Run(new MainForm());
                }
            }
        }

        private static void Application_LeaveThreadModal(object sender, EventArgs e)
        {
            MainForm m_Form = Application.OpenForms[0] as MainForm;

            if (m_Form != null)
            {
                m_Form.Controls["BarcodeScannerMode_Combo"].Enabled = true;
                m_Form.Controls["BarcodeScannerMode_Label"].Enabled = true;
            }
        }

        private static void Application_EnterThreadModal(object sender, EventArgs e)
        {
            MainForm m_Form = Application.OpenForms[0] as MainForm;

            if (m_Form != null)
            {
                m_Form.Controls["BarcodeScannerMode_Combo"].Enabled = false;
                m_Form.Controls["BarcodeScannerMode_Label"].Enabled = false;
            }
        }
    }
}
