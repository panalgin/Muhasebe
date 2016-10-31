using OpenHtmlToPdf;
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
    public partial class Manage_Orders_Mdi : Form
    {
        public Manage_Orders_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Orders_Mdi_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Order_Mdi m_Mdi = new Add_Order_Mdi();
            m_Mdi.ShowDialog();
            PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Orders = Program.User.WorksAt.Orders;

                m_Orders.All(delegate (Order order)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = order.ID;
                    m_Item.Text = order.ID.ToString();
                    m_Item.SubItems.Add(order.Name);
                    m_Item.SubItems.Add(order.CreatedAt.ToString());

                    if (order.Account != null)
                        m_Item.SubItems.Add(order.Account.Name);
                    else
                        m_Item.SubItems.Add("Yok");

                    m_Item.SubItems.Add(order.Note);

                    this.listView1.Items.Add(m_Item);

                    return true;
                });
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
                this.Export_Pdf_Button.Enabled = true;
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
                this.Export_Pdf_Button.Enabled = false;
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];
                int m_OrderID = Convert.ToInt32(m_Item.Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Order m_Order = m_Context.Orders.Where(q => q.ID == m_OrderID).FirstOrDefault();

                    if (m_Order != null)
                    {
                        if (MessageBox.Show(string.Format("{0} adlı sipariş silinecek, emin misiniz?", m_Order.Name), "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            m_Context.Orders.Remove(m_Order);
                            m_Context.SaveChanges();

                            PopulateListView();
                        }
                    }
                }

            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];
                int m_OrderID = Convert.ToInt32(m_Item.Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Order m_Order = m_Context.Orders.Where(q => q.ID == m_OrderID).FirstOrDefault();

                    if (m_Order != null)
                    {
                        Edit_Order_Mdi m_Mdi = new Edit_Order_Mdi();
                        m_Mdi.Order = m_Order;
                        m_Mdi.ShowDialog();

                        PopulateListView();
                    }
                }
            }
        }

        private void Export_Pdf_Button_Click(object sender, EventArgs e)
        {
            this.Export_Pdf_Button.Enabled = false;

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    ListViewItem m_Item = this.listView1.SelectedItems[0];
                    int m_OrderID = Convert.ToInt32(m_Item.Tag);

                    Order m_Order = m_Context.Orders.Where(q => q.ID == m_OrderID).FirstOrDefault();

                    this.Save_Dialog.FileName = string.Format("Sipariş - {0}.pdf", m_OrderID);

                    if (m_Order != null && this.Save_Dialog.ShowDialog() == DialogResult.OK)
                    {
                        string m_SavePath = this.Save_Dialog.FileName;
                        string html = "";
                        string m_LocalPath = Application.StartupPath;
                        string m_IndexPath = Path.Combine(m_LocalPath, "View\\OrderForm\\index.html");
                        string m_AbsPath = Path.Combine(m_LocalPath, "View\\OrderForm\\");

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
                        html = html.Replace("{ATTN-NAME}", m_Order.Account != null ? m_Order.Account.Name : "Yetkili");
                        html = html.Replace("{AUTHOR-NAME}", Program.User.FullName);
                        html = html.Replace("{AUTHOR-POSITION}", Program.User.Position.Name);
                        html = html.Replace("{AUTHOR-EMAIL}", Program.User.Email);
                        html = html.Replace("{AUTHOR-GSM}", Program.User.WorksAt.Gsm);
                        html = html.Replace("{ORDER-ID}", m_Order.ID.ToString());
                        html = html.Replace("{ATTN-NOTE}", m_Order.Note);


                        string m_Template = "<tr class=\"item\">" +
                                    "<td class=\"pro-img\"><img src=\"{0}\" /></td>" +
                                    "<td class=\"pro-code\">{1}</td>" +
                                    "<td class=\"pro-name\">{2}</td>" +
                                    "<td class=\"pro-quantity\">{3}</td>" +
                                    "<td class=\"pro-desc\">{4}</td>" +
                                "</tr>";

                        string m_Data = "";

                        m_Order.Nodes.All(delegate (OrderNode node)
                        {
                            string m_ProImgPath = Path.Combine(m_LocalPath, node.Item.LocalImagePath);

                            m_Data += string.Format(m_Template, File.Exists(m_ProImgPath) ? m_ProImgPath : "", string.IsNullOrEmpty(node.Item.OrderCode) ? "Yok" : node.Item.OrderCode, node.Item.Product.Name, GetFormattedAmount(node.Amount, node.Item.UnitType.DecimalPlaces, node.Item.UnitType.Name), node.Description);

                            return true;
                        });

                        html = html.Replace("{DATA}", m_Data);

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
                        catch(Exception ex)
                        {
                            Logger.Enqueue(ex);
                            MessageBox.Show("Oluşan bir hata nedeniyle pdf dosyası yazılamadı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            this.Export_Pdf_Button.Enabled = true;
        }

        private string GetFormattedAmount(decimal amount, int decimalPlaces, string abbreviation)
        {
            string m_Amount = "";

            try
            {
                if (decimalPlaces == 0)
                {
                    if (amount == 0.0000M)
                        m_Amount = string.Format("0 {0}", abbreviation);
                    else
                        m_Amount = string.Format("{0} {1}", amount.ToString("#"), abbreviation);
                }

                else
                {
                    string m_Format = "#." + "".PadRight(decimalPlaces, '#');
                    m_Amount = amount.ToString(m_Format) + " " + abbreviation;
                }
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }

            return m_Amount;
        }
    }
}
