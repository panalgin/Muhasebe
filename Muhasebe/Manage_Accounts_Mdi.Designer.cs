namespace Muhasebe
{
    partial class Manage_Accounts_Mdi
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
            this.Add_Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Debt_Label = new System.Windows.Forms.Label();
            this.Loan_Label = new System.Windows.Forms.Label();
            this.Sell_Volume_Label = new System.Windows.Forms.Label();
            this.Buy_Volume_Label = new System.Windows.Forms.Label();
            this.Net_Value_Label = new System.Windows.Forms.Label();
            this.Net_State_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Account_History_View = new Muhasebe.Custom.ListViewEx();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Inspect_Button = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Customers_List = new Muhasebe.Custom.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Suppliers_List = new Muhasebe.Custom.ListViewEx();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Enabled = false;
            this.Delete_Button.Image = global::Muhasebe.Properties.Resources.delete;
            this.Delete_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete_Button.Location = new System.Drawing.Point(740, 92);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Button.TabIndex = 36;
            this.Delete_Button.Text = "Sil";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Button.Enabled = false;
            this.Edit_Button.Location = new System.Drawing.Point(740, 63);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(75, 23);
            this.Edit_Button.TabIndex = 35;
            this.Edit_Button.Text = "Düzenle";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.Image = global::Muhasebe.Properties.Resources.add;
            this.Add_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_Button.Location = new System.Drawing.Point(740, 34);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Button.TabIndex = 34;
            this.Add_Button.Text = "Yeni";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 260);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(722, 291);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Debt_Label);
            this.tabPage1.Controls.Add(this.Loan_Label);
            this.tabPage1.Controls.Add(this.Sell_Volume_Label);
            this.tabPage1.Controls.Add(this.Buy_Volume_Label);
            this.tabPage1.Controls.Add(this.Net_Value_Label);
            this.tabPage1.Controls.Add(this.Net_State_Label);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Account_History_View);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(714, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "İşlem Geçmişi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Debt_Label
            // 
            this.Debt_Label.AutoSize = true;
            this.Debt_Label.Location = new System.Drawing.Point(359, 236);
            this.Debt_Label.Name = "Debt_Label";
            this.Debt_Label.Size = new System.Drawing.Size(62, 13);
            this.Debt_Label.TabIndex = 40;
            this.Debt_Label.Text = "Debt_Label";
            // 
            // Loan_Label
            // 
            this.Loan_Label.AutoSize = true;
            this.Loan_Label.Location = new System.Drawing.Point(359, 214);
            this.Loan_Label.Name = "Loan_Label";
            this.Loan_Label.Size = new System.Drawing.Size(41, 13);
            this.Loan_Label.TabIndex = 40;
            this.Loan_Label.Text = "label10";
            // 
            // Sell_Volume_Label
            // 
            this.Sell_Volume_Label.AutoSize = true;
            this.Sell_Volume_Label.Location = new System.Drawing.Point(166, 236);
            this.Sell_Volume_Label.Name = "Sell_Volume_Label";
            this.Sell_Volume_Label.Size = new System.Drawing.Size(35, 13);
            this.Sell_Volume_Label.TabIndex = 9;
            this.Sell_Volume_Label.Text = "label9";
            // 
            // Buy_Volume_Label
            // 
            this.Buy_Volume_Label.AutoSize = true;
            this.Buy_Volume_Label.Location = new System.Drawing.Point(166, 214);
            this.Buy_Volume_Label.Name = "Buy_Volume_Label";
            this.Buy_Volume_Label.Size = new System.Drawing.Size(35, 13);
            this.Buy_Volume_Label.TabIndex = 8;
            this.Buy_Volume_Label.Text = "label8";
            // 
            // Net_Value_Label
            // 
            this.Net_Value_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Net_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Net_Value_Label.ForeColor = System.Drawing.Color.Red;
            this.Net_Value_Label.Location = new System.Drawing.Point(562, 223);
            this.Net_Value_Label.Name = "Net_Value_Label";
            this.Net_Value_Label.Size = new System.Drawing.Size(104, 13);
            this.Net_Value_Label.TabIndex = 7;
            this.Net_Value_Label.Text = "25,00 TL";
            this.Net_Value_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Net_State_Label
            // 
            this.Net_State_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Net_State_Label.Location = new System.Drawing.Point(556, 239);
            this.Net_State_Label.Name = "Net_State_Label";
            this.Net_State_Label.Size = new System.Drawing.Size(110, 13);
            this.Net_State_Label.TabIndex = 6;
            this.Net_State_Label.Text = "Borcunuz bulunmakta";
            this.Net_State_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Net: ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Borç Geçmişiniz:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Alacak Geçmişiniz:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ticaret Hacminiz[Satış]:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ticaret Hacminiz[Alış]:";
            // 
            // Account_History_View
            // 
            this.Account_History_View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Account_History_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader21});
            this.Account_History_View.FullRowSelect = true;
            this.Account_History_View.GridLines = true;
            this.Account_History_View.Location = new System.Drawing.Point(3, 3);
            this.Account_History_View.MultiSelect = false;
            this.Account_History_View.Name = "Account_History_View";
            this.Account_History_View.Size = new System.Drawing.Size(708, 199);
            this.Account_History_View.TabIndex = 0;
            this.Account_History_View.UseCompatibleStateImageBehavior = false;
            this.Account_History_View.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tarih";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "İşlemi Yapan";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Ödeme Türü";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tutar";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Hareket Türü";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader21.Width = 115;
            // 
            // Inspect_Button
            // 
            this.Inspect_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Inspect_Button.Image = global::Muhasebe.Properties.Resources.magnifier;
            this.Inspect_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Inspect_Button.Location = new System.Drawing.Point(740, 282);
            this.Inspect_Button.Name = "Inspect_Button";
            this.Inspect_Button.Size = new System.Drawing.Size(75, 23);
            this.Inspect_Button.TabIndex = 38;
            this.Inspect_Button.Text = "İncele";
            this.Inspect_Button.UseVisualStyleBackColor = true;
            this.Inspect_Button.Click += new System.EventHandler(this.Inspect_Button_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(12, 12);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(722, 242);
            this.tabControl2.TabIndex = 39;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Customers_List);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(714, 216);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Müşteriler";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Customers_List
            // 
            this.Customers_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6});
            this.Customers_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Customers_List.FullRowSelect = true;
            this.Customers_List.GridLines = true;
            this.Customers_List.Location = new System.Drawing.Point(3, 3);
            this.Customers_List.Name = "Customers_List";
            this.Customers_List.Size = new System.Drawing.Size(708, 210);
            this.Customers_List.TabIndex = 33;
            this.Customers_List.UseCompatibleStateImageBehavior = false;
            this.Customers_List.View = System.Windows.Forms.View.Details;
            this.Customers_List.SelectedIndexChanged += new System.EventHandler(this.Customers_List_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "Hesap Adı";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 144;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 0;
            this.columnHeader4.Text = "#";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 28;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hesap Türü";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 124;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Şehir";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "İlçe";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Telefon";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Gsm";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Email";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 117;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Suppliers_List);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(714, 216);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Tedarikçiler";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Suppliers_List
            // 
            this.Suppliers_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.Suppliers_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Suppliers_List.FullRowSelect = true;
            this.Suppliers_List.GridLines = true;
            this.Suppliers_List.Location = new System.Drawing.Point(3, 3);
            this.Suppliers_List.Name = "Suppliers_List";
            this.Suppliers_List.Size = new System.Drawing.Size(708, 210);
            this.Suppliers_List.TabIndex = 34;
            this.Suppliers_List.UseCompatibleStateImageBehavior = false;
            this.Suppliers_List.View = System.Windows.Forms.View.Details;
            this.Suppliers_List.SelectedIndexChanged += new System.EventHandler(this.Suppliers_List_SelectedIndexChanged);
            // 
            // columnHeader13
            // 
            this.columnHeader13.DisplayIndex = 1;
            this.columnHeader13.Text = "Hesap Adı";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 144;
            // 
            // columnHeader14
            // 
            this.columnHeader14.DisplayIndex = 0;
            this.columnHeader14.Text = "#";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 28;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Hesap Türü";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 124;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Şehir";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "İlçe";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Telefon";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Gsm";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Email";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader20.Width = 117;
            // 
            // Manage_Accounts_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 563);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.Inspect_Button);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Add_Button);
            this.Name = "Manage_Accounts_Mdi";
            this.Text = "Hesap Yönetimi";
            this.Load += new System.EventHandler(this.Manage_Accounts_Mdi_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Add_Button;
        private Custom.ListViewEx Customers_List;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private Muhasebe.Custom.ListViewEx Account_History_View;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button Inspect_Button;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Custom.ListViewEx Suppliers_List;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Label Net_Value_Label;
        private System.Windows.Forms.Label Net_State_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Debt_Label;
        private System.Windows.Forms.Label Loan_Label;
        private System.Windows.Forms.Label Sell_Volume_Label;
        private System.Windows.Forms.Label Buy_Volume_Label;
    }
}