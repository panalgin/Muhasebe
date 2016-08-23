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
    public partial class Add_ItemGroup_Mdi : Form
    {
        public Add_ItemGroup_Mdi()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                ItemGroup m_Group = new ItemGroup();
                m_Group.Name = this.Name_Box.Text;
                m_Context.ItemGroups.Add(m_Group);
                m_Context.SaveChanges();
            }

            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
