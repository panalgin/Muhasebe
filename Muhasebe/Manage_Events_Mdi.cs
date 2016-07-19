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
    public partial class Manage_Events_Mdi : Form
    {
        public Manage_Events_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Events_Mdi_Load(object sender, EventArgs e)
        {
            this.Sort_Combo.SelectedIndex = 0;

            this.Begin_Picker.Value = DateTime.Now.Subtract(TimeSpan.FromDays(90.0));
            this.End_Picker.Value = DateTime.Now;

            MicroEntities m_Context = new MicroEntities();

            var m_Categories = m_Context.EventCategories.ToList();

            this.Categories_Combo.DataSource = m_Categories;
            this.Categories_Combo.ValueMember = "ID";
            this.Categories_Combo.DisplayMember = "Name";

            this.PopulateListView();
        }

        private void Sort_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Sort_Combo.SelectedItem.ToString() == "Belirli Tarih Aralığı")
            {
                this.Begin_Picker.Visible = true;
                this.End_Picker.Visible = true;
            }
            else
            {
                this.Begin_Picker.Visible = false;
                this.End_Picker.Visible = false;
            }

            PopulateListView();
        }

        private void PopulateListView()
        {
            this.Event_List.Items.Clear();
            MicroEntities m_Context = new MicroEntities();
            DateTime m_Now = DateTime.Now;

            DateTime m_Begin = new DateTime(m_Now.Year, m_Now.Month, m_Now.Day, 0, 0, 0);
            DateTime m_End = new DateTime(m_Now.Year, m_Now.Month, m_Now.Day, 23, 59, 59);
            int m_CategoryID = 0;
            EventCategory m_Category = null;

            if (this.Categories_Combo.SelectedValue != null && int.TryParse(this.Categories_Combo.SelectedValue.ToString(), out m_CategoryID))
            {
                m_Category = m_Context.EventCategories.Where(q => q.ID == m_CategoryID).FirstOrDefault();
            }

            if (this.Sort_Combo.SelectedItem.ToString() != string.Empty)
            {
                switch (this.Sort_Combo.SelectedItem.ToString())
                {
                    case "Bugün": //defaulted
                        break;

                    case "Son 7 Gün":
                        {
                            m_Begin = m_Begin.Subtract(TimeSpan.FromDays(7));

                            break;
                        }

                    case "Son 30 Gün":
                        {
                            m_Begin = m_Begin.Subtract(TimeSpan.FromDays(30.0));

                            break;
                        }

                    case "Son 60 Gün":
                        {
                            m_Begin = m_Begin.Subtract(TimeSpan.FromDays(60.0));

                            break;
                        }

                    case "Son 6 Ay":
                        {
                            m_Begin = m_Begin.Subtract(TimeSpan.FromDays(180.0));

                            break;
                        }

                    case "Son 1 Yıl":
                        {
                            m_Begin = m_Begin.Subtract(TimeSpan.FromDays(365.0));

                            break;
                        }

                    case "Belirli Tarih Aralığı":
                        {
                            m_Begin = new DateTime(this.Begin_Picker.Value.Year, this.Begin_Picker.Value.Month, this.Begin_Picker.Value.Day, 0, 0, 0);
                            m_End = new DateTime(this.End_Picker.Value.Year, this.End_Picker.Value.Month, this.End_Picker.Value.Day, 23, 59, 59);

                            break;
                        }
                }

                List<Event> m_Events = null;

                if (this.Sort_Combo.SelectedItem.ToString() == "Belirli Tarih Aralığı")
                {
                    m_Begin = this.Begin_Picker.Value;
                    m_End = this.End_Picker.Value;
                }

                if (m_Category != null && m_Category.Name != "Hepsi")
                    m_Events = m_Context.Events.Where(q => q.Author.WorksAtID == Program.User.WorksAtID && (q.CreatedAt >= m_Begin && q.CreatedAt <= m_End) && q.CategoryID == m_CategoryID).OrderByDescending(q => q.CreatedAt).ToList();
                else
                    m_Events = m_Context.Events.Where(q => q.Author.WorksAtID == Program.User.WorksAtID && (q.CreatedAt >= m_Begin && q.CreatedAt <= m_End)).OrderByDescending(q => q.CreatedAt).ToList();

                m_Events.All(delegate(Event m_Event)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Event.ID;
                    m_Item.Text = string.Format("{0} {1}", m_Event.Author.Name, m_Event.Author.Surname);
                    m_Item.SubItems.Add(m_Event.CreatedAt.ToString());
                    m_Item.SubItems.Add(m_Event.Description);

                    if (m_Event.Category != null)
                        m_Item.SubItems.Add(m_Event.Category.Name);
                    else
                        m_Item.SubItems.Add("-");

                    this.Event_List.Items.Add(m_Item);


                    return true;
                });
            }
        }

        private void Begin_Picker_ValueChanged(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void End_Picker_ValueChanged(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void Categories_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateListView();
        }
    }
}
