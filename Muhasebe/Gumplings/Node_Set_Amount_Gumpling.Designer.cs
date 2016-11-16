﻿namespace Muhasebe
{
    partial class Node_Set_Amount_Gumpling
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
            this.label2 = new System.Windows.Forms.Label();
            this.Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün için yeni miktar giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Miktar:";
            // 
            // Amount_Num
            // 
            this.Amount_Num.Location = new System.Drawing.Point(73, 63);
            this.Amount_Num.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Amount_Num.Name = "Amount_Num";
            this.Amount_Num.Size = new System.Drawing.Size(150, 20);
            this.Amount_Num.TabIndex = 0;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(148, 101);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(52, 101);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(90, 23);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ürün Adı:";
            // 
            // Name_Label
            // 
            this.Name_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name_Label.Location = new System.Drawing.Point(73, 36);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(150, 20);
            this.Name_Label.TabIndex = 5;
            this.Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Node_Set_Amount_Gumpling
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(235, 136);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Amount_Num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Node_Set_Amount_Gumpling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ürün Miktarı Düzenle";
            this.Load += new System.EventHandler(this.Node_Set_Amount_Gumpling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Amount_Num;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Name_Label;
    }
}