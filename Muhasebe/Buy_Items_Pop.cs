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

namespace Muhasebe
{
    public partial class Buy_Items_Pop : Form
    {
        public StockMovement StockMovement { get; set; }
        public Buy_Items_Pop()
        {
            InitializeComponent();
        }

        private void Buy_Items_Pop_Load(object sender, EventArgs e)
        {
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;

            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.StockMovement == null)
                    this.StockMovement = new StockMovement();

                var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                this.PaymentType_Combo.DataSource = m_PaymentTypes;
                this.PaymentType_Combo.ValueMember = "ID";
                this.PaymentType_Combo.DisplayMember = "Name";

                this.PaymentType_Combo.Invalidate();
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

                        if (this.StockMovement.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.StockMovement.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.StockMovement.Nodes.Add(m_Node);
                    }
                    else
                        MessageBox.Show("Okuttuğunuz bu barkoda ait bir ürün bulunamadı.", "Hata", MessageBoxButtons.OK);
                }

                PopulateListView();
            }
        }

        private void PopulateListView()
        {
            this.Buy_Items_List.Items.Clear();
            this.Buy_Items_List.BeginUpdate();

            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.StockMovement.Nodes.All(delegate (StockMovementNode m_Node)
                {
                    m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    ListViewItem m_ViewItem = new ListViewItem();
                    m_ViewItem.Tag = m_Node.ID;
                    m_ViewItem.Text = m_Node.Item.Product.Barcode;
                    m_ViewItem.SubItems.Add(m_Node.Item.OrderCode);
                    m_ViewItem.SubItems.Add(m_Node.Item.Product.Name);
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.Amount * m_Node.Item.BasePrice.Value));

                    this.Buy_Items_List.Items.Add(m_ViewItem);

                    return true;
                });
            }

            this.Buy_Items_List.EndUpdate();

        }
    }
}
