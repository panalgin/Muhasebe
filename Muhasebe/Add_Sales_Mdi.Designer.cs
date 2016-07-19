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
            this.Abbreviation_Label = new System.Windows.Forms.Label();
            this.Barcode_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.Final_Price_Num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Sale_Button = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Final_Price_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Abbreviation_Label);
            this.groupBox2.Controls.Add(this.Barcode_Box);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Name_Box);
            this.groupBox2.Controls.Add(this.Final_Price_Num);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Amount_Num);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 142);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürün Bilgileri";
            // 
            // Abbreviation_Label
            // 
            this.Abbreviation_Label.BackColor = System.Drawing.SystemColors.Window;
            this.Abbreviation_Label.Location = new System.Drawing.Point(167, 73);
            this.Abbreviation_Label.Name = "Abbreviation_Label";
            this.Abbreviation_Label.Size = new System.Drawing.Size(47, 13);
            this.Abbreviation_Label.TabIndex = 15;
            this.Abbreviation_Label.Text = "birim";
            this.Abbreviation_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Barcode_Box
            // 
            this.Barcode_Box.Location = new System.Drawing.Point(91, 18);
            this.Barcode_Box.Name = "Barcode_Box";
            this.Barcode_Box.Size = new System.Drawing.Size(139, 20);
            this.Barcode_Box.TabIndex = 0;
            this.Barcode_Box.Leave += new System.EventHandler(this.Barcode_Box_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün Adı:";
            // 
            // Name_Box
            // 
            this.Name_Box.Location = new System.Drawing.Point(91, 44);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(139, 20);
            this.Name_Box.TabIndex = 1;
            // 
            // Final_Price_Num
            // 
            this.Final_Price_Num.DecimalPlaces = 2;
            this.Final_Price_Num.Location = new System.Drawing.Point(91, 96);
            this.Final_Price_Num.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Final_Price_Num.Name = "Final_Price_Num";
            this.Final_Price_Num.Size = new System.Drawing.Size(139, 20);
            this.Final_Price_Num.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Miktar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Satış Fiyatı:";
            // 
            // Amount_Num
            // 
            this.Amount_Num.Location = new System.Drawing.Point(91, 70);
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
            this.Amount_Num.TabIndex = 4;
            this.Amount_Num.Leave += new System.EventHandler(this.Amount_Num_Leave);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(92, 162);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 2;
            this.Cancel_button.Text = "Vazgeç";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sale_Button
            // 
            this.Sale_Button.Location = new System.Drawing.Point(173, 162);
            this.Sale_Button.Name = "Sale_Button";
            this.Sale_Button.Size = new System.Drawing.Size(75, 23);
            this.Sale_Button.TabIndex = 3;
            this.Sale_Button.Text = "Satış";
            this.Sale_Button.UseVisualStyleBackColor = true;
            this.Sale_Button.Click += new System.EventHandler(this.Sale_Button_Click);
            // 
            // Add_Sales_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 197);
            this.Controls.Add(this.Sale_Button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(271, 224);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(271, 224);
            this.Name = "Add_Sales_Mdi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manuel Satış";
            this.Load += new System.EventHandler(this.Add_Sales_Mdi_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Final_Price_Num)).EndInit();
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
        private System.Windows.Forms.NumericUpDown Final_Price_Num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Amount_Num;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Sale_Button;
    }
}