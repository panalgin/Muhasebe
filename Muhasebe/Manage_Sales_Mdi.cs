﻿using System;
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
            if (this.Invoice.Nodes.Any(q => q.ItemID == node.ItemID) == false)
            {
                node.InvoiceID = this.Invoice.ID;
                this.Invoice.Nodes.Add(node);

            }
            else
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

                PopulateListView();

                this.Author_Label.Text = string.Format("Kasiyer: {0} {1}", Program.User.Name, Program.User.Surname);
            }
        }

        private void PopulateListView()
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {

                this.Node_List.Items.Clear();

                var m_Nodes = this.Invoice.Nodes;

                decimal m_Subtotal = 0;
                decimal m_Tax = 0;
                decimal m_Total = 0;
                int i = 0;
                Color m_Shaded = Color.FromArgb(240, 240, 240);

                m_Nodes.All(delegate(InvoiceNode m_Node)
                {
                    Item m_Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();
                    m_Node.Item = m_Item;
                    m_Node.Invoice = this.Invoice;
                    m_Node.InvoiceID = this.Invoice.ID;

                    if (m_Item != null)
                    {
                        ListViewItem m_ViewItem = new ListViewItem();
                        m_ViewItem.Tag = m_Node.ItemID;
                        m_ViewItem.Text = m_Item.Product.Barcode;
                        m_ViewItem.SubItems.Add(m_Item.Product.Name);
                        m_ViewItem.SubItems.Add(m_Node.Amount.Value.ToString()); // format
                        m_ViewItem.SubItems.Add(m_Item.UnitType.Name);
                        m_ViewItem.SubItems.Add(string.Format("%{0}", m_Item.Tax.Value.ToString()));
                        m_ViewItem.SubItems.Add(string.Format("{0:0.00} TL", m_Item.FinalPrice.Value));
                        m_ViewItem.SubItems.Add(string.Format("{0:0.00} TL", m_Item.FinalPrice.Value * m_Node.Amount)); // format shit


                        if (i++ % 2 == 1)
                        {
                            m_ViewItem.BackColor = m_Shaded;
                            m_ViewItem.UseItemStyleForSubItems = true;
                        }

                        m_Node.BasePrice = m_Item.BasePrice * m_Node.Amount.Value;
                        m_Node.FinalPrice = m_Item.FinalPrice * m_Node.Amount.Value;
                        m_Node.Tax = m_Item.Tax;

                        m_Subtotal += m_Item.BasePrice.Value * m_Node.Amount.Value;
                        m_Tax += (m_Item.BasePrice.Value * ((decimal)m_Item.Tax.Value / 100)) * m_Node.Amount.Value;
                        m_Total += m_Item.FinalPrice.Value * m_Node.Amount.Value;

                        this.Node_List.Items.Add(m_ViewItem);
                    }

                    return true;
                });

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

                    Item_Set_Amount_Gumpling m_Gumpling = new Item_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.ItemAmountChanged += m_Gumpling_ItemAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        void m_Gumpling_ItemAmountChanged(InvoiceNode node)
        {
            InvoiceNode m_Actual = this.Invoice.Nodes.Where(q => q.ItemID == node.ItemID).FirstOrDefault();

            if (m_Actual != null)
                m_Actual.Amount = node.Amount;

            this.PopulateListView();
        }

        private void Context_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (this.Node_List.SelectedItems.Count == 1)
                this.düzenleToolStripMenuItem.Enabled = true;

            if (this.Node_List.SelectedItems.Count >= 1)
                this.silToolStripMenuItem.Enabled = true;

            if (this.Node_List.SelectedItems.Count == 0)
            {
                this.düzenleToolStripMenuItem.Enabled = false;
                this.silToolStripMenuItem.Enabled = false;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Node_List.SelectedItems.Count == 1)
            {
                int m_ItemID = Convert.ToInt32(this.Node_List.SelectedItems[0].Tag);

                InvoiceNode m_Node = this.Invoice.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                if (m_Node != null)
                {
                    Item_Set_Amount_Gumpling m_Gumpling = new Item_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.ItemAmountChanged += m_Gumpling_ItemAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Node_List.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(string.Format("Seçili {0} objeyi silmek istediğinizden emin misiniz?", this.Node_List.SelectedItems.Count), "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem m_ViewItem in this.Node_List.SelectedItems)
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

                    this.Invoice.Nodes.All(delegate(InvoiceNode m_Node)
                    {
                        m_Total += m_Node.FinalPrice.Value;
                        m_Tax += m_Node.FinalPrice.Value - m_Node.BasePrice.Value;

                        m_Context.Items.Attach(m_Node.Item);
                        m_Context.Products.Attach(m_Node.Item.Product);
                        m_Context.UnitTypes.Attach(m_Node.Item.UnitType);

                        m_Node.Item.Amount -= m_Node.Amount.Value;
                        m_Node.InvoiceID = this.Invoice.ID;
                        m_Context.InvoiceNodes.Add(m_Node);
                        return true;
                    });

                    Income m_Income = new Income();
                    m_Income.Amount = m_Total;
                    m_Income.AuthorID = Program.User.ID;
                    m_Income.CreatedAt = DateTime.Now;
                    m_Income.Description = "Ticari mal satışı yapıldı.";
                    m_Income.CreatedAt = DateTime.Now;
                    m_Income.IncomeTypeID = 1; // Gayrisafi
                    m_Income.Invoice = this.Invoice;
                    m_Income.OwnerID = Program.User.WorksAtID;
                    m_Income.PaymentTypeID = this.Invoice.PaymentTypeID;

                    m_Context.Incomes.Add(m_Income);
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
    }
}
