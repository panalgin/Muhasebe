namespace Muhasebe
{
    partial class Add_Item_Pop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Item_Pop));
            this.label1 = new System.Windows.Forms.Label();
            this.Barcode_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Inventory_Combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Unit_Type_Combo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.Base_Price_Num = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Tax_Num = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.Final_Price_Num = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Camera_Box = new System.Windows.Forms.PictureBox();
            this.Browse_Button = new System.Windows.Forms.Button();
            this.Webcam_Button = new System.Windows.Forms.Button();
            this.Picture_Box = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Group_Combo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Generate_Barcode_Button = new System.Windows.Forms.Button();
            this.Abbreviation_Label = new System.Windows.Forms.Label();
            this.Browse_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.Error_Provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Save_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Print_Barcode_Button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Termed_Price_Num = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Base_Price_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Final_Price_Num)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Camera_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Box)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Termed_Price_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod:";
            // 
            // Barcode_Box
            // 
            this.Error_Provider.SetIconPadding(this.Barcode_Box, -20);
            this.Barcode_Box.Location = new System.Drawing.Point(113, 19);
            this.Barcode_Box.Name = "Barcode_Box";
            this.Barcode_Box.Size = new System.Drawing.Size(124, 20);
            this.Barcode_Box.TabIndex = 0;
            this.Barcode_Box.TextChanged += new System.EventHandler(this.Barcode_Box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Adı:";
            // 
            // Name_Box
            // 
            this.Error_Provider.SetIconPadding(this.Name_Box, -20);
            this.Name_Box.Location = new System.Drawing.Point(113, 45);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(159, 20);
            this.Name_Box.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Envanter:";
            // 
            // Inventory_Combo
            // 
            this.Inventory_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Error_Provider.SetIconPadding(this.Inventory_Combo, -35);
            this.Inventory_Combo.Location = new System.Drawing.Point(113, 71);
            this.Inventory_Combo.Name = "Inventory_Combo";
            this.Inventory_Combo.Size = new System.Drawing.Size(159, 21);
            this.Inventory_Combo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Birim:";
            // 
            // Unit_Type_Combo
            // 
            this.Unit_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Unit_Type_Combo.FormattingEnabled = true;
            this.Error_Provider.SetIconPadding(this.Unit_Type_Combo, -35);
            this.Unit_Type_Combo.Location = new System.Drawing.Point(113, 125);
            this.Unit_Type_Combo.Name = "Unit_Type_Combo";
            this.Unit_Type_Combo.Size = new System.Drawing.Size(159, 21);
            this.Unit_Type_Combo.TabIndex = 5;
            this.Unit_Type_Combo.SelectedValueChanged += new System.EventHandler(this.Unit_Type_Combo_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Miktar:";
            // 
            // Amount_Num
            // 
            this.Error_Provider.SetIconPadding(this.Amount_Num, -35);
            this.Amount_Num.Location = new System.Drawing.Point(113, 152);
            this.Amount_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Amount_Num.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.Amount_Num.Name = "Amount_Num";
            this.Amount_Num.Size = new System.Drawing.Size(159, 20);
            this.Amount_Num.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Alış Fiyatı:";
            // 
            // Base_Price_Num
            // 
            this.Base_Price_Num.DecimalPlaces = 2;
            this.Error_Provider.SetIconPadding(this.Base_Price_Num, -35);
            this.Base_Price_Num.Location = new System.Drawing.Point(113, 178);
            this.Base_Price_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Base_Price_Num.Name = "Base_Price_Num";
            this.Base_Price_Num.Size = new System.Drawing.Size(159, 20);
            this.Base_Price_Num.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Kdv Oranı:";
            // 
            // Tax_Num
            // 
            this.Error_Provider.SetIconPadding(this.Tax_Num, -35);
            this.Tax_Num.Location = new System.Drawing.Point(113, 204);
            this.Tax_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Tax_Num.Name = "Tax_Num";
            this.Tax_Num.Size = new System.Drawing.Size(159, 20);
            this.Tax_Num.TabIndex = 8;
            this.Tax_Num.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Satış Fiyatı:";
            // 
            // Final_Price_Num
            // 
            this.Final_Price_Num.DecimalPlaces = 2;
            this.Error_Provider.SetIconPadding(this.Final_Price_Num, -35);
            this.Final_Price_Num.Location = new System.Drawing.Point(113, 230);
            this.Final_Price_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Final_Price_Num.Name = "Final_Price_Num";
            this.Final_Price_Num.Size = new System.Drawing.Size(159, 20);
            this.Final_Price_Num.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Camera_Box);
            this.groupBox1.Controls.Add(this.Browse_Button);
            this.groupBox1.Controls.Add(this.Webcam_Button);
            this.groupBox1.Controls.Add(this.Picture_Box);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 288);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Fotoğrafı";
            // 
            // Camera_Box
            // 
            this.Camera_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Camera_Box.Location = new System.Drawing.Point(6, 19);
            this.Camera_Box.Name = "Camera_Box";
            this.Camera_Box.Size = new System.Drawing.Size(163, 184);
            this.Camera_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Camera_Box.TabIndex = 19;
            this.Camera_Box.TabStop = false;
            this.Camera_Box.Visible = false;
            // 
            // Browse_Button
            // 
            this.Browse_Button.Image = global::Muhasebe.Properties.Resources.magnifier;
            this.Browse_Button.Location = new System.Drawing.Point(113, 209);
            this.Browse_Button.Name = "Browse_Button";
            this.Browse_Button.Size = new System.Drawing.Size(25, 25);
            this.Browse_Button.TabIndex = 0;
            this.Browse_Button.UseVisualStyleBackColor = true;
            this.Browse_Button.Click += new System.EventHandler(this.Browse_Button_Click);
            // 
            // Webcam_Button
            // 
            this.Webcam_Button.Image = global::Muhasebe.Properties.Resources.webcam;
            this.Webcam_Button.Location = new System.Drawing.Point(144, 209);
            this.Webcam_Button.Name = "Webcam_Button";
            this.Webcam_Button.Size = new System.Drawing.Size(25, 25);
            this.Webcam_Button.TabIndex = 1;
            this.Webcam_Button.UseVisualStyleBackColor = true;
            this.Webcam_Button.Click += new System.EventHandler(this.Webcam_Button_Click);
            // 
            // Picture_Box
            // 
            this.Picture_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Picture_Box.Image = global::Muhasebe.Properties.Resources.items;
            this.Picture_Box.Location = new System.Drawing.Point(6, 19);
            this.Picture_Box.Name = "Picture_Box";
            this.Picture_Box.Size = new System.Drawing.Size(163, 184);
            this.Picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Picture_Box.TabIndex = 18;
            this.Picture_Box.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Termed_Price_Num);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Group_Combo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.Generate_Barcode_Button);
            this.groupBox2.Controls.Add(this.Abbreviation_Label);
            this.groupBox2.Controls.Add(this.Barcode_Box);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Unit_Type_Combo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Name_Box);
            this.groupBox2.Controls.Add(this.Base_Price_Num);
            this.groupBox2.Controls.Add(this.Tax_Num);
            this.groupBox2.Controls.Add(this.Final_Price_Num);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Inventory_Combo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Amount_Num);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(193, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 288);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürün Bilgileri";
            // 
            // Group_Combo
            // 
            this.Group_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Group_Combo.FormattingEnabled = true;
            this.Group_Combo.Location = new System.Drawing.Point(113, 98);
            this.Group_Combo.Name = "Group_Combo";
            this.Group_Combo.Size = new System.Drawing.Size(159, 21);
            this.Group_Combo.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Grup:";
            // 
            // Generate_Barcode_Button
            // 
            this.Generate_Barcode_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generate_Barcode_Button.Image = global::Muhasebe.Properties.Resources._195_barcode_icon;
            this.Generate_Barcode_Button.Location = new System.Drawing.Point(243, 19);
            this.Generate_Barcode_Button.Name = "Generate_Barcode_Button";
            this.Generate_Barcode_Button.Size = new System.Drawing.Size(29, 20);
            this.Generate_Barcode_Button.TabIndex = 1;
            this.Generate_Barcode_Button.UseVisualStyleBackColor = false;
            this.Generate_Barcode_Button.Click += new System.EventHandler(this.Generate_Barcode_Button_Click);
            // 
            // Abbreviation_Label
            // 
            this.Abbreviation_Label.BackColor = System.Drawing.SystemColors.Window;
            this.Abbreviation_Label.Location = new System.Drawing.Point(205, 156);
            this.Abbreviation_Label.Name = "Abbreviation_Label";
            this.Abbreviation_Label.Size = new System.Drawing.Size(47, 13);
            this.Abbreviation_Label.TabIndex = 15;
            this.Abbreviation_Label.Text = "birim";
            this.Abbreviation_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Browse_Dialog
            // 
            this.Browse_Dialog.Filter = "Resim Dosyaları|*.jpg;*.bmp;*.png";
            // 
            // Error_Provider
            // 
            this.Error_Provider.ContainerControl = this;
            this.Error_Provider.Icon = ((System.Drawing.Icon)(resources.GetObject("Error_Provider.Icon")));
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(267, 330);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(99, 23);
            this.Save_Button.TabIndex = 0;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(372, 330);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(99, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Print_Barcode_Button
            // 
            this.Print_Barcode_Button.Image = global::Muhasebe.Properties.Resources._195_barcode_icon;
            this.Print_Barcode_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Print_Barcode_Button.Location = new System.Drawing.Point(12, 330);
            this.Print_Barcode_Button.Name = "Print_Barcode_Button";
            this.Print_Barcode_Button.Size = new System.Drawing.Size(101, 23);
            this.Print_Barcode_Button.TabIndex = 2;
            this.Print_Barcode_Button.Text = "Barkod Yazdır";
            this.Print_Barcode_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Print_Barcode_Button.UseVisualStyleBackColor = true;
            this.Print_Barcode_Button.Click += new System.EventHandler(this.Print_Barcode_Button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Vadeli Satış Fiyatı:";
            // 
            // Termed_Price_Num
            // 
            this.Termed_Price_Num.DecimalPlaces = 2;
            this.Error_Provider.SetIconPadding(this.Termed_Price_Num, -35);
            this.Termed_Price_Num.Location = new System.Drawing.Point(113, 256);
            this.Termed_Price_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Termed_Price_Num.Name = "Termed_Price_Num";
            this.Termed_Price_Num.Size = new System.Drawing.Size(159, 20);
            this.Termed_Price_Num.TabIndex = 19;
            // 
            // Add_Item_Pop
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(483, 365);
            this.Controls.Add(this.Print_Barcode_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Item_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Add_Item_Pop_FormClosed);
            this.Load += new System.EventHandler(this.Add_Item_Pop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Base_Price_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Final_Price_Num)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Camera_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Box)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Termed_Price_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Barcode_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Inventory_Combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Unit_Type_Combo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Amount_Num;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Base_Price_Num;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Tax_Num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Final_Price_Num;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.PictureBox Picture_Box;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Webcam_Button;
        private System.Windows.Forms.Button Browse_Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog Browse_Dialog;
        private System.Windows.Forms.ErrorProvider Error_Provider;
        private System.Windows.Forms.Label Abbreviation_Label;
        private System.Windows.Forms.PictureBox Camera_Box;
        private System.Windows.Forms.Button Print_Barcode_Button;
        private System.Windows.Forms.Button Generate_Barcode_Button;
        private System.Windows.Forms.ComboBox Group_Combo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown Termed_Price_Num;
        private System.Windows.Forms.Label label10;
    }
}