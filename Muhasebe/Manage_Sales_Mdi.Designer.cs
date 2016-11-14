namespace Muhasebe
{
    partial class Manage_Sales_Mdi
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Subtotal_Label = new System.Windows.Forms.Label();
            this.Tax_Label = new System.Windows.Forms.Label();
            this.Total_Label = new System.Windows.Forms.Label();
            this.Author_Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SaleScreen_List = new Muhasebe.Custom.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Context_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manuelSatışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Payment_Combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.UseTermedPrice_Check = new System.Windows.Forms.CheckBox();
            this.Account_Box = new Muhasebe.Custom.SearchBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Sale_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Context_Menu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 378);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 26);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Genel Toplam";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ara Toplam :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Subtotal_Label
            // 
            this.Subtotal_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Subtotal_Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Subtotal_Label.Location = new System.Drawing.Point(155, 10);
            this.Subtotal_Label.Name = "Subtotal_Label";
            this.Subtotal_Label.Size = new System.Drawing.Size(78, 13);
            this.Subtotal_Label.TabIndex = 10;
            this.Subtotal_Label.Text = "0 TL";
            this.Subtotal_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Subtotal_Label.Click += new System.EventHandler(this.Subtotal_Label_Click);
            // 
            // Tax_Label
            // 
            this.Tax_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Tax_Label.Location = new System.Drawing.Point(152, 32);
            this.Tax_Label.Name = "Tax_Label";
            this.Tax_Label.Size = new System.Drawing.Size(81, 13);
            this.Tax_Label.TabIndex = 11;
            this.Tax_Label.Text = "0 TL";
            this.Tax_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Total_Label
            // 
            this.Total_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Total_Label.ForeColor = System.Drawing.Color.Green;
            this.Total_Label.Location = new System.Drawing.Point(131, 67);
            this.Total_Label.Name = "Total_Label";
            this.Total_Label.Size = new System.Drawing.Size(102, 16);
            this.Total_Label.TabIndex = 12;
            this.Total_Label.Text = "0 TL";
            this.Total_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Author_Label
            // 
            this.Author_Label.AutoSize = true;
            this.Author_Label.Location = new System.Drawing.Point(12, 9);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(128, 13);
            this.Author_Label.TabIndex = 13;
            this.Author_Label.Text = "Kasiyer : Ahmet VARDAR";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Subtotal_Label);
            this.panel1.Controls.Add(this.Total_Label);
            this.panel1.Controls.Add(this.Tax_Label);
            this.panel1.Location = new System.Drawing.Point(12, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 102);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Genel Toplam :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(10, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Kdv Toplam:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaleScreen_List
            // 
            this.SaleScreen_List.AllowColumnReorder = true;
            this.SaleScreen_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaleScreen_List.AutoArrange = false;
            this.SaleScreen_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaleScreen_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.SaleScreen_List.ContextMenuStrip = this.Context_Menu;
            this.SaleScreen_List.FullRowSelect = true;
            this.SaleScreen_List.GridLines = true;
            this.SaleScreen_List.Location = new System.Drawing.Point(12, 25);
            this.SaleScreen_List.Name = "SaleScreen_List";
            this.SaleScreen_List.Size = new System.Drawing.Size(650, 347);
            this.SaleScreen_List.TabIndex = 18;
            this.SaleScreen_List.UseCompatibleStateImageBehavior = false;
            this.SaleScreen_List.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barkod";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ürün Adı";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 44;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Birim";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "KDV";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 44;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Birim Fiyat";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 102;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Toplam Fiyat";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 113;
            // 
            // Context_Menu
            // 
            this.Context_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manuelSatışToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem});
            this.Context_Menu.Name = "Context_Menu";
            this.Context_Menu.Size = new System.Drawing.Size(135, 70);
            this.Context_Menu.Opening += new System.ComponentModel.CancelEventHandler(this.Context_Menu_Opening);
            // 
            // manuelSatışToolStripMenuItem
            // 
            this.manuelSatışToolStripMenuItem.Name = "manuelSatışToolStripMenuItem";
            this.manuelSatışToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.manuelSatışToolStripMenuItem.Text = "Manuel Satış";
            this.manuelSatışToolStripMenuItem.Click += new System.EventHandler(this.manuelSatışToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Enabled = false;
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Enabled = false;
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // Payment_Combo
            // 
            this.Payment_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Payment_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Payment_Combo.FormattingEnabled = true;
            this.Payment_Combo.Location = new System.Drawing.Point(82, 7);
            this.Payment_Combo.Name = "Payment_Combo";
            this.Payment_Combo.Size = new System.Drawing.Size(165, 21);
            this.Payment_Combo.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ödeme Türü :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(272, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 26);
            this.panel2.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(4, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ödeme Seçenekleri";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.UseTermedPrice_Check);
            this.panel4.Controls.Add(this.Account_Box);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.Payment_Combo);
            this.panel4.Location = new System.Drawing.Point(272, 403);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 102);
            this.panel4.TabIndex = 22;
            // 
            // UseTermedPrice_Check
            // 
            this.UseTermedPrice_Check.AutoSize = true;
            this.UseTermedPrice_Check.Checked = true;
            this.UseTermedPrice_Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseTermedPrice_Check.Enabled = false;
            this.UseTermedPrice_Check.Location = new System.Drawing.Point(82, 61);
            this.UseTermedPrice_Check.Name = "UseTermedPrice_Check";
            this.UseTermedPrice_Check.Size = new System.Drawing.Size(113, 17);
            this.UseTermedPrice_Check.TabIndex = 23;
            this.UseTermedPrice_Check.Text = "Vade Farkı Uygula";
            this.UseTermedPrice_Check.UseVisualStyleBackColor = true;
            this.UseTermedPrice_Check.CheckedChanged += new System.EventHandler(this.UseTermedPrice_Check_CheckedChanged);
            // 
            // Account_Box
            // 
            this.Account_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Account_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Account_Box.FillType = Muhasebe.Custom.SearchBox.Fillable.Account;
            this.Account_Box.FormattingEnabled = true;
            this.Account_Box.Location = new System.Drawing.Point(82, 34);
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(165, 21);
            this.Account_Box.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "İlgili Hesap:";
            // 
            // Sale_Button
            // 
            this.Sale_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Sale_Button.Image = global::Muhasebe.Properties.Resources.basket_valid;
            this.Sale_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sale_Button.Location = new System.Drawing.Point(536, 401);
            this.Sale_Button.Name = "Sale_Button";
            this.Sale_Button.Size = new System.Drawing.Size(126, 49);
            this.Sale_Button.TabIndex = 23;
            this.Sale_Button.Text = "Satış [Enter]";
            this.Sale_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Sale_Button.UseVisualStyleBackColor = true;
            this.Sale_Button.Click += new System.EventHandler(this.Sale_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.basket_delete;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(536, 456);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(126, 49);
            this.Cancel_Button.TabIndex = 24;
            this.Cancel_Button.Text = "İptal [Esc]";
            this.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Manage_Sales_Mdi
            // 
            this.AcceptButton = this.Sale_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(674, 517);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Sale_Button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.SaleScreen_List);
            this.Controls.Add(this.Author_Label);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "Manage_Sales_Mdi";
            this.Text = "Satış Ekranı";
            this.Load += new System.EventHandler(this.Manage_Sales_Mdi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Manage_Sales_Mdi_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Context_Menu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Subtotal_Label;
        private System.Windows.Forms.Label Tax_Label;
        private System.Windows.Forms.Label Total_Label;
        private System.Windows.Forms.Label Author_Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private Custom.ListViewEx SaleScreen_List;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ComboBox Payment_Combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Sale_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.ContextMenuStrip Context_Menu;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuelSatışToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private Custom.SearchBox Account_Box;
        private System.Windows.Forms.CheckBox UseTermedPrice_Check;
    }
}