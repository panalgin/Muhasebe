using Muhasebe.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Add_Offer_Pop : Form
    {
        public Offer Offer { get; set; }

        public Add_Offer_Pop()
        {
            InitializeComponent();
        }

        private void Add_Offer_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.Offer == null)
                    this.Offer = new Offer();
            }

            EventSink.BarcodeScanned += EventSink_BarcodeScanned;
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
                        OfferNode m_Node = new OfferNode();
                        m_Node.ItemID = m_Item.ID;
                        m_Node.OfferID = this.Offer.ID;
                        m_Node.Offer = this.Offer;
                        m_Node.Amount = 1.00M;

                        if (this.Offer.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.Offer.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.Offer.Nodes.Add(m_Node);
                    }
                    else
                        MessageBox.Show("Okuttuğunuz bu barkoda ait bir ürün bulunamadı.", "Hata", MessageBoxButtons.OK);
                }

                PopulateListView();
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];
                int m_NodeID = Convert.ToInt32(m_Item.Tag);

                OfferNode m_CurrentNode = this.Offer.Nodes.Where(q => q.ID == m_NodeID).FirstOrDefault();
                OfferNode_Edit_Gumpling m_Pop = new OfferNode_Edit_Gumpling();
                m_Pop.OfferNode = m_CurrentNode;
                m_Pop.ShowDialog();

                this.PopulateListView();
            }
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.Offer.Nodes.All(delegate (OfferNode m_Node)
                {
                    m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Node.ID;

                    string imageResult = "";

                    if (!string.IsNullOrEmpty(m_Node.Item.LocalImagePath) && File.Exists(m_Node.Item.LocalImagePath))
                        imageResult = "Var";
                    else
                        imageResult = "Yok";

                    m_Item.Text = imageResult;
                    m_Item.SubItems.Add(m_Node.Item.Product.Barcode);
                    m_Item.SubItems.Add(m_Node.Item.Product.Name);

                    int numberOfDecimalPlaces = m_Node.Item.UnitType.DecimalPlaces;
                    string unitTypeName = m_Node.Item.UnitType.Name;

                    string formatString = String.Concat("{0:F", numberOfDecimalPlaces, "} {1}");

                    m_Item.SubItems.Add(string.Format(formatString, m_Node.Amount, unitTypeName, unitTypeName));
                    m_Item.SubItems.Add(m_Node.Description);

                    this.listView1.Items.Add(m_Item);

                    return true;
                });
            }
        }
    }
}
