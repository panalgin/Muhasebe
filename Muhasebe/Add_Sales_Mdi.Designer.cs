namespace Muhasebe
{
    partial class Add_Sales_Mdi
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UseCustumPricing_Check = new System.Windows.Forms.CheckBox();
            this.TotalPrice_Num = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.Abbreviation_Label = new System.Windows.Forms.Label();
            this.Barcode_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.PerPrice_Num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Sale_Button = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPrice_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerPrice_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.UseCustumPricing_Check);
            this.groupBox2.Controls.Add(this.TotalPrice_Num);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Abbreviation_Label);
            this.groupBox2.Controls.Add(this.Barcode_Box);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Name_Box);
            this.groupBox2.Controls.Add(this.PerPrice_Num);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Amount_Num);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 177);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürün Bilgileri";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Özel Fiyat Uygula:";
            // 
            // UseCustumPricing_Check
            // 
            this.UseCustumPricing_Check.AutoSize = true;
            this.UseCustumPricing_Check.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UseCustumPricing_Check.Location = new System.Drawing.Point(117, 97);
            this.UseCustumPricing_Check.Name = "UseCustumPricing_Check";
            this.UseCustumPricing_Check.Size = new System.Drawing.Size(15, 14);
            this.UseCustumPricing_Check.TabIndex = 3;
            this.UseCustumPricing_Check.UseVisualStyleBackColor = true;
            this.UseCustumPricing_Check.CheckedChanged += new System.EventHandler(this.UseCustumPricing_Check_CheckedChanged);
            // 
            // TotalPrice_Num
            // 
            this.TotalPrice_Num.DecimalPlaces = 2;
            this.TotalPrice_Num.Location = new System.Drawing.Point(117, 143);
            this.TotalPrice_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TotalPrice_Num.Name = "TotalPrice_Num";
            this.TotalPrice_Num.ReadOnly = true;
            this.TotalPrice_Num.Size = new System.Drawing.Size(139, 20);
            this.TotalPrice_Num.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Satış Fiyatı [Toplam]:";
            // 
            // Abbreviation_Label
            // 
            this.Abbreviation_Label.BackColor = System.Drawing.SystemColors.Window;
            this.Abbreviation_Label.Location = new System.Drawing.Point(189, 75);
            this.Abbreviation_Label.Name = "Abbreviation_Label";
            this.Abbreviation_Label.Size = new System.Drawing.Size(47, 13);
            this.Abbreviation_Label.TabIndex = 15;
            this.Abbreviation_Label.Text = "birim";
            this.Abbreviation_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Barcode_Box
            // 
            this.Barcode_Box.Location = new System.Drawing.Point(117, 19);
            this.Barcode_Box.Name = "Barcode_Box";
            this.Barcode_Box.Size = new System.Drawing.Size(139, 20);
            this.Barcode_Box.TabIndex = 0;
            this.Barcode_Box.TextChanged += new System.EventHandler(this.Barcode_Box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Adı:";
            // 
            // Name_Box
            // 
            this.Name_Box.Location = new System.Drawing.Point(117, 45);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(139, 20);
            this.Name_Box.TabIndex = 1;
            // 
            // PerPrice_Num
            // 
            this.PerPrice_Num.DecimalPlaces = 2;
            this.PerPrice_Num.Location = new System.Drawing.Point(117, 117);
            this.PerPrice_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PerPrice_Num.Name = "PerPrice_Num";
            this.PerPrice_Num.ReadOnly = true;
            this.PerPrice_Num.Size = new System.Drawing.Size(139, 20);
            this.PerPrice_Num.TabIndex = 4;
            this.PerPrice_Num.ValueChanged += new System.EventHandler(this.PerPrice_Num_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Miktar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Satış Fiyatı [Birim]:";
            // 
            // Amount_Num
            // 
            this.Amount_Num.Location = new System.Drawing.Point(117, 71);
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
            this.Amount_Num.Size = new System.Drawing.Size(139, 20);
            this.Amount_Num.TabIndex = 2;
            this.Amount_Num.ValueChanged += new System.EventHandler(this.Amount_Num_ValueChanged);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_button.Location = new System.Drawing.Point(192, 211);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(82, 23);
            this.Cancel_button.TabIndex = 2;
            this.Cancel_button.Text = "Vazgeç";
            this.Cancel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sale_Button
            // 
            this.Sale_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Sale_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sale_Button.Location = new System.Drawing.Point(97, 211);
            this.Sale_Button.Name = "Sale_Button";
            this.Sale_Button.Size = new System.Drawing.Size(89, 23);
            this.Sale_Button.TabIndex = 1;
            this.Sale_Button.Text = "Satış";
            this.Sale_Button.UseVisualStyleBackColor = true;
            this.Sale_Button.Click += new System.EventHandler(this.Sale_Button_Click);
            // 
            // Add_Sales_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 246);
            this.Controls.Add(this.Sale_Button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(271, 224);
            this.Name = "Add_Sales_Mdi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manuel Satış";
            this.Load += new System.EventHandler(this.Add_Sales_Mdi_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPrice_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerPrice_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Abbreviation_Label;
        private System.Windows.Forms.TextBox Barcode_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.NumericUpDown PerPrice_Num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Amount_Num;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Sale_Button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox UseCustumPricing_Check;
        private System.Windows.Forms.NumericUpDown TotalPrice_Num;
        private System.Windows.Forms.Label label4;
    }
}