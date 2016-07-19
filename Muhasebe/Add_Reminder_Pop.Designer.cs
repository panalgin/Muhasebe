namespace Muhasebe
{
    partial class Add_Reminder_Pop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Reminder_Pop));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Max_UnitType_Label = new System.Windows.Forms.Label();
            this.Min_UnitType_Label = new System.Windows.Forms.Label();
            this.ReminderWidth_Combo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Product_Barcode_Box = new System.Windows.Forms.TextBox();
            this.Product_Name_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Max_Num = new System.Windows.Forms.NumericUpDown();
            this.Min_Num = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Responsible_Combo = new System.Windows.Forms.ComboBox();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Max_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Max_UnitType_Label);
            this.groupBox1.Controls.Add(this.Min_UnitType_Label);
            this.groupBox1.Controls.Add(this.ReminderWidth_Combo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Product_Barcode_Box);
            this.groupBox1.Controls.Add(this.Product_Name_Box);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Max_Num);
            this.groupBox1.Controls.Add(this.Min_Num);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Responsible_Combo);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hartılatma";
            // 
            // Max_UnitType_Label
            // 
            this.Max_UnitType_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Max_UnitType_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Max_UnitType_Label.Location = new System.Drawing.Point(321, 104);
            this.Max_UnitType_Label.Name = "Max_UnitType_Label";
            this.Max_UnitType_Label.Size = new System.Drawing.Size(35, 13);
            this.Max_UnitType_Label.TabIndex = 24;
            this.Max_UnitType_Label.Text = "birim";
            this.Max_UnitType_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Min_UnitType_Label
            // 
            this.Min_UnitType_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Min_UnitType_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Min_UnitType_Label.Location = new System.Drawing.Point(310, 77);
            this.Min_UnitType_Label.Name = "Min_UnitType_Label";
            this.Min_UnitType_Label.Size = new System.Drawing.Size(46, 15);
            this.Min_UnitType_Label.TabIndex = 24;
            this.Min_UnitType_Label.Text = "birim";
            this.Min_UnitType_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReminderWidth_Combo
            // 
            this.ReminderWidth_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReminderWidth_Combo.FormattingEnabled = true;
            this.ReminderWidth_Combo.Location = new System.Drawing.Point(185, 153);
            this.ReminderWidth_Combo.Name = "ReminderWidth_Combo";
            this.ReminderWidth_Combo.Size = new System.Drawing.Size(192, 21);
            this.ReminderWidth_Combo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Hatırlatma Yöntemi :";
            // 
            // Product_Barcode_Box
            // 
            this.Product_Barcode_Box.Location = new System.Drawing.Point(185, 22);
            this.Product_Barcode_Box.Name = "Product_Barcode_Box";
            this.Product_Barcode_Box.Size = new System.Drawing.Size(192, 20);
            this.Product_Barcode_Box.TabIndex = 1;
            this.Product_Barcode_Box.TextChanged += new System.EventHandler(this.Product_Barcode_Box_TextChanged);
            // 
            // Product_Name_Box
            // 
            this.Product_Name_Box.Location = new System.Drawing.Point(185, 48);
            this.Product_Name_Box.Name = "Product_Name_Box";
            this.Product_Name_Box.Size = new System.Drawing.Size(192, 20);
            this.Product_Name_Box.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ürün Adı :";
            // 
            // Max_Num
            // 
            this.Max_Num.DecimalPlaces = 2;
            this.Max_Num.Location = new System.Drawing.Point(185, 100);
            this.Max_Num.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Max_Num.Name = "Max_Num";
            this.Max_Num.Size = new System.Drawing.Size(192, 20);
            this.Max_Num.TabIndex = 4;
            // 
            // Min_Num
            // 
            this.Min_Num.DecimalPlaces = 2;
            this.Min_Num.Location = new System.Drawing.Point(185, 74);
            this.Min_Num.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Min_Num.Name = "Min_Num";
            this.Min_Num.Size = new System.Drawing.Size(192, 20);
            this.Min_Num.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ürün Barkodu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Minimum Miktar :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Maksimum Miktar :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Hatırlatma Sorumlusu :";
            // 
            // Responsible_Combo
            // 
            this.Responsible_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Responsible_Combo.FormattingEnabled = true;
            this.Responsible_Combo.Location = new System.Drawing.Point(185, 126);
            this.Responsible_Combo.Name = "Responsible_Combo";
            this.Responsible_Combo.Size = new System.Drawing.Size(192, 21);
            this.Responsible_Combo.TabIndex = 5;
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Btn.Location = new System.Drawing.Point(298, 207);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(96, 23);
            this.Cancel_Btn.TabIndex = 8;
            this.Cancel_Btn.Text = "İptal";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // Save_Btn
            // 
            this.Save_Btn.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Btn.Location = new System.Drawing.Point(196, 207);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(96, 23);
            this.Save_Btn.TabIndex = 7;
            this.Save_Btn.Text = "Kaydet";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Add_Reminder_Pop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 242);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Save_Btn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(413, 269);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(413, 269);
            this.Name = "Add_Reminder_Pop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Hatırlatma";
            this.Load += new System.EventHandler(this.Add_Reminder_Pop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Max_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Min_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Responsible_Combo;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.TextBox Product_Barcode_Box;
        private System.Windows.Forms.TextBox Product_Name_Box;
        private System.Windows.Forms.NumericUpDown Max_Num;
        private System.Windows.Forms.ComboBox ReminderWidth_Combo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Max_UnitType_Label;
        private System.Windows.Forms.Label Min_UnitType_Label;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}