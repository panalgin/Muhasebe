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

            MuhasebeEntities m_Context = new MuhasebeEntities();

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
            MuhasebeEntities m_Context = new MuhasebeEntities();
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

                List<Faker> m_Events = null;

                if (this.Sort_Combo.SelectedItem.ToString() == "Belirli Tarih Aralığı")
                {
                    m_Begin = this.Begin_Picker.Value;
                    m_End = this.End_Picker.Value;
                }

                if (m_Category != null && m_Category.Name != "Hepsi")
                {
                    var result = from ev in m_Context.Events
                                 join author in (from at in m_Context.Users
                                                 select new
                                                 {
                                                     at.ID,
                                                     at.Name,
                                                     at.Surname
                                                 }) on ev.AuthorID equals author.ID
                                 join category in (from cat in m_Context.EventCategories
                                                   select new
                                                   {
                                                       cat.ID,
                                                       cat.Name
                                                   }) on ev.CategoryID equals category.ID

                                 where ev.OwnerID == Program.User.WorksAtID && ev.CategoryID == m_CategoryID && (ev.CreatedAt >= m_Begin && ev.CreatedAt <= m_End)
                                 orderby ev.CreatedAt descending

                                 select new Faker
                                 {
                                     ID = ev.ID,
                                     Name = author.Name,
                                     Surname = author.Surname,
                                     Category = category.Name,
                                     Description = ev.Description,
                                     CreatedAt = ev.CreatedAt.Value

                                 };

                    m_Events = result.ToList();

                }
                else
                {
                    var result = from ev in m_Context.Events
                                 join author in (from at in m_Context.Users
                                                 select new
                                                 {
                                                     at.ID,
                                                     at.Name,
                                                     at.Surname
                                                 }) on ev.AuthorID equals author.ID
                                 join category in (from cat in m_Context.EventCategories
                                                   select new
                                                   {
                                                       cat.ID,
                                                       cat.Name
                                                   }) on ev.CategoryID equals category.ID

                                 where ev.OwnerID == Program.User.WorksAtID && (ev.CreatedAt >= m_Begin && ev.CreatedAt <= m_End)
                                 orderby ev.CreatedAt descending

                                 select new Faker
                                 {
                                     ID = ev.ID,
                                     Name = author.Name,
                                     Surname = author.Surname,
                                     Category = category.Name,
                                     Description = ev.Description,
                                     CreatedAt = ev.CreatedAt.Value

                                 };

                    m_Events = result.ToList();
                }

                m_Events.All(delegate(Faker m_Event)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Event.ID;
                    m_Item.Text = string.Format("{0} {1}", m_Event.Name, m_Event.Surname);
                    m_Item.SubItems.Add(m_Event.CreatedAt.ToString());
                    m_Item.SubItems.Add(m_Event.Description);

                    if (m_Event.Category != null)
                        m_Item.SubItems.Add(m_Event.Category);
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

        private class Faker
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
        }
    }
}
