using AutoMapper;
using Muhasebe.Custom;
using Muhasebe.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFramework.Extensions;

namespace Muhasebe
{
    public partial class Edit_StockMovement_Mdi : Form
    {
        public StockMovement StockMovement { get; set; }

        public Edit_StockMovement_Mdi()
        {
            InitializeComponent();
        }

        private void Edit_StockMovement_Mdi_Load(object sender, EventArgs e)
        {
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;

            if (this.StockMovement != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    this.StockMovement = m_Context.StockMovements.Where(q => q.ID == this.StockMovement.ID).FirstOrDefault();

                    this.CreatedAt_Picker.Value = StockMovement.CreatedAt;
                    this.Account_Box.SelectedText = StockMovement.Account.Name;
                    this.Account_Box.Enabled = false;

                    if (this.StockMovement.Discount.HasValue)
                        this.Discount_Num.Value = StockMovement.Discount.Value;
                    else
                        this.Discount_Num.Value = 0;

                    var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                    this.PaymentType_Combo.DataSource = m_PaymentTypes;
                    this.PaymentType_Combo.ValueMember = "ID";
                    this.PaymentType_Combo.DisplayMember = "Name";

                    this.PaymentType_Combo.Invalidate();

                    this.PaymentType_Combo.SelectedValue = StockMovement.PaymentTypeID;
                    this.PaymentType_Combo.Enabled = false;

                    PopulateListView();
                }
            }

            if (this.StockMovement != null)
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<StockMovement, StockMovement>());
                    var mapper = config.CreateMapper();

