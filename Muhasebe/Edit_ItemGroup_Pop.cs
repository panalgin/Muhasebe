using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Edit_ItemGroup_Pop : Form
    {
        public delegate void OnItemGroupEdited(ItemGroup group);
        public event OnItemGroupEdited ItemGroupEdited;

        public ItemGroup ItemGroup { get; set; }

        public Edit_ItemGroup_Pop()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.ItemGroup != null)
            {
                if (this.Name_Box.Text == string.Empty || this.Name_Box.Text.Length < 3)
                {
                    MessageBox.Show("Lütfen en az 3 karakterden oluşan bir ürün grubu adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (MuhasebeEntities m_Context = new MuhasebeEntities())
                    {
                        ItemGroup m_Actual = m_Context.ItemGroups.Where(q => q.ID == this.ItemGroup.ID).FirstOrDefault();
                        m_Actual.Name = this.Name_Box.Text;
                        m_Context.SaveChanges();

                        InvokeItemGroupEdited(m_Actual);
                    }

                    this.Close();
                }
            }
        }

        private void InvokeItemGroupEdited(ItemGroup group)
        {
            if (ItemGroupEdited != null)
                ItemGroupEdited(group);
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_ItemGroup_Pop_Load(object sender, EventArgs e)
        {
            if (this.ItemGroup != null)
            {
                this.Name_Box.Text = this.ItemGroup.Name;
            }
        }
    }
}
