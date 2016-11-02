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
    public partial class Edit_Account_Mdi : Form
    {
        public Account Account { get; set; }

        public Edit_Account_Mdi()
        {
            InitializeComponent();
        }

        private void Edit_Account_Mdi_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Cities = m_Context.Cities.Select(q => new { ID = q.ID, Name = q.Name }).ToList();

                this.City_Combo.DataSource = m_Cities;
                this.City_Combo.ValueMember = "ID";
                this.City_Combo.DisplayMember = "Name";

                this.City_Combo.SelectedIndexChanged += City_Combo_SelectedIndexChanged;

                this.City_Combo.Invalidate();

                var m_AccountTypes = m_Context.AccountTypes.ToList();
                this.AccountType_Combo.DataSource = m_AccountTypes;
                this.AccountType_Combo.ValueMember = "ID";
                this.AccountType_Combo.DisplayMember = "Name";

                this.AccountType_Combo.Invalidate();
            }

            this.AccountType_Combo.SelectedValue = this.Account.AccountTypeID;
            this.AccountName_Box.Text = this.Account.Name;
            this.City_Combo.SelectedValue = this.Account.CityID;
            this.Province_Combo.SelectedValue = this.Account.ProvinceID;

            this.Address_Box.Text = this.Account.Address;
            this.Phone_Box.Text = this.Account.Phone;
            this.Gsm_Box.Text = this.Account.Gsm;
            this.Email_Box.Text = this.Account.Email;
        }

        private void City_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                int m_CityID = Convert.ToInt32(this.City_Combo.SelectedValue);
                City m_City = m_Context.Cities.Where(q => q.ID == m_CityID).FirstOrDefault();

                if (m_City != null)
                {
                    var m_Provinces = m_City.Provinces.ToList();

                    this.Province_Combo.DataSource = m_Provinces;
                    this.Province_Combo.ValueMember = "ID";
                    this.Province_Combo.DisplayMember = "Name";

                    this.Province_Combo.Invalidate();
                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateAll())
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    /*Account m_Account = new Account();
                    m_Account.AccountTypeID = Convert.ToInt32(this.AccountType_Combo.SelectedValue);
                    m_Account.Name = this.AccountName_Box.Text;
                    m_Account.CityID = Convert.ToInt32(this.City_Combo.SelectedValue);
                    m_Account.ProvinceID = Convert.ToInt32(this.Province_Combo.SelectedValue);
                    m_Account.Address = this.Address_Box.Text;
                    m_Account.Phone = this.Phone_Box.Text;
                    m_Account.Gsm = this.Gsm_Box.Text;
                    m_Account.Email = this.Email_Box.Text;
                    m_Account.OwnerID = Program.User.WorksAtID.Value;

                    m_Context.Accounts.Add(m_Account);
                    m_Context.SaveChanges();*/

                    this.Close();
                }
            }
        }

        private bool ValidateAll()
        {
            if (this.AccountName_Box.Text.Length < 3)
            {
                this.Error_Provider.SetError(this.AccountName_Box, "En az 3 karakterden oluşan bir hesap adı giriniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.AccountName_Box, "");

            /*if (this.Address_Box.Text.Length < 3)
            {
                this.Error_Provider.SetError(this.Address_Box, "Geçerli bir adres giriniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Address_Box, "");*/

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Account m_Account = m_Context.Accounts.Where(q => q.Name == this.AccountName_Box.Text).FirstOrDefault();

                if (m_Account != null)
                {
                    this.Error_Provider.SetError(this.AccountName_Box, "Bu ad ile açılmış başka bir hesap var. Farklı bir ad tanımlayınız.");
                    return false;
                }
            }

            return true;
        }
    }
}
