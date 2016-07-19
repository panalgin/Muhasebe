using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Muhasebe
{
    public partial class Edit_User_Pop : Form
    {
        public delegate void OnUserEdited(User User);
        public event OnUserEdited UserEdited;
        public User User { get; set; }

        public Edit_User_Pop()
        {
            InitializeComponent();
        }

        private void Edit_User_Pop_Load(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();
            var m_Position = m_Context.JobPositions.ToList();

            this.Position_Combo.DataSource = m_Position;
            this.Position_Combo.ValueMember = "ID";
            this.Position_Combo.DisplayMember = "Name";

            if (this.User != null)
            {
                this.Email_Box.Text = this.User.Email;
                this.PW_Box.Text = this.User.Password;
                this.RePW_Box.Text = this.User.Password;
                this.Name_Box.Text = this.User.Name;
                this.Surname_Box.Text = this.User.Surname;
                this.Birthday_Picker.Value = this.User.BornAt.Value;
                this.Position_Combo.SelectedValue = this.User.PositionID;

            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.User != null)
            {
                if (ValidateInput())
                {
                    MicroEntities m_Context = new MicroEntities();

                    User m_Actual = m_Context.Users.Where(q => q.ID == this.User.ID).FirstOrDefault();

                    if (m_Actual != null)
                    {
                        m_Actual.Email = this.Email_Box.Text;
                        m_Actual.Password = this.PW_Box.Text;
                        m_Actual.Name = this.Name_Box.Text;
                        m_Actual.Surname = this.Surname_Box.Text;
                        m_Actual.BornAt = Convert.ToDateTime(this.Birthday_Picker.Value);
                        m_Actual.PositionID = Convert.ToInt32(this.Position_Combo.SelectedValue);

                        m_Context.SaveChanges();
                        UserInvokeEdited(m_Actual);

                        this.Close();
                    }
                }
            }
        }

        private void UserInvokeEdited(User User)
        {
            if (UserEdited != null)
                UserEdited(User);
        }

        private bool ValidateInput()
        {
            if (this.Email_Box.Text == null || this.Email_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Email_Box, "Email adresi girmelisiniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Email_Box, string.Empty);

            string email = this.Email_Box.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                this.Error_Provider.SetError(this.Email_Box, string.Empty);
            else
            {
                this.Error_Provider.SetError(this.Email_Box, "Geçerli bir Email adresi girmelisiniz");
                return false;
            }

           /* 
            Sorusu Düzenlenecek !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            MicroEntities m_Context = new MicroEntities();
            User m_Existing = m_Context.Users.Where(q => q.Email == this.Email_Box.Text).FirstOrDefault();
            if (m_Existing != null)
            {
                this.Error_Provider.SetError(this.Email_Box, "Bu email adresi başka bir kullanıcı tarafından kullanımda");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Email_Box, string.Empty);
            */
            if (this.PW_Box.Text.Length < 6)
            {
                this.Error_Provider.SetError(this.PW_Box, "6 karakterli bir şifre seçmelisiniz");
                return false;
            }
            else
                this.Error_Provider.SetError(this.PW_Box, string.Empty);

            if (this.RePW_Box.Text != PW_Box.Text)
            {
                this.Error_Provider.SetError(this.RePW_Box, "Şifreleriniz uyuşmuyor");
                return false;
            }
            else
                this.Error_Provider.SetError(this.RePW_Box, string.Empty);


            if (this.Name_Box.Text == null || Name_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Name_Box, "Kullanıcının ismini girmelisiniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Name_Box, string.Empty);

            if (this.Surname_Box.Text == null || Surname_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Surname_Box, "Kullanıcının soyismini girmelisiniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Surname_Box, string.Empty);

            if (this.Position_Combo.SelectedValue == null)
            {
                this.Error_Provider.SetError(this.Position_Combo, "Bir pozisyon seçmelisiniz");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Position_Combo, string.Empty);

            return true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
