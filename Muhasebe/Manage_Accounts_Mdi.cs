using Muhasebe.Custom;
using OpenHtmlToPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

                if (this.Accounts_Tab.SelectedIndex == 0)
                {
                    if (this.Customers_List.SelectedItems.Count > 0)
                        m_AccountID = Convert.ToInt32(this.Customers_List.SelectedItems[0].Tag);
                }
                else
                {
                    if (this.Suppliers_List.SelectedItems.Count > 0)
                        m_AccountID = Convert.ToInt32(this.Suppliers_List.SelectedItems[0].Tag);
                }

                if (m_AccountID > 0)
                {
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
                        string m_Message = string.Format("{0} adlı {1} hesabı ve ona ait tüm gelir/gider bilgisi silinecek, emin misiniz?", m_Account.Name, m_Account.AccountType.Name);

                        if (MessageBox.Show(m_Message, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            var m_Movements = m_Context.AccountMovements.Where(q => q.AccountID == m_Account.ID);

                            m_Movements.Where(q => q.MovementTypeID == 1).All(delegate (AccountMovement mov)
                            {
                                //Bu sefer InvoiceID var Contractta

                                Invoice m_Invoice = m_Context.Invoices.Where(q => q.ID == mov.ContractID).FirstOrDefault();

                                if (m_Invoice != null)
                                {
                                    m_Invoice.Nodes.All(delegate (InvoiceNode node)
                                    {
                                        /*if (node.Item != null)
                                            node.Item.Amount += node.Amount.Value;*/

                                        return true;
                                    });

                                    m_Context.InvoiceNodes.RemoveRange(m_Invoice.Nodes);
                                    m_Context.Invoices.Remove(m_Invoice);
                                }


                                return true;
                            });

                            m_Context.AccountMovements.RemoveRange(m_Movements);

                            //Peşin satışlardan sonra üretilen gelirlerdeki ürünleri geri koy
                            var m_Incomes = m_Context.Incomes.Where(q => q.AccountID == m_AccountID);
                            m_Incomes.All(delegate (Income m_Income)
                            {
                                if (m_Income.Invoice != null)
                                {
                                    m_Income.Invoice.Nodes.All(delegate (InvoiceNode node)
                                    {
                                        /*if (node.Item != null)
                                            node.Item.Amount += node.Amount.Value;*/

                                        return true;
                                    });

                                    m_Context.InvoiceNodes.RemoveRange(m_Income.Invoice.Nodes);
                                    m_Context.Invoices.Remove(m_Income.Invoice);
                                }

                                return true;
                            });

                            m_Context.Incomes.RemoveRange(m_Incomes);
                            m_Context.Accounts.Remove(m_Account);
                            m_Context.SaveChanges();

                            ClearAccountHistory();
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

        private void ClearAccountHistory()
        {
            this.Account_History_View.Items.Clear();

            this.Buy_Volume_Label.Text = "0 TL";
            this.Sell_Volume_Label.Text = "0 TL";

            this.Loan_Label.Text = "0 TL";
            this.Debt_Label.Text = "0 TL";

            this.Charged_Label.Text = "0 TL";
            this.Paid_Label.Text = "0 TL";

            this.Net_Loan_Label.Text = "0 TL";
            this.Net_Debt_Label.Text = "0 TL";

            this.Net_Value_Label.Text = "0 TL";
            this.Net_State_Label.Text = "Nötr";
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
                AccountSummary m_Summary = this.CalculateNet(m_Movements);

                this.Buy_Volume_Label.Text = string.Format("{0} TL", m_Summary.BuyVolume.ToString());
                this.Sell_Volume_Label.Text = string.Format("{0} TL", m_Summary.SellVoluma.ToString());

                this.Loan_Label.Text = string.Format("{0} TL", m_Summary.LoanTotal.ToString());
                this.Debt_Label.Text = string.Format("{0} TL", m_Summary.DebtTotal.ToString());

                this.Charged_Label.Text = string.Format("{0} TL", m_Summary.Charged.ToString());
                this.Paid_Label.Text = string.Format("{0} TL", m_Summary.Paid.ToString());

                this.Net_Loan_Label.Text = string.Format("{0} TL", m_Summary.LoanNet.ToString());
                this.Net_Debt_Label.Text = string.Format("{0} TL", m_Summary.DebtNet.ToString());

                this.Net_Value_Label.Text = string.Format("{0} TL", Math.Abs(m_Summary.Net));

                if (m_Summary.Net < 0)
                    this.Net_State_Label.Text = "Alacağınız var.";
                else if (m_Summary.Net > 0)
                    this.Net_State_Label.Text = "Borcunuz var.";
                else
                    this.Net_State_Label.Text = "Nötr";
            });
        }

        private void Accounts_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Accounts_Tab.SelectedIndex == 0)
            {
                foreach (ListViewItem item in this.Suppliers_List.SelectedItems)
                {
                    item.Selected = false;
                }
            }
            else if (this.Accounts_Tab.SelectedIndex == 1)
            {
                foreach (ListViewItem item in this.Customers_List.SelectedItems)
                {
                    item.Selected = false;
                }
            }

            this.Edit_Button.Enabled = false;
            this.Delete_Button.Enabled = false;
        }

        private void Delete_Movement_Button_Click(object sender, EventArgs e)
        {
            if (this.Account_History_View.SelectedItems.Count > 0)
            {
                int m_MovementID = Convert.ToInt32(this.Account_History_View.SelectedItems[0].Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.ID == m_MovementID).FirstOrDefault();

                    if (m_Movement != null)
                    {
                        Account m_Account = m_Context.Accounts.Where(q => q.ID == m_Movement.AccountID).FirstOrDefault();

                        switch (m_Movement.MovementTypeID)
                        {
                            case 1: //Ticari Mal Satışı (Peşin / Vadeli)
                                {
                                    string message = "Yaptığınız {0} TL tutarındaki {1} satışa ait tüm gelir bilgileri silinecek, sattığınız ürünlerin adetleri stoğunuza geri eklenecek, onaylıyor musunuz?";

                                    Invoice m_Invoice = m_Context.Invoices.Where(q => q.ID == m_Movement.ContractID).FirstOrDefault();

                                    if (m_Invoice != null)
                                    {
                                        message = string.Format(message, m_Invoice.Nodes.Sum(q => q.FinalPrice).Value, m_Movement.PaymentTypeID == 3 ? "vadeli" : "peşin");

                                        if (MessageBox.Show(message, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            if (m_Movement.PaymentTypeID != 3) // vadeli değil yani ödenmiş ve gelir oluşmuş
                                            {
                                                Income m_Income = m_Context.Incomes.Where(q => q.InvoiceID == m_Invoice.ID).FirstOrDefault();

                                                if (m_Income != null)
                                                    m_Context.Incomes.Remove(m_Income);
                                            }

                                            m_Invoice.Nodes.All(delegate (InvoiceNode node)
                                            {
                                                node.Item.Amount += node.Amount.Value;

                                                return true;
                                            });

                                            m_Context.InvoiceNodes.RemoveRange(m_Invoice.Nodes);
                                            m_Context.Invoices.Remove(m_Invoice);

                                        }
                                    }

                                    m_Context.AccountMovements.Remove(m_Movement);
                                    m_Context.SaveChanges();

                                    break;
                                }

                            case 2: //Vadenin Tahsilatı
                                {
                                    string message = "Yaptığınız {0} TL tutarındaki alacak tahsilatı iptal edilecek ve bu işleme ait geliriniz silinecek, onaylıyor musunuz?";

                                    Income m_Income = m_Context.Incomes.Where(q => q.ID == m_Movement.ContractID).FirstOrDefault();

                                    if (m_Income != null)
                                    {
                                        message = string.Format(message, m_Income.Amount.Value);

                                        if (MessageBox.Show(message, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            m_Context.Incomes.Remove(m_Income);
                                        }
                                    }

                                    m_Context.AccountMovements.Remove(m_Movement);
                                    m_Context.SaveChanges();

                                    break;
                                }

                            case 3: //Ürün Tedariği Yapıldı
                                {
                                    string message = "Yaptığınız {0} kalemlik mal tahsilatı iptal edilecek, \nBu işlem ile stoğunuza eklenmiş olan ürünler silinecektir. \nBu işlemden oluşan giderler silinecektir. \n\nOnaylıyor musunuz?";

                                    StockMovement m_StockMov = m_Context.StockMovements.Where(q => q.ID == m_Movement.ContractID && q.OwnerID == Program.User.WorksAtID).FirstOrDefault();

                                    if (m_StockMov != null)
                                    {
                                        message = string.Format(message, m_StockMov.Nodes.Count);

                                        if (MessageBox.Show(message, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            m_StockMov.Nodes.All(delegate (StockMovementNode m_Node)
                                            {
                                                m_Node.Item.Amount -= m_Node.Amount;

                                                return true;
                                            });

                                            if (m_StockMov.PaymentTypeID != 3)
                                            {
                                                Expenditure m_Expenditure = m_Context.Expenditures.Where(q => q.MovementID == m_Movement.ID).FirstOrDefault();

                                                if (m_Expenditure != null)
                                                    m_Context.Expenditures.Remove(m_Expenditure);
                                            }

                                            m_Context.AccountMovements.Remove(m_Movement);
                                            m_Context.SaveChanges();
                                        }
                                    }

                                    break;
                                }

                            case 4: // Borç ödemesi yapıldı.
                                {
                                    string message = "Yaptığınız {0} TL tutarındaki borç ödemesi silinecektir. \nBu işleme ait, gider yönetiminde gözüken gideriniz de silinecektir. \n\nOnaylıyor musunuz?";

                                    
                                    Expenditure m_Expenditure = m_Context.Expenditures.Where(q => q.ID == m_Movement.ContractID && q.OwnerID == Program.User.WorksAtID).FirstOrDefault();

                                    if (m_Expenditure != null)
                                    {
                                        message = string.Format(message, m_Expenditure.Amount.Value);

                                        if (MessageBox.Show(message, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            m_Context.Expenditures.Remove(m_Expenditure);
                                        }
                                    }

                                    m_Context.AccountMovements.Remove(m_Movement);
                                    m_Context.SaveChanges();


                                    break;
                                }
                        }

                        PopulateAccountHistory(m_Account);
                    }
                }
            }
        }

        private void Account_History_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Account_History_View.SelectedItems.Count > 0)
            {
                this.Delete_Movement_Button.Enabled = true;
                this.silToolStripMenuItem.Enabled = true;
                this.seçiliİşlemleriPDFyeAktarToolStripMenuItem.Enabled = true;

                if (this.Account_History_View.SelectedItems.Count > 1)
                {
                    this.seçiliİşlemleriPDFyeAktarToolStripMenuItem.Text = "Seçili İşlemleri PDF Dosyasına Aktar";
                    this.Delete_Movement_Button.Enabled = false;
                    this.silToolStripMenuItem.Enabled = false;
                }
                else
                    this.seçiliİşlemleriPDFyeAktarToolStripMenuItem.Text = "PDF'ye Aktar";
            }
            else
            {
                this.silToolStripMenuItem.Enabled = false;
                this.seçiliİşlemleriPDFyeAktarToolStripMenuItem.Enabled = false;
                this.Delete_Movement_Button.Enabled = false;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Delete_Movement_Button_Click(sender, e);
        }

        private void seçiliİşlemleriPDFyeAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.seçiliİşlemleriPDFyeAktarToolStripMenuItem.Enabled = false;

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    List<AccountMovement> m_List = new List<AccountMovement>();

                    foreach(ListViewItem m_Item in this.Account_History_View.SelectedItems)
                    {
                        int m_MovementID = Convert.ToInt32(m_Item.Tag);

                        AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.ID == m_MovementID).FirstOrDefault();
                        m_List.Add(m_Movement);
                    }

                    m_List = m_List.OrderBy(q => q.CreatedAt).ToList();
                    Account m_Account = m_List.FirstOrDefault().Account;
                    AccountSummary m_Summary = this.CalculateNet(m_List);

                    string m_Data = "";
                    string m_SummaryTemplate = "Yukarıdaki işlemler sonucunda firmamız <strong>{0}</strong>";
                    string m_BaseTemplate = "<tr class=\"movement\">" +
                                                 "<td class=\"id\">{0}</td>" +
                                                 "<td class=\"mtype\">{1}</td>" +
                                                 "<td class=\"date\">{2}</td>" +
                                                 "<td class=\"author\">{3}</td>" +
                                                 "<td class=\"payment\">{4}</td>" +
                                                 "<td class=\"desc\">{5}</td> " +
                                                 "<td class=\"price\">{6}</td>" +
                                             "</tr>";

                    m_List.All(delegate (AccountMovement movement)
                    {
                        string m_Description = "";

                        if (movement.MovementTypeID != 3) // ürün tedariğinde yorum yok
                        {
                            if (movement.MovementTypeID == 1 && movement.PaymentTypeID != 3) // Vadeli satış değilse
                            {
                                Income m_Income = m_Context.Incomes.Where(q => q.InvoiceID == movement.ContractID).FirstOrDefault();

                                if (m_Income != null)
                                    m_Description = m_Income.Description;
                            }
                            else if (movement.MovementTypeID == 2) // Alacak tahsilatı, gelir
                            {
                                Income m_Income = m_Context.Incomes.Where(q => q.ID == movement.ContractID).FirstOrDefault();

                                if (m_Income != null)
                                    m_Description = m_Income.Description;
                            }
                            else if (movement.MovementTypeID == 4) // Borç ödemesi, gider
                            {
                                Expenditure m_Expenditure = m_Context.Expenditures.Where(q => q.ID == movement.ContractID).FirstOrDefault();

                                if (m_Expenditure != null)
                                    m_Description = m_Expenditure.Description;
                            }
                        }

                        string m_Formatted = string.Format(m_BaseTemplate, movement.ID, movement.MovementType.Name, movement.CreatedAt.ToString("dd/MM/yyyy"),
                            movement.Author.FullName, movement.PaymentType.Name, m_Description, ItemHelper.GetFormattedPrice(movement.Value));

                        m_Data += m_Formatted;

                        if (movement.MovementTypeID == 1 || movement.MovementTypeID == 3) // satılan malları veya alınanları listeleyelim
                        {
                            string m_ExTemplate =   "<tr>" +
                                                        "<td colspan=\"7\">" +
                                                            "<div class=\"columns sale\">" +
                                                                "<div class=\"order-code col\">Sipariş Kodu</div>" +
                                                                "<div class=\"name col\">Ürün Adı</div>" +
                                                                "<div class=\"amount col\">Miktar</div>" +
                                                                "<div class=\"base-price col\">Birim</div>" +
                                                                "<div class=\"total-price col\">Toplam</div>" +
                                                            "</div>" +
                                                            "{0}" +
                                                        "</td>" +
                                                    "</tr>";

                            string m_ExItemTemplate =   "<div class=\"item\">" +
                                                            "<div class=\"order-code col\">{0}</div>" +
                                                            "<div class=\"name col\">{1}</div>" +
                                                            "<div class=\"amount col\">{2}</div>" +
                                                            "<div class=\"base-price col\">{3}</div>" +
                                                            "<div class=\"total-price col\">{4}</div>" +
                                                        "</div>";

                            if (movement.MovementTypeID == 1) //Mal satışı
                            {
                                Invoice m_Invoice = m_Context.Invoices.Where(q => q.ID == movement.ContractID).FirstOrDefault();

                                if (m_Invoice != null)
                                {
                                    string m_ExItemInfo = "";

                                    m_Invoice.Nodes.All(delegate (InvoiceNode node)
                                    {
                                        string m_OrderCode = node.Item != null ? node.Item.OrderCode : "-";
                                        string m_Name = node.Item != null ? node.Item.Product.Name : node.Description;
                                        string m_Amount = node.Item != null ? ItemHelper.GetFormattedAmount(node.Amount.Value, node.Item.UnitType.DecimalPlaces, node.Item.UnitType.Abbreviation)
                                                                            : ItemHelper.GetFormattedAmount(node.Amount.Value, 0, "Adet");
                                        string m_Base = ItemHelper.GetFormattedPrice(node.BasePrice.Value);
                                        string m_Final = ItemHelper.GetFormattedPrice(node.FinalPrice.Value);

                                        m_ExItemInfo += string.Format(m_ExItemTemplate, m_OrderCode, m_Name, m_Amount, m_Base, m_Final);
                                        return true;
                                    });

                                    m_ExItemInfo = string.Format(m_ExTemplate, m_ExItemInfo);
                                    m_Data += m_ExItemInfo;
                                }
                            }
                            else if (movement.MovementTypeID == 3) //Mal alımı
                            {
                                StockMovement m_Stock = m_Context.StockMovements.Where(q => q.ID == movement.ContractID).FirstOrDefault();

                                if (m_Stock != null)
                                {
                                    string m_ExItemInfo = "";

                                    m_Stock.Nodes.All(delegate (StockMovementNode node)
                                    {
                                        string m_OrderCode = node.Item.OrderCode;
                                        string m_Name = node.Item.Product.Name;
                                        string m_Amount = ItemHelper.GetFormattedAmount(node.Amount, node.Item.UnitType.DecimalPlaces, node.Item.UnitType.Abbreviation);
                                        string m_Base = ItemHelper.GetFormattedPrice(node.BasePrice.Value);
                                        string m_Final = ItemHelper.GetFormattedPrice(node.FinalPrice.Value);

                                        m_ExItemInfo += string.Format(m_ExItemTemplate, m_OrderCode, m_Name, m_Amount, m_Base, m_Final);
                                        return true;
                                    });

                                    m_ExItemInfo = string.Format(m_ExTemplate, m_ExItemInfo);
                                    m_Data += m_ExItemInfo;
                                }
                            }
                        }

                        return true;
                    });

                    if (m_Summary.Net < 0)
                        m_SummaryTemplate = string.Format(m_SummaryTemplate, string.Format("sizden {0} alacaklıdır.", ItemHelper.GetFormattedPrice(Math.Abs(m_Summary.Net))));
                    else if (m_Summary.Net > 0)
                        m_SummaryTemplate = string.Format(m_SummaryTemplate, string.Format("size {0} borçludur.", ItemHelper.GetFormattedPrice(Math.Abs(m_Summary.Net))));
                    else
                        this.Net_State_Label.Text = "Herhangi bir alacak/borç bulunmamaktadır.";

                    this.Save_Dialog.FileName = string.Format("{0} - İşlem Geçmişi.pdf", m_Account.Name);

                    if (this.Save_Dialog.ShowDialog() == DialogResult.OK)
                    {
                        string m_SavePath = this.Save_Dialog.FileName;
                        string html = "";
                        string m_LocalPath = Application.StartupPath;
                        string m_IndexPath = Path.Combine(m_LocalPath, "View\\AccountMovementsForm\\index.html");
                        string m_AbsPath = Path.Combine(m_LocalPath, "View\\AccountMovementsForm\\");

                        using (StreamReader m_Reader = new StreamReader(m_IndexPath, Encoding.UTF8, true))
                        {
                            html = m_Reader.ReadToEnd();
                        }

                        html = html.Replace("{PATH}", m_AbsPath);
                        html = html.Replace("{BASEPATH}", m_LocalPath);
                        html = html.Replace("{COMPANY-NAME}", Program.User.WorksAt.Name);
                        html = html.Replace("{TAXID}", Program.User.WorksAt.TaxID);
                        html = html.Replace("{TAXPLACE}", Program.User.WorksAt.TaxDepartment);
                        html = html.Replace("{ADDRESS}", Program.User.WorksAt.Address);
                        html = html.Replace("{DISTRICT}", Program.User.WorksAt.District);
                        html = html.Replace("{PROVINCE}", Program.User.WorksAt.Province);
                        html = html.Replace("{TELEPHONE}", Program.User.WorksAt.Phone);
                        html = html.Replace("{EMAIL}", Program.User.WorksAt.Email);

                        html = html.Replace("{DATA}", m_Data);
                        html = html.Replace("{SUMMARY}", m_SummaryTemplate);

                        html = html.Replace("{ACCOUNT-NAME}", m_Account.Name);
                        html = html.Replace("{ACCOUNT-TAXOFFICE", m_Account.TaxDepartment);
                        html = html.Replace("{ACCOUNT-TAXID}", m_Account.TaxID);
                        html = html.Replace("{ACCOUNT-ADDRESS}", m_Account.Address);
                        html = html.Replace("{ACCOUNT-CITY}", m_Account.City.Name);
                        html = html.Replace("{ACCOUNT-PROVINCE}", m_Account.Province.Name);
                        html = html.Replace("{ACCOUNT-PHONE}", m_Account.Phone);
                        html = html.Replace("{ACCOUNT-GSM}", m_Account.Gsm);
                        html = html.Replace("{ACCOUNT-EMAIL}", m_Account.Email);

                        try
                        {
                            var pdf = Pdf
                                .From(html)
                                .OfSize(PaperSize.A4)
                                .WithTitle("Title")
                                .WithMargins(0.8.Centimeters())
                                .WithoutOutline()
                                .Portrait()
                                .Comressed()
                                .Content();

                            FileStream m_Stream = new FileStream(m_SavePath, FileMode.Create);

                            using (BinaryWriter m_Writer = new BinaryWriter(m_Stream))
                            {
                                m_Writer.Write(pdf, 0, pdf.Length);
                            }

                            m_Stream.Close();
                            m_Stream.Dispose();
                            MessageBox.Show("Pdf dosyası oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Logger.Enqueue(ex);
                            MessageBox.Show("Oluşan bir hata nedeniyle pdf dosyası yazılamadı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            this.seçiliİşlemleriPDFyeAktarToolStripMenuItem.Enabled = true;
        }

        private AccountSummary CalculateNet(List<AccountMovement> m_Movements)
        {
            AccountSummary m_Summary = new AccountSummary();

            m_Summary.BuyVolume = m_Movements.Where(q => q.MovementTypeID == 3).Sum(q => q.Value);
            m_Summary.SellVoluma = m_Movements.Where(q => q.MovementTypeID == 1).Sum(q => q.Value);

            m_Summary.LoanTotal = m_Movements.Where(q => q.MovementTypeID == 1 && q.PaymentTypeID == 3).Sum(q => q.Value); // Yapılan vadeli satışlardan alacak geçmişimiz
            m_Summary.Charged = m_Movements.Where(q => q.MovementTypeID == 2).Sum(q => q.Value); // Yapılan vade tahsilatları

            m_Summary.DebtTotal = m_Movements.Where(q => q.MovementTypeID == 3 && q.PaymentTypeID == 3).Sum(q => q.Value); // Yapılan vadeli ürün alımlarımıza ait borcumuz
            m_Summary.Paid = m_Movements.Where(q => q.MovementTypeID == 4).Sum(q => q.Value); // Yaptığımız borç ödemeleri

            return m_Summary;
        }

        private class AccountSummary
        {
            public decimal BuyVolume { get; set; }
            public decimal SellVoluma { get; set; }
            public decimal LoanTotal { get; set; }
            public decimal DebtTotal { get; set; }

            public decimal Charged { get; set; }
            public decimal Paid { get; set; }

            public decimal LoanNet { get { return LoanTotal - Charged; } }
            public decimal DebtNet { get { return DebtTotal - Paid; } }
            public decimal Net { get { return DebtNet - LoanNet; } }
        }
    }
}
