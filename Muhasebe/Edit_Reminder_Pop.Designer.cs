namespace Muhasebe
{
    partial class Edit_Reminder_Pop
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReminderWidth_Combo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ProductBarcode_Box = new System.Windows.Forms.TextBox();
            this.ProductName_Box = new System.Windows.Forms.TextBox();
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
            this.Max_UnitType_Label = new System.Windows.Forms.Label();
            this.Min_UnitType_Label = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.ProductBarcode_Box);
            this.groupBox1.Controls.Add(this.ProductName_Box);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Max_Num);
            this.groupBox1.Controls.Add(this.Min_Num);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Responsible_Combo);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 192);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hartılatma";
            // 
            // ReminderWidth_Combo
            // 
            this.ReminderWidth_Combo.FormattingEnabled = true;
            this.ReminderWidth_Combo.Location = new System.Drawing.Point(185, 153);
            this.ReminderWidth_Combo.Name = "ReminderWidth_Combo";
            this.ReminderWidth_Combo.Size = new System.Drawing.Size(192, 21);
            this.ReminderWidth_Combo.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hatırlatma Yöntemi :";
            // 
            // ProductBarcode_Box
            // 
            this.ProductBarcode_Box.Location = new System.Drawing.Point(185, 48);
            this.ProductBarcode_Box.Name = "ProductBarcode_Box";
            this.ProductBarcode_Box.Size = new System.Drawing.Size(192, 20);
            this.ProductBarcode_Box.TabIndex = 22;
            // 
            // ProductName_Box
            // 
            this.ProductName_Box.Location = new System.Drawing.Point(185, 22);
            this.ProductName_Box.Name = "ProductName_Box";
            this.ProductName_Box.Size = new System.Drawing.Size(192, 20);
            this.ProductName_Box.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ürün adı :";
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
            this.Max_Num.TabIndex = 2;
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
            this.Min_Num.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ürün barkodu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Minimum miktar :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Maksimum miktar :";
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
            this.Responsible_Combo.TabIndex = 4;
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
            // Max_UnitType_Label
            // 
            this.Max_UnitType_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Max_UnitType_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Max_UnitType_Label.Location = new System.Drawing.Point(322, 103);
            this.Max_UnitType_Label.Name = "Max_UnitType_Label";
            this.Max_UnitType_Label.Size = new System.Drawing.Size(35, 13);
            this.Max_UnitType_Label.TabIndex = 26;
            this.Max_UnitType_Label.Text = "birim";
            this.Max_UnitType_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Min_UnitType_Label
            // 
            this.Min_UnitType_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Min_UnitType_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Min_UnitType_Label.Location = new System.Drawing.Point(311, 76);
            this.Min_UnitType_Label.Name = "Min_UnitType_Label";
            this.Min_UnitType_Label.Size = new System.Drawing.Size(46, 15);
            this.Min_UnitType_Label.TabIndex = 27;
            this.Min_UnitType_Label.Text = "birim";
            this.Min_UnitType_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Edit_Reminder_Pop
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
            this.Name = "Edit_Reminder_Pop";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hatırlatma Düzenleme";
            this.Load += new System.EventHandler(this.Edit_Reminder_Pop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Max_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ProductBarcode_Box;
        private System.Windows.Forms.TextBox ProductName_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Max_Num;
        private System.Windows.Forms.NumericUpDown Min_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Responsible_Combo;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.ComboBox ReminderWidth_Combo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Max_UnitType_Label;
        private System.Windows.Forms.Label Min_UnitType_Label;
    }
}