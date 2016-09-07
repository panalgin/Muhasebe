namespace Muhasebe
{
    partial class Manage_Expenditure_Mdi
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
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.End_Picker = new System.Windows.Forms.DateTimePicker();
            this.End_Label = new System.Windows.Forms.Label();
            this.Begin_Picker = new System.Windows.Forms.DateTimePicker();
            this.Begin_Label = new System.Windows.Forms.Label();
            this.Sort_Label = new System.Windows.Forms.Label();
            this.Sort_Combo = new System.Windows.Forms.ComboBox();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.listView1 = new Muhasebe.Custom.ListViewEx();
            this.Stats_Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Add_Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Açıklama";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 405;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ödeme Yöntemi";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tutar";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Gider Türü";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 89;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tarih";
            this.columnHeader1.Width = 142;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sorumlu";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 97;
            // 
            // End_Picker
            // 
            this.End_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.End_Picker.Location = new System.Drawing.Point(448, 9);
            this.End_Picker.Name = "End_Picker";
            this.End_Picker.Size = new System.Drawing.Size(98, 20);
            this.End_Picker.TabIndex = 38;
            this.End_Picker.Visible = false;
            this.End_Picker.ValueChanged += new System.EventHandler(this.End_Picker_ValueChanged);
            // 
            // End_Label
            // 
            this.End_Label.AutoSize = true;
            this.End_Label.Location = new System.Drawing.Point(413, 12);
            this.End_Label.Name = "End_Label";
            this.End_Label.Size = new System.Drawing.Size(29, 13);
            this.End_Label.TabIndex = 37;
            this.End_Label.Text = "Bitiş:";
            this.End_Label.Visible = false;
            // 
            // Begin_Picker
            // 
            this.Begin_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Begin_Picker.Location = new System.Drawing.Point(298, 10);
            this.Begin_Picker.Name = "Begin_Picker";
            this.Begin_Picker.Size = new System.Drawing.Size(98, 20);
            this.Begin_Picker.TabIndex = 36;
            this.Begin_Picker.Visible = false;
            this.Begin_Picker.ValueChanged += new System.EventHandler(this.Begin_Picker_ValueChanged);
            // 
            // Begin_Label
            // 
            this.Begin_Label.AutoSize = true;
            this.Begin_Label.Location = new System.Drawing.Point(236, 12);
            this.Begin_Label.Name = "Begin_Label";
            this.Begin_Label.Size = new System.Drawing.Size(56, 13);
            this.Begin_Label.TabIndex = 35;
            this.Begin_Label.Text = "Başlangıç:";
            this.Begin_Label.Visible = false;
            // 
            // Sort_Label
            // 
            this.Sort_Label.AutoSize = true;
            this.Sort_Label.Location = new System.Drawing.Point(12, 12);
            this.Sort_Label.Name = "Sort_Label";
            this.Sort_Label.Size = new System.Drawing.Size(50, 13);
            this.Sort_Label.TabIndex = 34;
            this.Sort_Label.Text = "Sıralama:";
            // 
            // Sort_Combo
            // 
            this.Sort_Combo.BackColor = System.Drawing.SystemColors.Window;
            this.Sort_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sort_Combo.FormattingEnabled = true;
            this.Sort_Combo.Items.AddRange(new object[] {
            "Bugün",
            "Son 7 Gün",
            "Son 30 Gün",
            "Son 60 Gün",
            "Son 6 Ay",
            "Son 1 Yıl",
            "Belirli Tarih Aralığı"});
            this.Sort_Combo.Location = new System.Drawing.Point(68, 9);
            this.Sort_Combo.Name = "Sort_Combo";
            this.Sort_Combo.Size = new System.Drawing.Size(144, 21);
            this.Sort_Combo.TabIndex = 33;
            this.Sort_Combo.SelectedIndexChanged += new System.EventHandler(this.Sort_Combo_SelectedIndexChanged);
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Button.Enabled = false;
            this.Edit_Button.Location = new System.Drawing.Point(718, 64);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(75, 23);
            this.Edit_Button.TabIndex = 31;
            this.Edit_Button.Text = "Düzenle";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 36);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(700, 490);
            this.listView1.TabIndex = 29;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Stats_Label
            // 
            this.Stats_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Stats_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Stats_Label.ForeColor = System.Drawing.Color.White;
            this.Stats_Label.Location = new System.Drawing.Point(10, 8);
            this.Stats_Label.Name = "Stats_Label";
            this.Stats_Label.Size = new System.Drawing.Size(433, 13);
            this.Stats_Label.TabIndex = 39;
            this.Stats_Label.Text = "Toplam Kayıt: 0 adet, Toplam Gider: 0.00 TL";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.Stats_Label);
            this.panel1.Location = new System.Drawing.Point(-1, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 29);
            this.panel1.TabIndex = 42;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Enabled = false;
            this.Delete_Button.Image = global::Muhasebe.Properties.Resources.delete;
            this.Delete_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete_Button.Location = new System.Drawing.Point(718, 93);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Button.TabIndex = 32;
            this.Delete_Button.Text = "Sil";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.Image = global::Muhasebe.Properties.Resources.add;
            this.Add_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_Button.Location = new System.Drawing.Point(718, 35);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Button.TabIndex = 30;
            this.Add_Button.Text = "Yeni";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Manage_Expenditure_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.End_Picker);
            this.Controls.Add(this.End_Label);
            this.Controls.Add(this.Begin_Picker);
            this.Controls.Add(this.Begin_Label);
            this.Controls.Add(this.Sort_Label);
            this.Controls.Add(this.Sort_Combo);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.listView1);
            this.Name = "Manage_Expenditure_Mdi";
            this.Text = "Gider Yönetimi";
            this.Load += new System.EventHandler(this.Manage_Expenditure_Mdi_Load);
            this.Click += new System.EventHandler(this.Manage_Expenditure_Mdi_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.DateTimePicker End_Picker;
        private System.Windows.Forms.Label End_Label;
        private System.Windows.Forms.DateTimePicker Begin_Picker;
        private System.Windows.Forms.Label Begin_Label;
        private System.Windows.Forms.Label Sort_Label;
        private System.Windows.Forms.ComboBox Sort_Combo;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Add_Button;
        private Custom.ListViewEx listView1;
        private System.Windows.Forms.Label Stats_Label;
        private System.Windows.Forms.Panel panel1;
    }
}