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
            PopulateList();
        }

        private void Manage_Accounts_Mdi_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                this.Customers_List.BeginUpdate();
                this.Suppliers_List.BeginUpdate();

                this.Customers_List.Items.Clear();
                this.Suppliers_List.Items.Clear();

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_Customers = m_Context.Accounts.Where(q => q.OwnerID == Program.User.WorksAtID && q.AccountType.Name != "Tedarikçi");
                    var m_Suppliers = m_Context.Accounts.Where(q => q.OwnerID == Program.User.WorksAtID && q.AccountType.Name != "Müşteri");

                    m_Customers.All(delegate (Account account)
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

                        this.Customers_List.Items.Add(m_Item);

                        return true;
                    });

                    m_Suppliers.All(delegate (Account account)
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

                        this.Suppliers_List.Items.Add(m_Item);

                        return true;
                    });
                }

                this.Customers_List.EndUpdate();
                this.Suppliers_List.EndUpdate();
            });
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Customers_List.SelectedItems.Count > 0 || this.Suppliers_List.SelectedItems.Count > 0)
            {
                int m_AccountID = 0;

                if (this.Customers_List.SelectedItems.Count > 0)
                    m_AccountID = Convert.ToInt32(this.Customers_List.SelectedItems[0].Tag);
                else
                    m_AccountID = Convert.ToInt32(this.Suppliers_List.SelectedItems[0].Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();

                    if (m_Account != null)
                    {
                        Edit_Account_Mdi m_Mdi = new Edit_Account_Mdi();
                        m_Mdi.Account = m_Account;
                        m_Mdi.ShowDialog();
                        PopulateList();
                    }
                }
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Customers_List.SelectedItems.Count > 0 || this.Suppliers_List.SelectedItems.Count > 0)
            {
                int m_AccountID = 0;

                if (this.Customers_List.SelectedItems.Count > 0)
                    m_AccountID = Convert.ToInt32(this.Customers_List.SelectedItems[0].Tag);
                else
                    m_AccountID = Convert.ToInt32(this.Suppliers_List.SelectedItems[0].Tag);

                using(MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();

                    if (m_Account != null)
                    {
                        string m_Message = string.Format("{0} adlı {1} hesabı silinecek, emin misiniz?", m_Account.Name, m_Account.AccountType.Name);

                        if (MessageBox.Show(m_Message, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            m_Context.Accounts.Remove(m_Account);
                            m_Context.SaveChanges();
                            PopulateList();
                        }
                    }
                }
            }
        }

        private void Customers_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Customers_List.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;

                int m_AccountID = Convert.ToInt32(this.Customers_List.SelectedItems[0].Tag);

                using(MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();
                    PopulateAccountHistory(m_Account);
                }
                
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
            }

        }

        private void Suppliers_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Suppliers_List.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;

                int m_AccountID = Convert.ToInt32(this.Suppliers_List.SelectedItems[0].Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();
                    PopulateAccountHistory(m_Account);
                }

            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
            }
        }

        private void PopulateAccountHistory(Account account)
        {
            this.Account_History_View.BeginUpdate();

            this.Account_History_View.BeginInvoke((MethodInvoker)delegate ()
            {
                this.Account_History_View.Items.Clear();

                if (account != null)
                {
                    using (MuhasebeEntities m_Context = new MuhasebeEntities())
                    {
                        var m_Movements = m_Context.AccountMovements.Where(q => q.AccountID == account.ID);

                        int index = 0;
                        Color m_Shaded = Color.FromArgb(240, 240, 240);

                        m_Movements.All(delegate (AccountMovement movement)
                        {
                            ListViewItem m_Item = new ListViewItem();
                            m_Item.Tag = movement.ID;
                            m_Item.Text = movement.CreatedAt.ToString();
                            m_Item.SubItems.Add(movement.Author.FullName);
                            m_Item.SubItems.Add(movement.PaymentType.Name);
                            m_Item.SubItems.Add(movement.Value.ToString());
                            m_Item.SubItems.Add(movement.MovementType.Name);

                            if (index++ % 2 == 0)
                            {
                                m_Item.BackColor = m_Shaded;
                                m_Item.UseItemStyleForSubItems = true;
                            }

                            if (movement.Flag == "Red")
                                m_Item.ForeColor = Color.Red;
                            else if (movement.Flag == "Green")
                                m_Item.ForeColor = Color.Green;
                            else if (movement.Flag == "Yellow")
                                m_Item.ForeColor = Color.SaddleBrown;

                            
                            this.Account_History_View.Items.Insert(0, m_Item);

                            return true;
                        });

                        CalculateAccountStatistics(m_Movements.ToList());
                    }
                }
            });

            this.Account_History_View.EndUpdate();
        }

        private void Inspect_Button_Click(object sender, EventArgs e)
        {

        }

        private void CalculateAccountStatistics(List<AccountMovement> m_Movements)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                decimal buyVolume = 0.00m;
                decimal sellVolume = 0.00m;

                decimal totalLoan = 0.00m;
                decimal totalCharged = 0.00m;

                decimal totalDebt = 0.00m;
                decimal totalPaid = 0.00m;

                decimal netLoan = 0.00m;
                decimal netDebt = 0.00m;

                decimal netValue = 0.00m;

                buyVolume = m_Movements.Where(q => q.MovementTypeID == 3).Sum(q => q.Value);
                sellVolume = m_Movements.Where(q => q.MovementTypeID == 1).Sum(q => q.Value);

                totalLoan = m_Movements.Where(q => q.MovementTypeID == 1 && q.PaymentTypeID == 3).Sum(q => q.Value); // Yapılan vadeli satışlardan alacak geçmişimiz
                totalCharged = m_Movements.Where(q => q.MovementTypeID == 2).Sum(q => q.Value); // Yapılan vade tahsilatları

                totalDebt = m_Movements.Where(q => q.MovementTypeID == 3 && q.PaymentTypeID == 3).Sum(q => q.Value); // Yapılan vadeli ürün alımlarımıza ait borcumuz
                totalPaid = m_Movements.Where(q => q.MovementTypeID == 4).Sum(q => q.Value); // Yaptığımız borç ödemeleri

                netLoan = totalLoan - totalCharged;
                netDebt = totalDebt - totalPaid;

                this.Buy_Volume_Label.Text = string.Format("{0} TL", buyVolume.ToString());
                this.Sell_Volume_Label.Text = string.Format("{0} TL", sellVolume.ToString());

                this.Loan_Label.Text = string.Format("{0} TL", totalLoan.ToString());
                this.Debt_Label.Text = string.Format("{0} TL", totalDebt.ToString());

                this.Charged_Label.Text = string.Format("{0} TL", totalCharged.ToString());
                this.Paid_Label.Text = string.Format("{0} TL", totalPaid.ToString());

                this.Net_Loan_Label.Text = string.Format("{0} TL", netLoan.ToString());
                this.Net_Debt_Label.Text = string.Format("{0} TL", netDebt.ToString());

                netValue = netDebt - netLoan;

                this.Net_Value_Label.Text = string.Format("{0} TL", Math.Abs(netValue));

                if (netValue < 0)
                    this.Net_State_Label.Text = "Alacağınız var.";
                else if (netValue > 0)
                    this.Net_State_Label.Text = "Borcunuz var.";
                else
                    this.Net_State_Label.Text = "Nötr";
            });
        }
    }
}
