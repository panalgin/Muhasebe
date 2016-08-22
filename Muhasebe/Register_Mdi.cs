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
    public partial class Register_Mdi : Form
    {
        public Register_Mdi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();

                Company m_Company = new Company();
                m_Company.Name = this.Comp_Name_Box.Text;
                m_Company.Sector = this.Comp_Sector_Combo.SelectedItem.ToString();
                m_Company.Address = this.Comp_Adress_Box.Text;
                m_Company.Province = this.Comp_Province_Box.Text;
                m_Company.District = this.Comp_District_Box.Text;
                m_Company.Biography = this.Comp_Biography_Box.Text;
                m_Company.Phone = this.Phone_Box.Text;
                m_Company.Gsm = this.CellPhone_Box.Text;
                m_Company.Fax = this.Fax_Box.Text;
                m_Company.CreatedAt = DateTime.Now;

                User m_User = new User();
                m_User.Name = this.Name_Box.Text;
                m_User.Surname = this.Surname_Box.Text;
                m_User.Email = this.Email_Box.Text;
                m_User.Password = this.Password_Box.Text;
                m_User.BornAt = this.BornAt_Picker.Value;
                m_User.State = "Active";
                m_User.Level = "User";
                m_User.PositionID = 1;
                m_User.WorksAt = m_Company;
                m_User.CreatedAt = DateTime.Now;

                Inventory m_Inventory = new Inventory();
                m_Inventory.Owner = m_Company;
                m_Inventory.Name = "Depo #1";

                m_Context.Inventories.Add(m_Inventory);
                m_Context.Companies.Add(m_Company);
                m_Context.Users.Add(m_User);
                m_Context.SaveChanges();


                MessageBox.Show("Kayıt başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
        private bool ValidateInput()
        {
            if (this.Comp_Name_Box.Text == null || Comp_Name_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Comp_Name_Box, "Şirket ismini girmelisiniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Comp_Name_Box, string.Empty);

            if (this.Comp_Province_Box.Text == null || Comp_Province_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Comp_Province_Box, "Şirketinizin bulunduğu ili girin.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Comp_Province_Box, string.Empty);

            if (this.Comp_District_Box.Text == null || Comp_District_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Comp_District_Box, "Şirketinizin bulunduğu ilçeyi girin.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Comp_District_Box, string.Empty);

            if (this.Comp_Adress_Box.Text == null || Comp_Adress_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Comp_Adress_Box, "Şirketinizin adresini girin.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Comp_Adress_Box, string.Empty);

            if (this.Comp_Biography_Box.Text == null || Comp_Biography_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Comp_Biography_Box, "Şirketinizin biyografisini girin.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Comp_Biography_Box, string.Empty);

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

            MuhasebeEntities m_Context = new MuhasebeEntities();
            User m_Existing = m_Context.Users.Where(q => q.Email == this.Email_Box.Text).FirstOrDefault();
            if (m_Existing != null)
            {
                this.Error_Provider.SetError(this.Email_Box, "Bu email adresi başka bir kullanıcı tarafından kullanımda");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Email_Box, string.Empty);

            if (this.Password_Box.Text.Length < 6)
            {
                this.Error_Provider.SetError(this.Password_Box, "6 karakterli bir şifre seçmelisiniz");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Password_Box, string.Empty);

            if (this.Confirm_Box.Text != Password_Box.Text)
            {
                this.Error_Provider.SetError(this.Confirm_Box, "Şifreleriniz uyuşmuyor");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Confirm_Box, string.Empty);


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

            if (this.BornAt_Picker.Value == null)
            {
                this.Error_Provider.SetError(this.BornAt_Picker, "Doğum tarihinizi giriniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.BornAt_Picker, string.Empty);

            if (this.Phone_Box.Text == null || Phone_Box.Text == "")
            {
                this.Error_Provider.SetError(this.Phone_Box, "Şirket telefonunu giriniz");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Phone_Box, string.Empty);

            if (this.CellPhone_Box == null || CellPhone_Box.Text == "")
            {
                this.Error_Provider.SetError(this.CellPhone_Box, "GSM numaranızı girmelisiniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.CellPhone_Box, string.Empty);


            return true;
        }

        private void Register_Mdi_Load(object sender, EventArgs e)
        {
            this.Comp_Sector_Combo.SelectedIndex = 0;
        }
    }
}
