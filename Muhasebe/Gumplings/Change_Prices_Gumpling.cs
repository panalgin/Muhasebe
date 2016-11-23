using Muhasebe.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe.Gumplings
{
    public partial class Change_Prices_Gumpling : Form
    {
        private string AffectState = "Both";
        private Item Example { get; set; }

        public Change_Prices_Gumpling()
        {
            InitializeComponent();
        }

        private void Change_Prices_Gumpling_Load(object sender, EventArgs e)
        {
            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Groups = m_Context.ItemGroups.Select(q => new { ID = q.ID, Name = q.Name }).ToList();

                this.Group_Combo.DataSource = m_Groups;
                this.Group_Combo.ValueMember = "ID";
                this.Group_Combo.DisplayMember = "Name";

                this.Group_Combo.Invalidate();
            }

            this.Group_Combo.SelectedIndexChanged += Group_Combo_SelectedIndexChanged;
            this.Group_Combo_SelectedIndexChanged(sender, e);
            this.radioButton3.Checked = true;
        }

        private void Group_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m_GroupID = Convert.ToInt32(this.Group_Combo.SelectedValue);

            if (m_GroupID > 0)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_TotalItems = m_Context.ItemGroups.Where(q => q.ID == m_GroupID).FirstOrDefault().Items.Count;
                    this.Distinct_Label.Text = string.Format("{0} kalem ürün etkilenecek", m_TotalItems);

                    SelectExampleItem();
                }
            }
        }

        private void SelectExampleItem()
        {
            int m_GroupID = Convert.ToInt32(this.Group_Combo.SelectedValue);

            if (m_GroupID > 0)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    int m_Skip = new Random().Next(0, m_Context.ItemGroups.Where(q => q.ID == m_GroupID).FirstOrDefault().Items.Count - 1);

                    Item m_Item = m_Context.Items.Where(q => q.GroupID == m_GroupID).OrderByDescending(q => q.ID).Skip(m_Skip).Take(1).FirstOrDefault();

                    if (m_Item != null)
                    {
                        this.Example = m_Item;
                        UpdateExample();
                    }
                }
            }
        }

        private void UpdateExample()
        {
            if (this.Example != null)
            {
                this.Sample_Name_Label.Text = this.Example.Product.Name;
                this.Ex_BasePrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.BasePrice.Value);
                this.Ex_FinalPrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.FinalPrice.Value);
                this.New_BasePrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.BasePrice.Value);
                this.New_FinalPrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.FinalPrice.Value); ;

                if (this.Change_Num.Value != 0)
                {
                    if (this.AffectState != "Final")
                        this.New_BasePrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.BasePrice.Value * (1 + (this.Change_Num.Value / 100.00m)));

                    if (this.AffectState != "Base")
                        this.New_FinalPrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.FinalPrice.Value * (1 + (this.Change_Num.Value / 100.00m)));
                }
                else
                {
                    this.New_BasePrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.BasePrice.Value);
                    this.New_FinalPrice_Label.Text = ItemHelper.GetFormattedPrice(this.Example.FinalPrice.Value);
                }
            }
            else
            {
                this.Sample_Name_Label.Text = "Örnek Ürün Bulunamadı";
                this.Ex_BasePrice_Label.Text = "-";
                this.Ex_FinalPrice_Label.Text = "-";
                this.New_BasePrice_Label.Text = "-";
                this.New_FinalPrice_Label.Text = "-";
            }


            if (this.New_BasePrice_Label.Text != this.Ex_BasePrice_Label.Text)
                this.New_BasePrice_Label.ForeColor = Color.Red;
            else
                this.New_BasePrice_Label.ForeColor = SystemColors.ControlText;

            if (this.New_FinalPrice_Label.Text != this.Ex_FinalPrice_Label.Text)
                this.New_FinalPrice_Label.ForeColor = Color.Red;
            else
                this.New_FinalPrice_Label.ForeColor = SystemColors.ControlText;
        }

        private void Change_Num_ValueChanged(object sender, EventArgs e)
        {
            UpdateExample();
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton m_Button = sender as RadioButton;

            if (m_Button.Checked)
            {
                this.AffectState = Convert.ToString(m_Button.Tag);
                UpdateExample();
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Change_Num.Value != 0 && this.Example != null)
            {
                using(MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    int m_GroupID = Convert.ToInt32(this.Group_Combo.Tag);

                    ItemGroup m_Group = m_Context.ItemGroups.Where(q => q.ID == m_GroupID).FirstOrDefault();

                    if (m_Group != null)
                    {
                        if (this.AffectState != "Final")
                            m_Context.Items.Where(q => q.GroupID == m_GroupID).All(delegate (Item item)
                            {
                                item.BasePrice = item.BasePrice * (1 + (this.Change_Num.Value / 100.00m));

                                return true;
                            });

                        if (this.AffectState != "Base")
                            m_Context.Items.Where(q => q.GroupID == m_GroupID).All(delegate (Item item)
                            {
                                item.FinalPrice = item.FinalPrice * (1 + (this.Change_Num.Value / 100.00m));

                                return true;
                            });

                        m_Context.SaveChanges();
                    }
                }
            }

            this.Close();
        }
    }
}