                    this.StockMovement = mapper.Map<StockMovement>(StockMovement);
                }
                catch(Exception ex)
                {

                }
            }

           
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            if (args.Barcode != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_Item = m_Context.Items.Where(q => q.Product.Barcode == args.Barcode).FirstOrDefault();

                    if (m_Item != null)
                    {
                        StockMovementNode m_Node = new StockMovementNode();
                        m_Node.ItemID = m_Item.ID;
                        m_Node.StockMovementID = this.StockMovement.ID;
                        m_Node.Amount = 1.00M;
                        m_Node.BasePrice = m_Item.BasePrice;

                        if (this.StockMovement.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.StockMovement.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.StockMovement.Nodes.Add(m_Node);

                        this.Buy_Items_List.Focus();
                    }
                    else
                    {
                        Add_Item_Pop m_Pop = new Add_Item_Pop(args.Barcode);
                        m_Pop.ShowDialog();
                    }
                }

                PopulateListView();

            }
        }

        private void PopulateListView()
        {
            this.Buy_Items_List.Items.Clear();
            this.Buy_Items_List.BeginUpdate();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.StockMovement.Nodes.All(delegate (StockMovementNode m_Node)
                {
                    m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    ListViewItem m_ViewItem = new ListViewItem();
                    m_ViewItem.Tag = m_Node.ItemID;
                    m_ViewItem.Text = m_Node.Item.Product.Barcode;
                    m_ViewItem.SubItems.Add(m_Node.Item.OrderCode);
                    m_ViewItem.SubItems.Add(m_Node.Item.Product.Name);
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Item.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.BasePrice.Value));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.BasePrice.Value * m_Node.Amount));

                    this.Buy_Items_List.Items.Add(m_ViewItem);

                    return true;
                });

                decimal expectedSummary = this.StockMovement.Nodes.Sum(q => q.BasePrice.Value * q.Amount);
                this.SubTotal_Label.Text = ItemHelper.GetFormattedPrice(expectedSummary);

                decimal totalSummary = expectedSummary;

                if (this.StockMovement.Discount.HasValue)
                {
                    if (totalSummary > this.StockMovement.Discount.Value)
                        totalSummary -= this.StockMovement.Discount.Value;
                    else
                    {
                        this.StockMovement.Discount = 0;
                        this.Discount_Num.Value = 0;
                    }
                }

                this.Total_Label.Text = ItemHelper.GetFormattedPrice(totalSummary);
            }

            this.Buy_Items_List.EndUpdate();

        }

        private void Buy_Items_Pop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                if (this.StockMovement.Nodes.Count > 0)
                {
                    StockMovementNode m_Node = this.StockMovement.Nodes.LastOrDefault();
                    Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.NodeAmountChanged += NodeAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        private void NodeAmountChanged(dynamic node)
        {
            StockMovementNode m_Actual = this.StockMovement.Nodes.Where(q => q.ItemID == node.ItemID).FirstOrDefault();

            if (m_Actual != null)
            {
                m_Actual.Amount = node.Amount;
                m_Actual.BasePrice = node.BasePrice;
            }

            this.PopulateListView();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.StockMovement.Nodes == null || this.StockMovement.Nodes.Count <= 0)
            {
                MessageBox.Show("Ürün alımı için en az bir adet ürünü listeye eklemelisiniz.", "Hata");
                return;
            }

            int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();
                StockMovement m_Actual = m_Context.StockMovements.Where(q => q.ID == this.StockMovement.ID).FirstOrDefault();

                if (m_Account != null)
                {
                    var m_Added = this.StockMovement.Nodes.Except(m_Actual.Nodes, (p, p1) => p.ItemID == p1.ItemID).ToList();
                    var m_Deleted = m_Actual.Nodes.Except(this.StockMovement.Nodes, (p, p1) => p.ItemID == p1.ItemID).ToList();
                    var m_Changed = this.StockMovement.Nodes.Intersect(m_Actual.Nodes, (p, p1) => p.ItemID == p1.ItemID && (p.Amount != p1.Amount || p.BasePrice != p1.BasePrice)).ToList();

                    m_Actual.AccountID = m_Account.ID;
                    m_Actual.CreatedAt = CreatedAt_Picker.Value;
                    m_Actual.AuthorID = Program.User.ID;
                    m_Actual.OwnerID = Program.User.WorksAtID.Value;
                    m_Actual.PaymentTypeID = Convert.ToInt32(this.PaymentType_Combo.SelectedValue);

                    m_Deleted.All(delegate (StockMovementNode m_Node)
                    {
                        if (Decrese_Stock_Check.Checked)
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount -= m_Node.Amount;

                        StockMovementNode m_ToDelete = m_Actual.Nodes.Where(q => q.ID == m_Node.ID).FirstOrDefault();
                        m_Actual.Nodes.Remove(m_ToDelete);
                        m_Context.Entry(m_ToDelete).State = System.Data.Entity.EntityState.Deleted;

                        return true;
                    });

                    m_Added.All(delegate (StockMovementNode m_Node)
                    {
                        if (Increase_Stock_Check.Checked)
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount += m_Node.Amount;

                        m_Actual.Nodes.Add(m_Node);

                        return true;
                    });

                    m_Changed.All(delegate (StockMovementNode m_Node)
                    {
                        //actual node
                        StockMovementNode m_Anode = m_Actual.Nodes.Where(q => q.ID == m_Node.ID).FirstOrDefault();

                        if (m_Node.Amount > m_Anode.Amount && Increase_Stock_Check.Checked)
                            m_Context.Items.Where(q => q.ID == m_Anode.ItemID).FirstOrDefault().Amount += m_Node.Amount - m_Anode.Amount;

                        else if (m_Node.Amount < m_Anode.Amount && Decrese_Stock_Check.Checked)
                            m_Context.Items.Where(q => q.ID == m_Anode.ItemID).FirstOrDefault().Amount -= m_Anode.Amount - m_Node.Amount;

                        m_Anode.Amount = m_Node.Amount;
                        m_Anode.BasePrice = m_Node.BasePrice;

                        return true;
                    });
                    

                    m_Actual.Nodes.All(delegate (StockMovementNode m_Node)
                    {
                        m_Node.Parent = m_Actual;
                        m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;

                        return true;
                    });

                    m_Actual.Summary = m_Actual.Nodes.Sum(q => q.FinalPrice.Value);

                    if (this.StockMovement.Discount.HasValue)
                    {
                        m_Actual.Discount = this.StockMovement.Discount.Value;
                        m_Actual.Summary -= m_Actual.Discount.Value;
                    }

                    m_Context.SaveChanges();

                    AccountMovement movement = m_Context.AccountMovements.Where(q => q.MovementTypeID == 3 && q.ContractID == m_Actual.ID).FirstOrDefault();

                    if (movement != null)
                        movement.Value = m_Actual.Summary;

                    if (m_Actual.PaymentTypeID != 3) //Vadeli olmadığında, gideri doğrultalım
                    {
                        Expenditure m_Expenditure = m_Context.Expenditures.Where(q => q.AccountID == movement.AccountID && q.MovementID == movement.ID).FirstOrDefault();

                        if (m_Expenditure != null)
                        {
                            m_Expenditure.Amount = m_Actual.Summary;
                        }
                    }

                    m_Context.SaveChanges();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bu mal alımı için bir cari hesap belirtmelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Buy_Items_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                int m_ItemID = Convert.ToInt32(this.Buy_Items_List.SelectedItems[0].Tag);

                StockMovementNode m_Node = this.StockMovement.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                if (m_Node != null)
                {
                    this.StockMovement.Nodes.Remove(m_Node);
                    PopulateListView();
                }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                int m_ItemID = Convert.ToInt32(this.Buy_Items_List.SelectedItems[0].Tag);

                StockMovementNode m_Node = this.StockMovement.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                m_Gumpling.Node = m_Node;
                m_Gumpling.NodeAmountChanged += NodeAmountChanged;
                m_Gumpling.ShowDialog();
            }
        }

        private void Discount_Num_ValueChanged(object sender, EventArgs e)
        {
            this.StockMovement.Discount = this.Discount_Num.Value;
            this.PopulateListView();
        }

        private void Buy_Items_List_DoubleClick(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                Edit_Button_Click(sender, e);
            }
        }
    }
}
