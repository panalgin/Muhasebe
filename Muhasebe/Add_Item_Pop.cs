using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing.Imaging;
using Muhasebe.Events;

namespace Muhasebe
{
    public partial class Add_Item_Pop : Form
    {
        public delegate void OnItemAdded(Item item);
        public event OnItemAdded ItemAdded;

        private bool m_Running = false;

        const int VIDEODEVICE = 0; // zero based index of video capture device to use
        const int VIDEOWIDTH = 640; // Depends on video device caps
        const int VIDEOHEIGHT = 480; // Depends on video device caps
        const short VIDEOBITSPERPIXEL = 32; // BitsPerPixel values determined by device

        internal Camera Camera;

        public Add_Item_Pop(string barcode)
        {
            InitializeComponent();
            this.Barcode_Box.Text = barcode;
        }

        public Add_Item_Pop() : this(string.Empty)
        {

        }

        ~Add_Item_Pop()
        {
            if (this.Camera != null)
                this.Camera.Dispose();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            if (this.Browse_Dialog.ShowDialog() == DialogResult.OK)
            {
                this.Picture_Box.ImageLocation = this.Browse_Dialog.FileName;
                this.Picture_Box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();

                Product m_Product = m_Context.Products.Where(q => q.Barcode == this.Barcode_Box.Text).FirstOrDefault();

                if (m_Product == null)
                {
                    m_Product = new Product();
                    m_Product.Name = this.Name_Box.Text;
                    m_Product.Barcode = this.Barcode_Box.Text;

                    m_Context.Products.Add(m_Product);
                    m_Context.SaveChanges();

                    m_Product = m_Context.Products.Where(q => q.Barcode == m_Product.Barcode).FirstOrDefault(); // refreshing
                }

                Item m_Item = new Item();
                m_Item.Amount = this.Amount_Num.Value;
                m_Item.BasePrice = this.Base_Price_Num.Value;
                m_Item.FinalPrice = this.Final_Price_Num.Value;
                m_Item.InventoryID = Convert.ToInt32(this.Inventory_Combo.SelectedValue);
                m_Item.CreatedAt = DateTime.Now;
                m_Item.Tax = Convert.ToInt32(this.Tax_Num.Value);
                m_Item.UnitTypeID = Convert.ToInt32(this.Unit_Type_Combo.SelectedValue);
                m_Item.ProductID = m_Product.ID;

                m_Context.Items.Add(m_Item);
                m_Context.SaveChanges();

                if (this.Picture_Box.Image != null)
                {
                    Image m_Image = this.Picture_Box.Image;
                    m_Item.SynchronizeImage(m_Image);
                }

                InvokeItemAdded(m_Item);
                this.Close();
            }
        }

        private IntPtr m_Handle = IntPtr.Zero;

        private void Webcam_Button_Click(object sender, EventArgs e)
        {
            if (m_Running == false)
            {
                Camera = new Camera(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, this.Camera_Box);
                this.Camera_Box.Visible = true;
                m_Running = true;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                // Release any previous buffer
                if (m_Handle != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(m_Handle);
                    m_Handle = IntPtr.Zero;
                }

                // capture image
                m_Handle = this.Camera.Click();
                Bitmap b = new Bitmap(this.Camera.Width, this.Camera.Height, this.Camera.Stride, PixelFormat.Format24bppRgb, m_Handle);

                this.Camera_Box.Visible = false;
                this.Camera.Dispose();

                // If the image is upsidedown
                b.RotateFlip(RotateFlipType.RotateNoneFlipY);
                this.Picture_Box.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Picture_Box.Image = b;

                Cursor.Current = Cursors.Default;

                m_Running = false;
            }
        }

