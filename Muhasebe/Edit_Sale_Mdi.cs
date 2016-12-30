using Muhasebe.Custom;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Muhasebe.Gumplings;
using Muhasebe.Events;

namespace Muhasebe
{
    public partial class Edit_Sale_Mdi : Form
    {
        public Invoice Invoice { get; set; }

        public Edit_Sale_Mdi()
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
                this.Edit_Sale_List.Items.Clear();
                var m_Nodes = this.Invoice.Nodes;

                decimal m_Subtotal = 0;
                decimal m_Tax = 0;
                decimal m_Total = 0;
                int i = 0;
                Color m_Shaded = Color.FromArgb(240, 240, 240);

                m_Nodes.All(delegate (InvoiceNode m_Node)
                {
                    m_Node.Invoice = this.Invoice;
                    m_Node.InvoiceID = this.Invoice.ID;

                    if (m_Node.ItemID > 0)
                        m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    if (m_Node.Item != null || m_Node.ItemID < 0)
                    {
                        ListViewItem m_ViewItem = new ListViewItem();
                        m_ViewItem.Tag = m_Node.ItemID;

                        if (m_Node.UseCustomPrice == null)
                            m_Node.UseCustomPrice = false;

                        m_ViewItem.Text = m_Node.Item != null ? m_Node.Item.Product.Barcode : "Kayıt Dışı";

                        if (m_Node.Item == null && m_Node.Description.Length > 0)
                            m_ViewItem.SubItems.Add(m_Node.Description);
                        else
                            m_ViewItem.SubItems.Add(m_Node.Item.Product.Name);

                        if (m_Node.Item != null)
                            m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Amount.Value, m_Node.Item.UnitType.DecimalPlaces, null));
                        else
                            m_ViewItem.SubItems.Add(m_Node.Amount.Value.ToString());

                        m_ViewItem.SubItems.Add(m_Node.Item != null ? m_Node.Item.UnitType.Name : "-");
                        m_ViewItem.SubItems.Add(string.Format("%{0}", m_Node.Item != null ? m_Node.Item.Tax.Value.ToString() : m_Node.Tax.Value.ToString()));

                        decimal basePrice = 0.00m;
                        decimal finalPrice = 0.00m;

                        if (m_Node.Item != null &&
                            this.Invoice.PaymentTypeID.HasValue &&
                            this.Invoice.PaymentTypeID == 3 &&
                            m_Node.Item.TermedPrice.HasValue &&
                            m_Node.Item.TermedPrice.Value > m_Node.Item.FinalPrice &&
                            m_Node.UseCustomPrice == false &&
                            this.UseTermedPrice_Check.Checked
                            )
                        {
                            basePrice = m_Node.Item.TermedPrice.Value;
                            finalPrice = basePrice * m_Node.Amount.Value;
                        }
                        else
                        {
                            if (m_Node.UseCustomPrice == false && m_Node.Item != null)
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

                        this.Edit_Sale_List.Items.Add(m_ViewItem);
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
            if (this.Edit_Sale_List.SelectedItems.Count == 1)
                this.düzenleToolStripMenuItem.Enabled = true;

            if (this.Edit_Sale_List.SelectedItems.Count >= 1)
                this.silToolStripMenuItem.Enabled = true;

            if (this.Edit_Sale_List.SelectedItems.Count == 0)
            {
                this.düzenleToolStripMenuItem.Enabled = false;
                this.silToolStripMenuItem.Enabled = false;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Edit_Sale_List.SelectedItems.Count == 1)
            {
                int m_ItemID = Convert.ToInt32(this.Edit_Sale_List.SelectedItems[0].Tag);

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
            if (this.Edit_Sale_List.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(string.Format("Seçili {0} objeyi silmek istediğinizden emin misiniz?", this.Edit_Sale_List.SelectedItems.Count), "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem m_ViewItem in this.Edit_Sale_List.SelectedItems)
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

        private void Save_Button_Click(object sender, EventArgs e)
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
                    //this.Invoice.CreatedAt = DateTime.Now;
                    this.Invoice.AuthorID = Program.User.ID;

                    this.Invoice.State = "Complete";

                    decimal m_Total = 0;
                    decimal m_Tax = 0;

                    this.Invoice.Nodes.All(delegate (InvoiceNode m_Node)
                    {
                        m_Total += m_Node.FinalPrice.Value;
                        m_Tax += m_Node.FinalPrice.Value * ((decimal)(m_Node.Tax.Value / 100));

                        /*if (this.Decrease_Stock_Check.Checked && m_Node.Item != null)
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount -= m_Node.Amount.Value;

                        m_Node.Invoice = this.Invoice;
                        m_Node.Item = null;*/

                        return true;
                    });

                    if (this.Invoice.Discount.HasValue)
                    {
                        m_Total = m_Total - this.Invoice.Discount.Value;
                    }

                    Invoice m_Actual = m_Context.Invoices.Where(q => q.ID == this.Invoice.ID).FirstOrDefault();
                    m_Actual.OwnerID = this.Invoice.OwnerID;
                    m_Actual.AuthorID = this.Invoice.AuthorID;
                    m_Actual.CreatedAt = this.Invoice.CreatedAt;
                    m_Actual.Discount = this.Invoice.Discount;
                    m_Actual.PaymentTypeID = this.Invoice.PaymentTypeID;
                    m_Actual.State = this.Invoice.State;
                    m_Actual.TargetID = this.Invoice.TargetID;

                    var m_Added = this.Invoice.Nodes.Except(m_Actual.Nodes, (p, p1) => p.ItemID == p1.ItemID).ToList();
                    var m_Deleted = m_Actual.Nodes.Except(this.Invoice.Nodes, (p, p1) => p.ItemID == p1.ItemID).ToList();
                    var m_Changed = m_Actual.Nodes.Intersect(this.Invoice.Nodes, (p, p1) => p.ItemID == p1.ItemID && (p.Amount != p1.Amount || p.BasePrice != p1.BasePrice || p.UseCustomPrice != p1.UseCustomPrice)).ToList();

                    m_Added.All(delegate (InvoiceNode m_Node)
                    {
                        if (Decrease_Stock_Check.Checked && m_Node.ItemID > 0)
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount -= m_Node.Amount.Value;

                        m_Actual.Nodes.Add(m_Node);

                        return true;
                    });

                    m_Deleted.All(delegate (InvoiceNode m_Node)
                    {
                        if (Increase_Stock_Check.Checked && m_Node.ItemID > 0)
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount += m_Node.Amount.Value;

                        InvoiceNode m_ToDelete = m_Actual.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault();

                        m_Actual.Nodes.Remove(m_ToDelete);
                        m_Context.Entry(m_ToDelete).State = System.Data.Entity.EntityState.Deleted;

                        return true;
                    });

                    m_Changed.All(delegate (InvoiceNode m_Node)
                    {
                        InvoiceNode m_Knode = this.Invoice.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault();

                        if (m_Knode != null)
                        {
                            if (m_Node.Amount > m_Knode.Amount)
                            {// Bazıları silinmiş

                                if (m_Node.ItemID > 0 && Increase_Stock_Check.Checked) //Eğer kayıt dışı satış değilse
                                    m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount += m_Node.Amount.Value - m_Knode.Amount.Value;
                            }
                            else if (m_Node.Amount < m_Knode.Amount)
                            {
                                if (m_Node.ItemID > 0 && Decrease_Stock_Check.Checked) // Kayıt dışı satış değisle
                                    m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount -= m_Knode.Amount.Value - m_Node.Amount.Value;
                            }

                            m_Node.Amount = m_Knode.Amount;
                            m_Node.BasePrice = m_Knode.BasePrice;
                            m_Node.FinalPrice = m_Knode.FinalPrice;
                            m_Node.UseCustomPrice = m_Knode.UseCustomPrice;

                            if (m_Node.UseCustomPrice == null)
                                m_Node.UseCustomPrice = false;
                        }

                        return true;
                    });

                    m_Actual.Nodes.All(delegate (InvoiceNode m_Node)
                    {
                        m_Node.Invoice = m_Actual;
                        m_Node.Item = null;

                        return true;
                    });

                    if (m_Actual.PaymentTypeID != 3) // Vadeli değil
                    {
                        Income m_Income = m_Context.Incomes.Where(q => q.InvoiceID == m_Actual.ID).FirstOrDefault();
                        m_Income.Amount = m_Total;
                    }

                    AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.AccountID == m_Actual.TargetID && q.ContractID == m_Actual.ID && q.MovementTypeID == 1).FirstOrDefault();

                    if (m_Movement != null)
                    {
                        m_Movement.Value = m_Total;
                    }

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
            m_Pop.InvoiceNodeCreated += Pop_InvoiceNodeCreated;
            m_Pop.ShowDialog();
        }

        private void Pop_InvoiceNodeCreated(InvoiceNode node)
        {
            this.Append(node);
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
            m_Gump.InvoiceNodeCreated += Pop_InvoiceNodeCreated;
            m_Gump.NextID = m_LowestID;
            m_Gump.ShowDialog();
        }

        private void Edit_Sale_Mdi_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.Invoice = m_Context.Invoices.Where(q => q.ID == this.Invoice.ID).FirstOrDefault();

                var m_PaymentsTypes = m_Context.PaymentTypes.ToList();

                this.Payment_Combo.DataSource = m_PaymentsTypes;
                this.Payment_Combo.DisplayMember = "Name";
                this.Payment_Combo.ValueMember = "ID";
                this.Payment_Combo.Invalidate();

                this.Payment_Combo.SelectedValueChanged += Payment_Combo_SelectedValueChanged;
                this.Payment_Combo.SelectedValue = this.Invoice.PaymentTypeID;

                if (this.Invoice.TargetID.HasValue)
                {
                    this.Account_Box.SelectedText = m_Context.Accounts.Where(q => q.ID == this.Invoice.TargetID).FirstOrDefault().Name;
                    this.Account_Box.Enabled = false;
                }

                if (this.Invoice.Discount.HasValue)
                    this.Discount_Num.Value = this.Invoice.Discount.Value;
                else
                    this.Discount_Num.Value = 0;

                this.Payment_Combo.Enabled = false;

                PopulateListView();

                this.Author_Label.Text = string.Format("Kasiyer: {0} {1}", Program.User.Name, Program.User.Surname);

                EventSink.BarcodeScanned += EventSink_BarcodeScanned;
            }
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            if (args.Barcode != string.Empty)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    string m_Barcode = args.Barcode;

                    var m_Item = m_Context.Items.Where(q => q.Inventory.OwnerID == Program.User.WorksAtID && q.Product.Barcode == m_Barcode).FirstOrDefault();

                    if (m_Item == null)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            Add_Item_Pop m_Pop = new Add_Item_Pop(m_Barcode);
                            m_Pop.ShowDialog();
                        });
                    }
                    else
                    {
                        InvoiceNode m_Node = new InvoiceNode(m_Item);
                        m_Node.Amount = 1;
                        m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;
                        this.Append(m_Node);
                    }
                }
            }
        }

        private void Edit_Sale_List_DoubleClick(object sender, EventArgs e)
        {
            this.düzenleToolStripMenuItem_Click(sender, e);
        }
    }
}
