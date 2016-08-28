using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Edit_Item_Pop : Form
    {
        public delegate void OnItemEdited(Item Item);
        public event OnItemEdited ItemEdited;
        public Item Item { get; set; }
        private bool m_Running = false;

        internal Camera Camera;

        const int VIDEODEVICE = 0; // zero based index of video capture device to use
        const int VIDEOWIDTH = 640; // Depends on video device caps
        const int VIDEOHEIGHT = 480; // Depends on video device caps
        const short VIDEOBITSPERPIXEL = 32; // BitsPerPixel values determined by device

        public Edit_Item_Pop()
        {
            InitializeComponent();
        }

        ~Edit_Item_Pop()
        {
            if (this.Camera != null)
                this.Camera.Dispose();
        }

        private IntPtr m_Handle = IntPtr.Zero;

        private void Webcam_Button_Click(object sender, EventArgs e)
        {
            if (m_Running == false)
            {
                this.Remove_Cam_Button.Visible = false;
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
                this.Remove_Cam_Button.Visible = true;

                Cursor.Current = Cursors.Default;

                m_Running = false;
            }
        }

        private void Edit_Item_Pop_Load(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            var m_Inventories = m_Context.Inventories.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

            this.Inventory_Combo.DataSource = m_Inventories;
            this.Inventory_Combo.ValueMember = "ID";
            this.Inventory_Combo.DisplayMember = "Name";

            var m_UnitTypes = m_Context.UnitTypes.Where(q => q.OwnerID == Program.User.WorksAtID || q.OwnerID == null).ToList();

            this.Unit_Type_Combo.DataSource = m_UnitTypes;
            this.Unit_Type_Combo.ValueMember = "ID";
            this.Unit_Type_Combo.DisplayMember = "Name";

            var m_ItemGroups = m_Context.ItemGroups.ToList();
            this.Group_Combo.DataSource = m_ItemGroups;
            this.Group_Combo.ValueMember = "ID";
            this.Group_Combo.DisplayMember = "Name";

            this.Barcode_Box.Text = this.Item.Product.Barcode.ToString();
            this.Name_Box.Text = this.Item.Product.Name.ToString();
            this.Inventory_Combo.SelectedValue = this.Item.Inventory.ID;
            this.Unit_Type_Combo.SelectedValue = this.Item.UnitType.ID;
            this.Amount_Num.Value = this.Item.Amount;
            this.Base_Price_Num.Value = this.Item.BasePrice.Value;
            this.Tax_Num.Value = this.Item.Tax.Value;
            this.Final_Price_Num.Value = this.Item.FinalPrice.Value;

            if (this.Item.GroupID != null)
                this.Group_Combo.SelectedValue = this.Item.GroupID;

            if (this.Item.LocalImagePath.Length > 0 && File.Exists(this.Item.LocalImagePath))
                this.Picture_Box.ImageLocation = this.Item.LocalImagePath;
            else if (this.Item.Product.PublicImagePath.Length > 0)
                this.Picture_Box.ImageLocation = this.Item.Product.PublicImagePath;
        }

        private void InvokeItemEdited(Item item)
        {
            if (ItemEdited != null)
                ItemEdited(item);
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

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Item != null)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                Item m_Actual = m_Context.Items.Where(q => q.ID == this.Item.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.InventoryID = Convert.ToInt32(this.Inventory_Combo.SelectedValue);
                    m_Actual.UnitTypeID = Convert.ToInt32(this.Unit_Type_Combo.SelectedValue);
                    m_Actual.Amount = this.Amount_Num.Value;
                    m_Actual.BasePrice = this.Base_Price_Num.Value;
                    m_Actual.Tax = Convert.ToInt32(this.Tax_Num.Value);
                    m_Actual.FinalPrice = this.Final_Price_Num.Value;
                    m_Actual.Product.Name = this.Name_Box.Text;
                    m_Actual.GroupID = Convert.ToInt32(this.Group_Combo.SelectedValue);

                    if (this.Picture_Box.ImageLocation.Length > 0 && this.Picture_Box.ImageLocation != this.Item.LocalImagePath)
                    {
                        if (File.Exists(this.Picture_Box.ImageLocation))
                        {
                            Image m_Image = Image.FromFile(this.Picture_Box.ImageLocation);
                            m_Actual.SynchronizeImage(m_Image);
                        }
                    }
                    /*else if (this.Picture_Box.Image != null)
                    {
                        Image m_Image = this.Picture_Box.Image;
                        m_Actual.SynchronizeImage(m_Image);
                    }*/

                    m_Context.SaveChanges();
                    InvokeItemEdited(m_Actual);

                    this.Close();

                }
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Item_Pop_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Camera != null)
                this.Camera.Dispose();
        }

        private void Remove_Cam_Button_Click(object sender, EventArgs e)
        {
            if (this.Camera != null)
                this.Camera.Dispose();

            this.Remove_Cam_Button.Visible = false;
            this.Camera_Box.Visible = false;

            if (this.Item != null)
            {
                if (this.Item.LocalImagePath.Length > 0 && File.Exists(this.Item.LocalImagePath))
                    this.Picture_Box.ImageLocation = this.Item.LocalImagePath;

                else if (this.Item.Product.PublicImagePath.Length > 0)
                    this.Picture_Box.ImageLocation = this.Item.Product.PublicImagePath;

                else
                    this.Picture_Box.Image = Properties.Resources.items;


            }
            else
                this.Picture_Box.Image = Properties.Resources.items;

            m_Running = false;
        }

        private void Print_Barcode_Button_Click(object sender, EventArgs e)
        {
            if (this.Barcode_Box.Text != string.Empty)
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
                MessageBox.Show("Ürün için bir barkod belirleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Barcode_Box_TextChanged(object sender, EventArgs e)
        {
            if (this.Barcode_Box.Text.Length != 8)
                this.Print_Barcode_Button.Enabled = false;
            else
                this.Print_Barcode_Button.Enabled = true;
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            if (this.Browse_Dialog.ShowDialog() == DialogResult.OK)
            {
                this.Picture_Box.ImageLocation = this.Browse_Dialog.FileName;
                this.Picture_Box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
