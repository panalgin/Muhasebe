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
    public partial class Manage_Accounts_Mdi : Form
    {
        public Manage_Accounts_Mdi()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Account_Mdi m_Mdi = new Add_Account_Mdi();
            m_Mdi.ShowDialog();
        }

        private void Manage_Accounts_Mdi_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            this.Accounts_List.Items.Clear();

            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Accounts = m_Context.Accounts.Where(q => q.OwnerID == Program.User.WorksAtID);

                m_Accounts.All(delegate (Account account)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = account.ID;
                    m_Item.Text = account.Name;
                    m_Item.SubItems.Add(account.ID.ToString());
                    m_Item.SubItems.Add(account.AccountType.Name);
                    m_Item.SubItems.Add(account.City.Name);
                    m_Item.SubItems.Add(account.Province.Name);
                    m_Item.SubItems.Add(account.Phone);
                    m_Item.SubItems.Add(account.Gsm);
                    m_Item.SubItems.Add(account.Email);

                    this.Accounts_List.Items.Add(m_Item);

                    return true;
                });
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
