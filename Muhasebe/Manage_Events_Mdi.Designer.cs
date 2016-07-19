namespace Muhasebe
{
    using Muhasebe.Custom;
    partial class Manage_Events_Mdi
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
            this.label1 = new System.Windows.Forms.Label();
            this.Begin_Picker = new System.Windows.Forms.DateTimePicker();
            this.End_Picker = new System.Windows.Forms.DateTimePicker();
            this.Event_List = new ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Categories_Combo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Sort_Combo = new System.Windows.Forms.ComboBox();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarih Aralığı";
            // 
            // Begin_Picker
            // 
            this.Begin_Picker.CustomFormat = "dd/MM/yyyy H:mm";
            this.Begin_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Begin_Picker.Location = new System.Drawing.Point(330, 25);
            this.Begin_Picker.Name = "Begin_Picker";
            this.Begin_Picker.Size = new System.Drawing.Size(114, 20);
            this.Begin_Picker.TabIndex = 1;
            this.Begin_Picker.ValueChanged += new System.EventHandler(this.Begin_Picker_ValueChanged);
            // 
            // End_Picker
            // 
            this.End_Picker.CustomFormat = "dd/MM/yyyy H:mm";
            this.End_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.End_Picker.Location = new System.Drawing.Point(450, 24);
            this.End_Picker.Name = "End_Picker";
            this.End_Picker.Size = new System.Drawing.Size(114, 20);
            this.End_Picker.TabIndex = 2;
            this.End_Picker.ValueChanged += new System.EventHandler(this.End_Picker_ValueChanged);
            // 
            // Event_List
            // 
            this.Event_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Event_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Event_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.Event_List.FullRowSelect = true;
            this.Event_List.GridLines = true;
            this.Event_List.Location = new System.Drawing.Point(13, 52);
            this.Event_List.Name = "Event_List";
            this.Event_List.Size = new System.Drawing.Size(848, 407);
            this.Event_List.TabIndex = 4;
            this.Event_List.UseCompatibleStateImageBehavior = false;
            this.Event_List.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sorumlu";
            this.columnHeader1.Width = 163;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tarih";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 145;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Açıklama";
            this.columnHeader3.Width = 538;
            // 
            // Categories_Combo
            // 
            this.Categories_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Categories_Combo.FormattingEnabled = true;
            this.Categories_Combo.Location = new System.Drawing.Point(15, 24);
            this.Categories_Combo.Name = "Categories_Combo";
            this.Categories_Combo.Size = new System.Drawing.Size(149, 21);
            this.Categories_Combo.TabIndex = 5;
            this.Categories_Combo.SelectedIndexChanged += new System.EventHandler(this.Categories_Combo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kategori";
            // 
            // Sort_Combo
            // 
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
            this.Sort_Combo.Location = new System.Drawing.Point(170, 24);
            this.Sort_Combo.Name = "Sort_Combo";
            this.Sort_Combo.Size = new System.Drawing.Size(149, 21);
            this.Sort_Combo.TabIndex = 5;
            this.Sort_Combo.SelectedIndexChanged += new System.EventHandler(this.Sort_Combo_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kategori";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 148;
            // 
            // Manage_Events_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 473);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Sort_Combo);
            this.Controls.Add(this.Categories_Combo);
            this.Controls.Add(this.Event_List);
            this.Controls.Add(this.End_Picker);
            this.Controls.Add(this.Begin_Picker);
            this.Controls.Add(this.label1);
            this.Name = "Manage_Events_Mdi";
            this.Text = "Tüm Hareketler";
            this.Load += new System.EventHandler(this.Manage_Events_Mdi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Begin_Picker;
        private System.Windows.Forms.DateTimePicker End_Picker;
        private ListViewEx Event_List;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox Categories_Combo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Sort_Combo;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}