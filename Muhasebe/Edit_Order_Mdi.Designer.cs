﻿namespace Muhasebe
{
    partial class Edit_Order_Mdi
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
            this.Attn_Note = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Error_Provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Account_Box = new Muhasebe.Custom.SearchBox();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).BeginInit();
            this.SuspendLayout();
            // 
            // Attn_Note
            // 
            this.Error_Provider.SetIconPadding(this.Attn_Note, -20);
            this.Attn_Note.Location = new System.Drawing.Point(427, 12);
            this.Attn_Note.Multiline = true;
            this.Attn_Note.Name = "Attn_Note";
            this.Attn_Note.Size = new System.Drawing.Size(256, 47);
            this.Attn_Note.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Yetkiliye Not:";
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Enabled = false;
            this.Delete_Button.Location = new System.Drawing.Point(608, 119);
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
            this.Edit_Button.Location = new System.Drawing.Point(608, 90);
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
            this.Cancel_Button.Location = new System.Drawing.Point(608, 445);
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
            this.Save_Button.Location = new System.Drawing.Point(513, 445);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(89, 23);
            this.Save_Button.TabIndex = 21;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 90);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(590, 340);
            this.listView1.TabIndex = 24;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ürün Resmi";
            this.columnHeader6.Width = 68;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ürün Kodu";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 87;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ürün Adı";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 148;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "İstediğimiz Adet";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 87;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Açıklama";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 196;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Sipariş Listesi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "İlgili Hesap:";
            // 
            // Name_Box
            // 
            this.Error_Provider.SetIconPadding(this.Name_Box, -20);
            this.Name_Box.Location = new System.Drawing.Point(103, 12);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(216, 20);
            this.Name_Box.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sipariş Form Adı:";
            // 
            // Error_Provider
            // 
            this.Error_Provider.ContainerControl = this;
            // 
            // Account_Box
            // 
            this.Account_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Account_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Account_Box.FillType = Muhasebe.Custom.SearchBox.Fillable.Account;
            this.Account_Box.FormattingEnabled = true;
            this.Account_Box.Location = new System.Drawing.Point(103, 38);
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(216, 21);
            this.Account_Box.TabIndex = 26;
            // 
            // Edit_Order_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 480);
            this.Controls.Add(this.Account_Box);
            this.Controls.Add(this.Attn_Note);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Order_Mdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sipariş Düzenle";
            this.Load += new System.EventHandler(this.Edit_Order_Mdi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Attn_Note;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider Error_Provider;
        private Custom.SearchBox Account_Box;
    }
}