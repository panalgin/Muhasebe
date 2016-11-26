namespace Muhasebe
{
    partial class Buy_Items_Pop
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
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PaymentType_Combo = new System.Windows.Forms.ComboBox();
            this.Increase_Stock_Check = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CreatedAt_Picker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.Discount_Num = new System.Windows.Forms.NumericUpDown();
            this.Total_Label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SubTotal_Label = new System.Windows.Forms.Label();
            this.Buy_Items_List = new Muhasebe.Custom.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Account_Box = new Muhasebe.Custom.SearchBox();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.Discount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Enabled = false;
            this.Delete_Button.Location = new System.Drawing.Point(744, 54);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Button.TabIndex = 20;
            this.Delete_Button.Text = "Sil";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Button.Enabled = false;
            this.Edit_Button.Location = new System.Drawing.Point(744, 25);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(75, 23);
            this.Edit_Button.TabIndex = 19;
            this.Edit_Button.Text = "Düzenle";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(744, 505);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 23;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(649, 505);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(89, 23);
            this.Save_Button.TabIndex = 21;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ürün Listesi:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Toptancı:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Toplam Ödenecek:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Ödeme Türü:";
            // 
            // PaymentType_Combo
            // 
            this.PaymentType_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PaymentType_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaymentType_Combo.FormattingEnabled = true;
            this.PaymentType_Combo.Location = new System.Drawing.Point(87, 455);
            this.PaymentType_Combo.Name = "PaymentType_Combo";
            this.PaymentType_Combo.Size = new System.Drawing.Size(128, 21);
            this.PaymentType_Combo.TabIndex = 33;
            // 
            // Increase_Stock_Check
            // 
            this.Increase_Stock_Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Increase_Stock_Check.AutoSize = true;
            this.Increase_Stock_Check.Checked = true;
            this.Increase_Stock_Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Increase_Stock_Check.Location = new System.Drawing.Point(13, 508);
            this.Increase_Stock_Check.Name = "Increase_Stock_Check";
            this.Increase_Stock_Check.Size = new System.Drawing.Size(117, 17);
            this.Increase_Stock_Check.TabIndex = 34;
            this.Increase_Stock_Check.Text = "Ürünleri Stoğa Ekle";
            this.Increase_Stock_Check.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "İşlem Tarihi:";
            // 
            // CreatedAt_Picker
            // 
            this.CreatedAt_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreatedAt_Picker.Location = new System.Drawing.Point(357, 430);
            this.CreatedAt_Picker.Name = "CreatedAt_Picker";
            this.CreatedAt_Picker.Size = new System.Drawing.Size(178, 20);
            this.CreatedAt_Picker.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 484);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "İndirim:";
            // 
            // Discount_Num
            // 
            this.Discount_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Discount_Num.DecimalPlaces = 2;
            this.Discount_Num.Location = new System.Drawing.Point(357, 482);
            this.Discount_Num.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.Discount_Num.Name = "Discount_Num";
            this.Discount_Num.Size = new System.Drawing.Size(132, 20);
            this.Discount_Num.TabIndex = 38;
            this.Discount_Num.ValueChanged += new System.EventHandler(this.Discount_Num_ValueChanged);
            // 
            // Total_Label
            // 
            this.Total_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Total_Label.Location = new System.Drawing.Point(357, 508);
            this.Total_Label.Margin = new System.Windows.Forms.Padding(3);
            this.Total_Label.Name = "Total_Label";
            this.Total_Label.Size = new System.Drawing.Size(132, 20);
            this.Total_Label.TabIndex = 39;
            this.Total_Label.Text = "0.00 TL";
            this.Total_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Ara Toplam:";
            // 
            // SubTotal_Label
            // 
            this.SubTotal_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SubTotal_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SubTotal_Label.Location = new System.Drawing.Point(357, 456);
            this.SubTotal_Label.Margin = new System.Windows.Forms.Padding(3);
            this.SubTotal_Label.Name = "SubTotal_Label";
            this.SubTotal_Label.Size = new System.Drawing.Size(132, 20);
            this.SubTotal_Label.TabIndex = 41;
            this.SubTotal_Label.Text = "0.00 TL";
            this.SubTotal_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Buy_Items_List
            // 
            this.Buy_Items_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Buy_Items_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader5});
            this.Buy_Items_List.FullRowSelect = true;
            this.Buy_Items_List.GridLines = true;
            this.Buy_Items_List.Location = new System.Drawing.Point(12, 25);
            this.Buy_Items_List.MultiSelect = false;
            this.Buy_Items_List.Name = "Buy_Items_List";
            this.Buy_Items_List.Size = new System.Drawing.Size(726, 398);
            this.Buy_Items_List.TabIndex = 27;
            this.Buy_Items_List.UseCompatibleStateImageBehavior = false;
            this.Buy_Items_List.View = System.Windows.Forms.View.Details;
            this.Buy_Items_List.SelectedIndexChanged += new System.EventHandler(this.Buy_Items_List_SelectedIndexChanged);
            this.Buy_Items_List.DoubleClick += new System.EventHandler(this.Buy_Items_List_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barkod";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sipariş Kodu";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ürün Adı";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Alınan Miktar";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Birim Alış";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Toplam";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 143;
            // 
            // Account_Box
            // 
            this.Account_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Account_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Account_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Account_Box.FillType = Muhasebe.Custom.SearchBox.Fillable.Account;
            this.Account_Box.FormattingEnabled = true;
            this.Account_Box.Location = new System.Drawing.Point(87, 429);
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(128, 21);
            this.Account_Box.TabIndex = 26;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mevcut Stok";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 96;
            // 
            // Buy_Items_Pop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 540);
            this.Controls.Add(this.SubTotal_Label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Total_Label);
            this.Controls.Add(this.Discount_Num);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CreatedAt_Picker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Increase_Stock_Check);
            this.Controls.Add(this.PaymentType_Combo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buy_Items_List);
            this.Controls.Add(this.Account_Box);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Buy_Items_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mal Alımı";
            this.Load += new System.EventHandler(this.Buy_Items_Pop_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Buy_Items_Pop_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Discount_Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom.SearchBox Account_Box;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Custom.ListViewEx Buy_Items_List;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PaymentType_Combo;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox Increase_Stock_Check;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker CreatedAt_Picker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Discount_Num;
        private System.Windows.Forms.Label Total_Label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SubTotal_Label;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}