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
    public partial class Add_User_Mdi : Form
    {
        public delegate void OnUserAdded(User user);
        public event OnUserAdded UserAdded;

        public Add_User_Mdi()
        {
            InitializeComponent();
        }

        private void InvokeUserAdded(User user)
        {
            if (this.UserAdded != null)
                this.UserAdded(user);
        }

        private void Add_Users_Mdi_Load(object sender, EventArgs e)
        {
            MicroEntities m_Context = new MicroEntities();
            var m_Positions = m_Context.JobPositions.ToList();

            this.Position_Combo.DataSource = m_Positions;
            this.Position_Combo.ValueMember = "ID";
            this.Position_Combo.DisplayMember = "Name";
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MicroEntities m_Context = new MicroEntities();
                User m_User = new User();

                m_User.Name = this.Name_Box.Text;
                m_User.Surname = this.Surname_Box.Text;
                m_User.Email = this.Email_Box.Text;
                m_User.BornAt = this.Birthday_Picker.Value;
                m_User.Password = this.PW_Box.Text;
                m_User.PositionID = Convert.ToInt32(this.Position_Combo.SelectedValue);
                m_User.WorksAtID = Program.User.WorksAtID;
                m_User.State = "Active";
                m_User.Level = "User";
                m_User.CreatedAt = DateTime.Now;

                m_Context.Users.Add(m_User);
                m_Context.SaveChanges();

                this.InvokeUserAdded(m_User);
                this.Close();
            }
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

            MicroEntities m_Context = new MicroEntities();
            User m_Existing = m_Context.Users.Where(q => q.Email == this.Email_Box.Text).FirstOrDefault();
            if (m_Existing != null)
            {
                this.Error_Provider.SetError(this.Email_Box, "Bu email adresi başka bir kullanıcı tarafından kullanımda");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Email_Box, string.Empty);

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
    }
}
