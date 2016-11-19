using Muhasebe.Custom;
using Muhasebe.Gumplings;
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
    public partial class Manage_Sales_Mdi : Form
    {
        public Invoice Invoice { get; set; }

        public Manage_Sales_Mdi()
        {
            InitializeComponent();
        }

        public void Append(InvoiceNode node)
        {
            if (node.ItemID < 0 || this.Invoice.Nodes.Any(q => q.ItemID == node.ItemID) == false)
            {
                node.InvoiceID = this.Invoice.ID;
                this.Invoice.Nodes.Add(node);
            }
            else if (node.ItemID > 0)
            {
                this.Invoice.Nodes.Where(q => q.ItemID == node.ItemID).FirstOrDefault().Amount += node.Amount;
            }

            PopulateListView();
        }

        private void Manage_Sales_Mdi_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.Invoice == null)
                {
                    this.Invoice = new Invoice();
                    this.Invoice.AuthorID = Program.User.ID;
                    this.Invoice.CreatedAt = DateTime.Now;
                    this.Invoice.OwnerID = Program.User.WorksAtID.Value;
                    this.Invoice.State = "Incomplete";
                }

                var m_PaymentsTypes = m_Context.PaymentTypes.ToList();

                this.Payment_Combo.DataSource = m_PaymentsTypes;
                this.Payment_Combo.DisplayMember = "Name";
                this.Payment_Combo.ValueMember = "ID";
                this.Payment_Combo.Invalidate();

                this.Payment_Combo.SelectedValueChanged += Payment_Combo_SelectedValueChanged;

                PopulateListView();

                this.Author_Label.Text = string.Format("Kasiyer: {0} {1}", Program.User.Name, Program.User.Surname);
            }
        }

        private void Payment_Combo_SelectedValueChanged(object sender, EventArgs e)
        { 
            if (this.Payment_Combo.SelectedValue != null)
            {
                this.Invoice.PaymentTypeID = Convert.ToInt32(this.Payment_Combo.SelectedValue);

                int m_PaymentTypeID = Convert.ToInt32(this.Payment_Combo.SelectedValue);

                if (m_PaymentTypeID == 3)
                { //Vadeli
                    this.UseTermedPrice_Check.Enabled = true;
                }
                else
                    this.UseTermedPrice_Check.Enabled = false;

                this.PopulateListView();
            }
        }

        private void PopulateListView()
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.SaleScreen_List.Items.Clear();
                var m_Nodes = this.Invoice.Nodes;

                decimal m_Subtotal = 0;
                decimal m_Tax = 0;
                decimal m_Total = 0;
                int i = 0;
                Color m_Shaded = Color.FromArgb(240, 240, 240);

                m_Nodes.All(delegate(InvoiceNode m_Node)
                {
                    m_Node.Invoice = this.Invoice;
                    m_Node.InvoiceID = this.Invoice.ID;

                    if (m_Node.ItemID > 0)
                        m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    if (m_Node.Item != null || m_Node.ItemID < 0)
                    {
                        ListViewItem m_ViewItem = new ListViewItem();
                        m_ViewItem.Tag = m_Node.ItemID;

                        m_ViewItem.Text = m_Node.Item != null ? m_Node.Item.Product.Barcode : "-";

                        if (m_Node.Item == null && m_Node.Description.Length > 0)
                            m_ViewItem.SubItems.Add(m_Node.Description);
                        else
                            m_ViewItem.SubItems.Add(m_Node.Item.Product.Name);

                        m_ViewItem.SubItems.Add(m_Node.Amount.Value.ToString()); // format
                        m_ViewItem.SubItems.Add(m_Node.Item != null ? m_Node.Item.UnitType.Name : "-");
                        m_ViewItem.SubItems.Add(string.Format("%{0}", m_Node.Item != null ? m_Node.Item.Tax.Value.ToString() : m_Node.Tax.Value.ToString()));

                        decimal basePrice = 0.00m;
                        decimal finalPrice = 0.00m;

                        if (m_Node.Item != null &&
                            this.Invoice.PaymentTypeID.HasValue && 
                            this.Invoice.PaymentTypeID == 3 && 
                            m_Node.Item.TermedPrice.HasValue && 
                            m_Node.Item.TermedPrice.Value > m_Node.Item.FinalPrice && 
                            m_Node.UseCustomPricing == false && 
                            this.UseTermedPrice_Check.Checked
                            )
                        {
                            basePrice = m_Node.Item.TermedPrice.Value;
                            finalPrice = basePrice * m_Node.Amount.Value;
                        }
                        else
                        {
                            if (m_Node.UseCustomPricing == false && m_Node.Item != null)
                            {
                                basePrice = m_Node.Item.FinalPrice.Value;
                                finalPrice = basePrice * m_Node.Amount.Value;
                            }
                            else
                            {
                                basePrice = m_Node.BasePrice.Value;
                                finalPrice = basePrice * m_Node.Amount.Value;
                            }
                        }

                        m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(basePrice));
                        m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(finalPrice)); // format shit


                        if (i++ % 2 == 1)
                        {
                            m_ViewItem.BackColor = m_Shaded;
                            m_ViewItem.UseItemStyleForSubItems = true;
                        }                            

                        m_Subtotal += m_Node.Item != null ? m_Node.Item.BasePrice.Value * m_Node.Amount.Value : m_Node.BasePrice.Value * m_Node.Amount.Value;
                        m_Tax += (finalPrice * ((decimal)m_Node.Tax.Value / 100));

                        m_Total += finalPrice;

                        m_Node.BasePrice = basePrice;
                        m_Node.FinalPrice = finalPrice;

                        this.SaleScreen_List.Items.Add(m_ViewItem);
                    }

                    return true;
                });

                if (this.Invoice.Discount.HasValue)
                {
                    if (m_Total > this.Invoice.Discount.Value)
                        m_Total = m_Total - this.Invoice.Discount.Value;
                    else
                    {
                        this.Invoice.Discount = 0;
                        this.Discount_Num.Value = 0;
                        this.Discount_Label.Text = ItemHelper.GetFormattedPrice(this.Invoice.Discount.Value);
                    }
                }

                this.Subtotal_Label.Text = string.Format("{0:0.00} TL", m_Subtotal);
                this.Tax_Label.Text = string.Format("{0:0.00} TL", m_Tax);
                this.Total_Label.Text = string.Format("{0:0.00} TL", m_Total);
            }
        }

        private void Manage_Sales_Mdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                if (this.Invoice.Nodes.Count > 0)
                {
                    InvoiceNode m_Node = this.Invoice.Nodes.LastOrDefault();

                    Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.NodeAmountChanged += NodeAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        private void NodeAmountChanged(dynamic node)
        {
            InvoiceNode m_Actual = this.Invoice.Nodes.Where(q => q.ItemID == node.ItemID).FirstOrDefault();

            if (m_Actual != null)
                m_Actual.Amount = node.Amount;

            this.PopulateListView();
        }

        private void Context_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (this.SaleScreen_List.SelectedItems.Count == 1)
                this.düzenleToolStripMenuItem.Enabled = true;

            if (this.SaleScreen_List.SelectedItems.Count >= 1)
                this.silToolStripMenuItem.Enabled = true;

            if (this.SaleScreen_List.SelectedItems.Count == 0)
            {
                this.düzenleToolStripMenuItem.Enabled = false;
                this.silToolStripMenuItem.Enabled = false;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SaleScreen_List.SelectedItems.Count == 1)
            {
                int m_ItemID = Convert.ToInt32(this.SaleScreen_List.SelectedItems[0].Tag);

                InvoiceNode m_Node = this.Invoice.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                if (m_Node != null)
                {
                    Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.NodeAmountChanged += NodeAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SaleScreen_List.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(string.Format("Seçili {0} objeyi silmek istediğinizden emin misiniz?", this.SaleScreen_List.SelectedItems.Count), "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem m_ViewItem in this.SaleScreen_List.SelectedItems)
                    {
                        int m_ItemID = Convert.ToInt32(m_ViewItem.Tag);

                        InvoiceNode m_Node = this.Invoice.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                        if (m_Node != null)
                            this.Invoice.Nodes.Remove(m_Node);
                    }

                    PopulateListView();
                }
            }
        }

        private void Sale_Button_Click(object sender, EventArgs e)
        {
            int m_PaymentTypeID = Convert.ToInt32(this.Payment_Combo.SelectedValue);
            
            if (m_PaymentTypeID == 3 && this.Account_Box.SelectedValue == null)
            {
                MessageBox.Show("Vadeli satışı ancak bir cari hesaba yapabilirsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.Invoice != null && this.Invoice.Nodes.Count > 0)
                {
                    this.Invoice.OwnerID = Program.User.WorksAtID.Value;
                    this.Invoice.PaymentTypeID = Convert.ToInt32(this.Payment_Combo.SelectedValue);
                    this.Invoice.CreatedAt = DateTime.Now;
                    this.Invoice.AuthorID = Program.User.ID;

                    this.Invoice.State = "Complete";

                    decimal m_Total = 0;
                    decimal m_Tax = 0;

                    this.Invoice.Nodes.All(delegate (InvoiceNode m_Node)
                    {
                        m_Total += m_Node.FinalPrice.Value;
                        m_Tax += m_Node.FinalPrice.Value * ((decimal)(m_Node.Tax.Value / 100));

                        if (this.Decrease_Stock_Check.Checked && m_Node.Item != null)
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount -= m_Node.Amount.Value;

                        m_Node.Invoice = this.Invoice;
                        m_Node.Item = null;

                        return true;
                    });

                    if (this.Invoice.Discount.HasValue)
                    {
                        m_Total = m_Total - this.Invoice.Discount.Value;
                    }

                    m_Context.Invoices.Add(this.Invoice);
                    m_Context.SaveChanges();


                    if (this.Invoice.PaymentTypeID != 3) //Vadeli bir satış değilse gelir olarak geçmişe ekleyelim
                    {
                        Income m_Income = new Income();
                        m_Income.Amount = m_Total;
                        m_Income.AuthorID = Program.User.ID;
                        m_Income.CreatedAt = DateTime.Now;
                        m_Income.Description = "Ticari mal satışı yapıldı.";
                        m_Income.IncomeTypeID = 1; // Genel
                        m_Income.InvoiceID = this.Invoice.ID;
                        m_Income.OwnerID = Program.User.WorksAtID;

                        if (this.Account_Box.SelectedValue != null)
                        {
                            int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);
                            m_Income.AccountID = m_AccountID;
                        }

                        m_Context.Incomes.Add(m_Income);
                    }

                    m_Context.SaveChanges();

                    string toWho = "bilinmeyen bir müşteriye";
                    string paymentText = "peşin";

                    if (this.Account_Box.SelectedValue != null)
                    {
                        int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);

                        Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();

                        if (m_Account != null)
                        {
                            toWho = string.Format("{0} adlı hesaba", m_Account.Name);

                            AccountMovement m_Movement = new AccountMovement();
                            m_Movement.AccountID = m_Account.ID;
                            m_Movement.AuthorID = Program.User.ID;
                            m_Movement.MovementTypeID = 1; // Kasadan satış
                            m_Movement.ContractID = this.Invoice.ID;
                            m_Movement.CreatedAt = DateTime.Now;
                            m_Movement.OwnerID = Program.User.WorksAtID.Value;
                            m_Movement.PaymentTypeID = this.Invoice.PaymentTypeID.Value;
                            m_Movement.Value = m_Total; // m_Income.Amount.Value;

                            this.Invoice.TargetID = m_Account.ID;

                            m_Context.AccountMovements.Add(m_Movement);
                        }
                    }

                    if (this.Invoice.PaymentTypeID == 3)
                        paymentText = "vadeli";

                    Event m_Event = new Event();
                    m_Event.AuthorID = Program.User.ID;
                    m_Event.CategoryID = 4; // Satış
                    m_Event.CreatedAt = DateTime.Now;
                    m_Event.Description = string.Format("Kullanıcı {0} {1} TL değerinde {2} satış yaptı.", toWho, m_Total, paymentText);
                    m_Event.OwnerID = Program.User.WorksAtID;

                    m_Context.Events.Add(m_Event);

                    m_Context.SaveChanges();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Satılabilecek herhangi bir ürün yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void manuelSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Sales_Mdi m_Pop = new Add_Sales_Mdi();
            m_Pop.SalesForm = this;
            m_Pop.ShowDialog();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Subtotal_Label_Click(object sender, EventArgs e)
        {
            if (this.Subtotal_Label.ForeColor == SystemColors.Control)
                this.Subtotal_Label.ForeColor = SystemColors.ControlText;
            else
                this.Subtotal_Label.ForeColor = SystemColors.Control;
        }

        private void UseTermedPrice_Check_CheckedChanged(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void Discount_Num_ValueChanged(object sender, EventArgs e)
        {
            this.Discount_Label.Text = ItemHelper.GetFormattedPrice(this.Discount_Num.Value);
            this.Invoice.Discount = this.Discount_Num.Value;

            this.PopulateListView();
        }

        private void kayıtDışıSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int m_LowestID = -1;

            var m_UntracedNodes = this.Invoice.Nodes.Where(q => q.ItemID < 0).Select(q => q.ItemID);

            if (m_UntracedNodes.Count() > 0)
                m_LowestID = m_UntracedNodes.Min() - 1;

            Sell_Untraced_Gumpling m_Gump = new Sell_Untraced_Gumpling();
            m_Gump.SalesForm = this;
            m_Gump.NextID = m_LowestID;
            m_Gump.ShowDialog(); 
        }
    }
}