        private void Add_Item_Pop_Load(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            var m_UnitTypes = m_Context.UnitTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

            this.Unit_Type_Combo.DataSource = m_UnitTypes;
            this.Unit_Type_Combo.ValueMember = "ID";
            this.Unit_Type_Combo.DisplayMember = "Name";

            var m_Inventories = m_Context.Inventories.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();
            this.Inventory_Combo.DataSource = m_Inventories;
            this.Inventory_Combo.ValueMember = "ID";
            this.Inventory_Combo.DisplayMember = "Name";

            EventSink.BarcodeScanned += EventSink_BarcodeScanned;
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            string m_Barcode = args.Barcode;
            this.Barcode_Box.Text = m_Barcode;
        }

        private void Barcode_Box_TextChanged(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();
            string m_Barcode = this.Barcode_Box.Text;

            Product m_Product = m_Context.Products.Where(q => q.Barcode == m_Barcode).FirstOrDefault();

            if (m_Product != null)
            {
                this.Barcode_Box.Text = m_Product.Barcode;
                this.Name_Box.Text = m_Product.Name;

                this.Barcode_Box.ReadOnly = true;
                this.Name_Box.ReadOnly = true;

                if (m_Product.PublicImagePath != null)
                {
                    this.Picture_Box.Image = null;
                    this.Picture_Box.ImageLocation = string.Format("http://www.daflan.com/muhasebe/{0}", m_Product.PublicImagePath);
                    this.Picture_Box.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            if (this.Barcode_Box.Text.Length != 8)
                this.Print_Barcode_Button.Enabled = false;
            else
                this.Print_Barcode_Button.Enabled = true;
        }

        private bool ValidateInput()
        {
            if (this.Barcode_Box.Text.Length < 3)
            {
                this.Error_Provider.SetError(this.Barcode_Box, "Bir barkod değeri girilmelidir.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Barcode_Box, string.Empty);

            if (this.Name_Box.Text.Length < 3)
            {
                this.Error_Provider.SetError(this.Name_Box, "Bir ürün adı girilmelidir.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Name_Box, string.Empty);

            if (this.Inventory_Combo.SelectedValue == null)
            {
                this.Error_Provider.SetError(this.Inventory_Combo, "Bir envanter seçilmelidir.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Inventory_Combo, string.Empty);

            if (this.Unit_Type_Combo.SelectedValue == null)
            {
                this.Error_Provider.SetError(this.Unit_Type_Combo, "Bir ölçü birimi seçilmelidir.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Unit_Type_Combo, string.Empty);

            return true;
        }

        private void Unit_Type_Combo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.Unit_Type_Combo.SelectedValue != null)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                int m_ID = 0;

                if (int.TryParse(this.Unit_Type_Combo.SelectedValue.ToString(), out m_ID))
                {
                    UnitType m_Type = m_Context.UnitTypes.Where(q => q.ID == m_ID).FirstOrDefault();

                    if (m_Type != null)
                        this.Amount_Num.DecimalPlaces = m_Type.DecimalPlaces;

                    this.Abbreviation_Label.Text = m_Type.Abbreviation;
                }
            }
        }

        private void InvokeItemAdded(Item item)
        {
            if (ItemAdded != null)
                ItemAdded(item);
        }

        private void Add_Item_Pop_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Camera != null)
            {
                this.Camera.Dispose();
            }
        }

        private void Print_Barcode_Button_Click(object sender, EventArgs e)
        {
            if (this.Barcode_Box.Text != string.Empty && this.Name_Box.Text != string.Empty)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    BarcodePrinter m_Printer = Program.User.WorksAt.BarcodePrinters.FirstOrDefault();
                    
                    if (m_Printer != null)
                    {
                        m_Printer.Print(this.Name_Box.Text, this.Barcode_Box.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ürün için bir barkod belirleyin ve ürün adını girdiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Generate_Barcode_Button_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Random m_Random = new Random();

                    for (;;)
                    {
                        string m_Barcode = m_Random.Next(10000000, 99999999).ToString();
                        if (m_Context.Products.Where(q => q.Barcode == m_Barcode).FirstOrDefault() != null)
                            continue;
                        else
                        {
                            this.Barcode_Box.Text = m_Barcode;

                            break;
                        }
                    }
                }
            }));
        }
    }
}
