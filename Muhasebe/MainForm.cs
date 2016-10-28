using System;
using Muhasebe.Properties;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Muhasebe.Events;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using RawInputInterface;
using Muhasebe.Scripts;
using IO = System.IO;
using OpenHtmlToPdf;

namespace Muhasebe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetLastFormState()
        {
            if (Settings.Default.WindowState == 0)
            {
                this.Width = Settings.Default.Width;
                this.Height = Settings.Default.Height;
                this.Location = Settings.Default.Location;
            }
            else if (Settings.Default.WindowState == 1)
                this.WindowState = FormWindowState.Minimized;
            else if (Settings.Default.WindowState == 2)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Grid_Panel.Hide();

            SetLastFormState();

            BarcodeListener.Initialize(this.Handle);

            this.Menu_Strip.Enabled = false;
            this.Navigation_Strip.Enabled = false;

            EventSink.Error += EventSink_Error;
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;
            EventSink.UserLogon += EventSink_UserLogon;
            Application.ApplicationExit += Application_ApplicationExit;

            Login_Mdi m_Mdi = new Login_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.Show();

            if (Program.AutoLoginEnabled)
            {
                m_Mdi.AcceptButton.PerformClick();
            }
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            DeviceManager.DisconnectAll();
            this.Notify_Icon.Dispose();

            Settings.Default.Width = this.Width;
            Settings.Default.Height = this.Height;
            Settings.Default.WindowState = (int)this.WindowState;
            Settings.Default.Location = this.Location;
            Settings.Default.Save();

            if (Program.User != null)
            {
                Event m_Event = new Event();
                m_Event.AuthorID = Program.User.ID;
                m_Event.CategoryID = 6; // oturum
                m_Event.CreatedAt = DateTime.Now;
                m_Event.Description = "Kullanıcı oturumu sonlandırdı.";

                MuhasebeEntities m_Context = new MuhasebeEntities();
                m_Context.Events.Add(m_Event);
                m_Context.SaveChangesAsync();
            }
        }

        void EventSink_UserLogon(object sender, UserLogonEventArgs args)
        {
            if (args.User != null)
            {
                this.Menu_Strip.Enabled = true;
                this.Navigation_Strip.Enabled = true;
                this.Process_Label.Text = string.Format("Hareket: {0} giriş yaptı.", args.User.Email);

                Program.User = args.User;
                ShowBackgroundLogo();

                DeviceManager.Initialize();

                if (GuiManipulator.CanShowStatistics)
                {
                    this.Grid_Panel.Visible = true;
                }

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Event m_Event = new Event();
                    m_Event.AuthorID = args.User.ID;
                    m_Event.CategoryID = 6; // oturum
                    m_Event.CreatedAt = DateTime.Now;
                    m_Event.Description = "Kullanıcı oturum açtı.";

                    m_Context.Events.Add(m_Event);
                    m_Context.SaveChangesAsync();
                }
            }
            else
            {
                this.Process_Label.Text = "Hata: Beklenmedik giriş denemesi.";
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
                        if (!this.MdiChildren.Any(q => q is Manage_Sales_Mdi))
                        {
                            this.BeginInvoke((MethodInvoker)(delegate ()
                            {
                                Manage_Sales_Mdi m_Mdi = new Manage_Sales_Mdi();
                                m_Mdi.MdiParent = this;
                                m_Mdi.WindowState = FormWindowState.Maximized;
                                m_Mdi.Show();

                                m_Mdi.Shown += (s, a) =>
                                {
                                    InvoiceNode m_Node = new InvoiceNode(m_Item);
                                    m_Node.Amount = 1;
                                    m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;
                                    m_Mdi.Append(m_Node);
                                };

                            }));
                        }
                        else
                        {
                            Form m_Existing = this.MdiChildren.Where(q => q is Manage_Sales_Mdi).FirstOrDefault();

                            if (m_Existing != null)
                            {
                                Manage_Sales_Mdi m_Mdi = m_Existing as Manage_Sales_Mdi;
                                m_Mdi.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    InvoiceNode m_Node = new InvoiceNode(m_Item);
                                    m_Node.Amount = 1;
                                    m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;
                                    m_Mdi.Append(m_Node);
                                });
                            }
                        }
                    }
                }
            }
        }

        private void EventSink_Error(object sender, ErrorEventArgs args)
        {
            this.Process_Label.Text = string.Format("Hata: {0}", args.Exception.Message);
        }

        private void aygıtYöneticisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Devices_Mdi m_Mdi = new Manage_Devices_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.Show();
        }

        private void Inventory_Button_Click(object sender, EventArgs e)
        {
            Manage_Items_Mdi m_Mdi = new Manage_Items_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void ölçüBirimleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_UnitTypes_Mdi m_Mdi = new Manage_UnitTypes_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeutralizeView();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            /*   if (this.WindowState == FormWindowState.Minimized)
               {
                   this.ShowInTaskbar = false;
                   this.Hide();
               }
               else
               {
                   this.ShowInTaskbar = true;
               }*/
        }

        private void Notify_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NeutralizeView();
        }

        private void NeutralizeView()
        {
            this.Show();

            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            this.BringToFront();
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null && GuiManipulator.CanShowStatistics)
            {
                this.Grid_Panel.Visible = true;
            }
            else
            {
                this.Grid_Panel.Visible = false;
            }
        }

        private void Home_Button_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                if (GuiManipulator.CanShowStatistics)
                {
                    this.Grid_Panel.Visible = true;
                }

                this.MdiChildren.All(delegate (Form m_Form)
                {
                    m_Form.Close();
                    return true;
                });
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_Mdi m_Mdi = new About_Mdi();
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.MdiParent = this;
            m_Mdi.Show();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Sales_Button_Click(object sender, EventArgs e)
        {
            Manage_Sales_Mdi m_Mdi = new Manage_Sales_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void ödemeSeçenekleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_PaymentType_Mdi m_Mdi = new Manage_PaymentType_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void CalculateMetrics()
        {
            try
            {
                this.Downward_List.BeginUpdate();

                this.Downward_List.Items.Clear();
                this.Username_Label.Text = string.Format("{0}: {1} {2}", Program.User.Position != null ? Program.User.Position.Name : "Kullanıcı", Program.User.Name, Program.User.Surname);
                this.Company_Label.Text = string.Format("{0} / {1}", Program.User.WorksAt.Name, Program.User.WorksAt.Sector.ToString());

                MuhasebeEntities m_Context = new MuhasebeEntities();

                var m_Downwards = m_Context.PropertyReminders.Where(q => q.OwnerID == Program.User.WorksAtID && q.Item.Amount <= q.Minimum).ToList();

                m_Downwards.All(delegate (PropertyReminder m_Reminder)
                {
                    ListViewItem m_ViewItem = new ListViewItem();
                    m_ViewItem.Text = m_Reminder.Item.Product.Name;

                    string m_Amount = m_Reminder.Item.GetFormattedAmount();

                    m_ViewItem.SubItems.Add(string.Format("Kalan: {0}", m_Amount));
                    m_ViewItem.StateImageIndex = 0;
                    this.Downward_List.Items.Add(m_ViewItem);
                    return true;
                });

                this.Downward_List.EndUpdate();

                decimal m_Net = 0;
                decimal m_Cost = 0;
                decimal m_Total = 0;
                decimal m_Tax = 0;
                decimal m_Expenditure = 0;
                decimal m_Revenue = 0;

                DateTime m_Now = DateTime.Now;
                DateTime m_Begin = new DateTime(m_Now.Year, m_Now.Month, m_Now.Day, 0, 0, 0);
                var m_Invoices = m_Context.Invoices.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Begin).ToList();

                m_Invoices.All(delegate (Invoice m_Invoice)
                {
                    m_Net += m_Invoice.Nodes.Sum(q => q.FinalPrice - q.BasePrice).Value;
                    m_Cost += m_Invoice.Nodes.Sum(q => q.BasePrice).Value;
                    m_Total += m_Invoice.Nodes.Sum(q => q.FinalPrice).Value;
                    m_Tax += m_Invoice.Nodes.Sum(q => (q.FinalPrice / 100) * q.Tax).Value;

                    return true;
                });

                m_Revenue += m_Net;

                var m_IncomeMoves = m_Context.Incomes.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Begin && (q.InvoiceID == null || q.InvoiceID == 0));
                if (m_IncomeMoves.Count() > 0)
                    m_Revenue += m_IncomeMoves.Sum(q => q.Amount).Value;

                var m_ExpendMoves = m_Context.Expenditures.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Begin);
                if (m_ExpendMoves.Count() > 0)
                    m_Expenditure += m_ExpendMoves.Sum(q => q.Amount).Value;

                this.Net_Label.Text = string.Format("{0:0.00} TL", m_Net);
                this.Cost_Label.Text = string.Format("{0:0.00} TL", m_Cost);
                this.Total_Label.Text = string.Format("{0:0.00} TL", m_Total);
                this.Tax_Label.Text = string.Format("{0:0.00} TL", m_Tax);
                this.Expenditure_Label.Text = string.Format("{0:0.00} TL", m_Expenditure);
                this.Revenue_Label.Text = string.Format("{0:0.00} TL", m_Revenue);

                DateTime m_Monthly = m_Begin.Subtract(TimeSpan.FromDays(30.0));

                ///MySQL TruncateDate Bug
                var m_RevData = m_Context.Incomes.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Monthly).
                    GroupBy(q => new { Year = q.CreatedAt.Value.Year, Month = q.CreatedAt.Value.Month, Day = q.CreatedAt.Value.Day }).
                    Select(q => new
                    {
                        Amount = q.Sum(x => x.Amount),
                        CreatedAt = q.FirstOrDefault().CreatedAt
                    }).OrderBy(q => q.CreatedAt).ToList();

                var m_ExpData = m_Context.Expenditures.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Monthly).
                    GroupBy(q => new { Year = q.CreatedAt.Value.Year, Month = q.CreatedAt.Value.Month, Day = q.CreatedAt.Value.Day }).
                    Select(q => new
                    {
                        Amount = q.Sum(x => x.Amount),
                        CreatedAt = q.FirstOrDefault().CreatedAt
                    }).OrderBy(q => q.CreatedAt).ToList();

                Series m_Revenues = new Series();
                m_Revenues.Name = "Gelirler";

                Series m_Expenditures = new Series();
                m_Expenditures.Name = "Giderler";

                double i = 0;
                decimal m_TotalMonthlyRevenue = 0.0000m;
                decimal m_TotalMonthlyExpenditure = 0.0000m;

                m_RevData.All(q =>
                {
                    DateTime m_DateKey = new DateTime(q.CreatedAt.Value.Year, q.CreatedAt.Value.Month, q.CreatedAt.Value.Day);
                    DataPoint m_Point = new DataPoint(m_DateKey.ToOADate(), Convert.ToDouble(q.Amount));
                    m_Point.AxisLabel = q.CreatedAt.Value.ToShortDateString();
                    m_Point.LabelAngle = -90;
                    m_Point.LabelFormat = "0.## TL";
                    m_Revenues.Points.Add(m_Point);

                    m_TotalMonthlyRevenue += q.Amount.Value;

                    i++;
                    return true;
                });

                i = 0;
                m_ExpData.All(q =>
                {
                    DateTime m_DateKey = new DateTime(q.CreatedAt.Value.Year, q.CreatedAt.Value.Month, q.CreatedAt.Value.Day);
                    DataPoint m_Point = new DataPoint(m_DateKey.ToOADate(), Convert.ToDouble(q.Amount));
                    m_Point.AxisLabel = q.CreatedAt.Value.ToShortDateString();
                    m_Point.LabelAngle = -90;
                    m_Point.LabelFormat = "0.## TL";
                    m_Expenditures.Points.Add(m_Point);

                    m_TotalMonthlyExpenditure += q.Amount.Value;

                    i++;
                    return true;
                });

                m_Revenues.IsValueShownAsLabel = true;
                m_Revenues.SmartLabelStyle.Enabled = false;
                m_Expenditures.IsValueShownAsLabel = true;
                m_Expenditures.SmartLabelStyle.Enabled = false;

                this.chart1.Series.Clear();
                this.chart1.Series.Add(m_Revenues);
                this.chart1.Series.Add(m_Expenditures);

                this.chart1.Titles[0].Text = string.Format("Gelir: {0:0.00} TL", m_TotalMonthlyRevenue);
                this.chart1.Titles[1].Text = string.Format("Gider: {0:0.00} TL", m_TotalMonthlyExpenditure);


                var m_MostSoldData = m_Context.InvoiceNodes.Where(q => q.Invoice.OwnerID == Program.User.WorksAtID).GroupBy(q => q.ItemID).Select(q => new
                {
                    Amount = q.Sum(x => x.Amount),
                    Item = q.FirstOrDefault().Item
                }).OrderByDescending(q => q.Amount).Take(8).ToList();

                var m_MostProfitableData = m_Context.InvoiceNodes.Where(q => q.Invoice.OwnerID == Program.User.WorksAtID).GroupBy(q => q.ItemID).Select(q => new
                {
                    Percent = q.Sum(x => (x.FinalPrice - x.BasePrice) * x.Amount) / q.Count(),
                    Item = q.FirstOrDefault().Item
                }).OrderByDescending(q => q.Percent).Take(8).ToList();

                i = 0;
                this.chart2.Series.Clear();
                this.chart3.Series.Clear();

                Series m_MostSoldSerie = new Series();
                m_MostSoldSerie.ChartType = SeriesChartType.Doughnut;
                m_MostSoldSerie["PieLabelStyle"] = "Outside";
                m_MostSoldSerie["PieLineColor"] = "Black";

                m_MostSoldData.All(q =>
                {
                    DataPoint m_Point = new DataPoint(i, (double)q.Amount.Value);
                    m_Point.Label = q.Item.Product.Name;
                    m_MostSoldSerie.Points.Add(m_Point);

                    i++;
                    return true;
                });

                this.chart2.Series.Add(m_MostSoldSerie);

                i = 0;

                Series m_MostProfitableSerie = new Series();
                m_MostProfitableSerie.ChartType = SeriesChartType.StackedColumn;
                m_MostProfitableSerie.SmartLabelStyle.Enabled = false;
                chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart3.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
                chart3.ChartAreas[0].Area3DStyle.IsClustered = true;

                m_MostProfitableData.All(q =>
                {
                    DataPoint m_Point = new DataPoint(i, (double)q.Percent.Value);
                    m_Point.AxisLabel = q.Item.Product.Name;
                    m_Point.LabelAngle = -90;
                    m_MostProfitableSerie.Points.Add(m_Point);


                    i++;

                    return true;
                });

                this.chart3.Series.Add(m_MostProfitableSerie);
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }
        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Users_Mdi m_Mdi = new Manage_Users_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void Events_Button_Click(object sender, EventArgs e)
        {
            Manage_Events_Mdi m_Mdi = new Manage_Events_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void gelirYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Revenue_Mdi m_Mdi = new Manage_Revenue_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void giderYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Expenditure_Mdi m_Mdi = new Manage_Expenditure_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void Grid_Panel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Grid_Panel.Visible == true)
            {
                ThreadStart m_Starter = new ThreadStart(CalculateMetrics);
                Thread m_Thread = new Thread(m_Starter);
                m_Thread.IsBackground = true;
                m_Thread.Start();
            }
        }

        private void azalanÜrünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Reminder_Mdi m_Mdi = new Manage_Reminder_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void istatistiklerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            /* Manage_Statistics_Mdi m_Mdi = new Manage_Statistics_Mdi();
             m_Mdi.MdiParent = this;
             m_Mdi.WindowState = FormWindowState.Maximized;
             m_Mdi.Show();*/
        }

        private void Storge_Control_Click(object sender, EventArgs e)
        {
            Manage_Inventory_Mdi m_Mdi = new Manage_Inventory_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void Item_Control_Click(object sender, EventArgs e)
        {
            Manage_Items_Mdi m_Mdi = new Manage_Items_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void Accounts_Button_Click(object sender, EventArgs e)
        {
            Manage_Accounts_Mdi m_Mdi = new Manage_Accounts_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void seçeneklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options_Mdi m_Mdi = new Options_Mdi();
            m_Mdi.ShowDialog();
        }

        private void barkodTasarımYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_BarcodeTemplates_Mdi m_Mdi = new Manage_BarcodeTemplates_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void ürünGruplarıYönetimiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manage_ItemGroups_Mdi m_Mdi = new Manage_ItemGroups_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void ürünGruplarıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_ItemGroups_Mdi m_Mdi = new Manage_ItemGroups_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.WindowState = FormWindowState.Maximized;
            m_Mdi.Show();
        }

        private void ShowBackgroundLogo()
        {
            this.BackgroundImageLayout = ImageLayout.Center;

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    string m_FilePath = Program.User.WorksAt.BackgroundLogo;

                    if (m_FilePath != string.Empty && IO.File.Exists(m_FilePath))
                    {
                        ctl.BackgroundImageLayout = ImageLayout.Center;
                        ctl.BackgroundImage = Image.FromFile(m_FilePath);
                    }

                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = "";
            string m_LocalPath = Application.StartupPath;
            string m_IndexPath = IO.Path.Combine(m_LocalPath, "View\\OrderForm\\index.html");
            string m_AbsPath = IO.Path.Combine(m_LocalPath, "View\\OrderForm\\");

            using(IO.StreamReader m_Reader = new IO.StreamReader(m_IndexPath, Encoding.UTF8, true))
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

            var pdf = Pdf
                .From(html)
                .OfSize(PaperSize.A4)
                .WithTitle("Title")
                .WithMargins(0.8.Centimeters())
                .WithoutOutline()
                .Portrait()
                .Comressed()
                .Content();

            IO.FileStream m_Stream = new IO.FileStream(string.Format("C:\\test-{0}.pdf", IO.Path.GetRandomFileName()), IO.FileMode.Create);

            using (IO.BinaryWriter m_Writer = new IO.BinaryWriter(m_Stream))
            {
                m_Writer.Write(pdf, 0, pdf.Length);
            }

            m_Stream.Close();
            m_Stream.Dispose();
        }
    }
}
