namespace Muhasebe
{
    partial class Add_Revenue_Pop
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
            this.Description_Box = new System.Windows.Forms.TextBox();
            this.Revenue_Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.Responsible_Combo = new System.Windows.Forms.ComboBox();
            this.Revenue_Type_Combo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Revenue_Date_Picker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.Account_Box = new Muhasebe.Custom.SearchBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Revenue_Amount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Account_Box);
            this.groupBox1.Controls.Add(this.Description_Box);
            this.groupBox1.Controls.Add(this.Revenue_Amount_Num);
            this.groupBox1.Controls.Add(this.Responsible_Combo);
            this.groupBox1.Controls.Add(this.Revenue_Type_Combo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Revenue_Date_Picker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gelir Ekle";
            // 
            // Description_Box
            // 
            this.Description_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Description_Box.Location = new System.Drawing.Point(84, 153);
            this.Description_Box.Multiline = true;
            this.Description_Box.Name = "Description_Box";
            this.Description_Box.Size = new System.Drawing.Size(190, 66);
            this.Description_Box.TabIndex = 5;
            // 
            // Revenue_Amount_Num
            // 
            this.Revenue_Amount_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Revenue_Amount_Num.DecimalPlaces = 2;
            this.Revenue_Amount_Num.Location = new System.Drawing.Point(84, 72);
            this.Revenue_Amount_Num.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Revenue_Amount_Num.Name = "Revenue_Amount_Num";
            this.Revenue_Amount_Num.Size = new System.Drawing.Size(190, 20);
            this.Revenue_Amount_Num.TabIndex = 2;
            // 
            // Responsible_Combo
            // 
            this.Responsible_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Responsible_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Responsible_Combo.FormattingEnabled = true;
            this.Responsible_Combo.Location = new System.Drawing.Point(84, 125);
            this.Responsible_Combo.Name = "Responsible_Combo";
            this.Responsible_Combo.Size = new System.Drawing.Size(190, 21);
            this.Responsible_Combo.TabIndex = 4;
            // 
            // Revenue_Type_Combo
            // 
            this.Revenue_Type_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Revenue_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Revenue_Type_Combo.FormattingEnabled = true;
            this.Revenue_Type_Combo.Location = new System.Drawing.Point(84, 45);
            this.Revenue_Type_Combo.Name = "Revenue_Type_Combo";
            this.Revenue_Type_Combo.Size = new System.Drawing.Size(190, 21);
            this.Revenue_Type_Combo.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Açıklama:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Sorumlu:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "İlgili Hesap:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gelir Tutarı:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gelir Türü:";
            // 
            // Revenue_Date_Picker
            // 
            this.Revenue_Date_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Revenue_Date_Picker.Location = new System.Drawing.Point(84, 18);
            this.Revenue_Date_Picker.Name = "Revenue_Date_Picker";
            this.Revenue_Date_Picker.Size = new System.Drawing.Size(190, 20);
            this.Revenue_Date_Picker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gelir Tarihi:";
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Btn.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Btn.Location = new System.Drawing.Point(196, 271);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(96, 23);
            this.Cancel_Btn.TabIndex = 2;
            this.Cancel_Btn.Text = "İptal";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // Save_Btn
            // 
            this.Save_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Btn.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Btn.Location = new System.Drawing.Point(94, 271);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(96, 23);
            this.Save_Btn.TabIndex = 1;
            this.Save_Btn.Text = "Kaydet";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Account_Box
            // 
            this.Account_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Account_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Account_Box.FillType = Muhasebe.Custom.SearchBox.Fillable.Account;
            this.Account_Box.FormattingEnabled = true;
            this.Account_Box.Location = new System.Drawing.Point(84, 98);
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(190, 21);
            this.Account_Box.TabIndex = 3;
            // 
            // Add_Revenue_Pop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 306);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Save_Btn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Revenue_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gelir Ekleme";
            this.Load += new System.EventHandler(this.Add_Revenue_Pop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Revenue_Amount_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Revenue_Date_Picker;
        private System.Windows.Forms.NumericUpDown Revenue_Amount_Num;
        private System.Windows.Forms.ComboBox Responsible_Combo;
        private System.Windows.Forms.ComboBox Revenue_Type_Combo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Description_Box;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button Save_Btn;
        private Custom.SearchBox Account_Box;
    }
}