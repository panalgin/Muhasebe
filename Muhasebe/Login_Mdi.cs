using Muhasebe.Events;
using Muhasebe.Properties;
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
    public partial class Login_Mdi : Form
    {
        public Login_Mdi()
        {
            InitializeComponent();
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();

            User m_User = m_Context.Users.Where(q => q.Email == this.Email_Text.Text && q.Password == this.Password_Text.Text).FirstOrDefault();

            if (m_User != null)
            {
                this.Email_Text.Enabled = false;
                this.Password_Text.Enabled = false;

                if (Remind_Check.Checked)
                {
                    Settings.Default.Email = this.Email_Text.Text;
                    Settings.Default.Password = this.Password_Text.Text;
                    Settings.Default.CheckState = this.Remind_Check.Checked;
                    Settings.Default.Save();
                }

                Program.User = m_User;

                UserLogonEventArgs m_Args = new UserLogonEventArgs();
                m_Args.User = m_User;
                m_Args.LogonAt = DateTime.Now;
                EventSink.InvokeUserLogon(sender, m_Args);

                this.Close();
            }
            else
            {
                MessageBox.Show("Girdiğiniz email adresi veya şifreniz yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Email_Text.Clear();
                Password_Text.Clear();
            }
        }

        private void Password_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Login_Btn_Click(sender, e);
            }
        }

        private void Email_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Login_Btn_Click(sender, e);
            }
        }

        private void Login_Mdi_Load(object sender, EventArgs e)
        {
            this.Email_Text.Text = Settings.Default.Email;
            this.Password_Text.Text = Settings.Default.Password;
            this.Remind_Check.Checked = Settings.Default.CheckState;
        }

        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            Register_Mdi m_Mdi = new Register_Mdi();
            m_Mdi.WindowState = FormWindowState.Normal;
            m_Mdi.Show();
        }

        private void linklabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About_Mdi m_Mdi = new About_Mdi();
            m_Mdi.MdiParent = this.MdiParent;
            m_Mdi.Show();
            m_Mdi.WindowState = FormWindowState.Maximized;
        }
    }
}
