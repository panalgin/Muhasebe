using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe.Custom
{
    public class SearchBox : ComboBox
    {
        public enum Fillable
        {
            Account,
            User,
            Item,
            Barcode
        }

        [Description("Select what type of object to fill in"),
        Category("Data"),
        DefaultValue(typeof(TextBox), null),
        Browsable(true)]
        public Fillable FillType { get; set; }

        public SearchBox()
        {
            this.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.TextChanged += SearchBox_TextChanged;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchBox sb = sender as SearchBox;

            if (sb != null)
            {
                if (sb.Text.Length >= 3)
                {
                    //SuggestStrings will have the logic to return array of strings either from cache/db
                    List<SearchEntity> results = SuggestStrings(sb.Text);

                    if (results != null)
                    {
                        sb.DisplayMember = "Name";
                        sb.ValueMember = "ID";
                        sb.AutoCompleteSource = AutoCompleteSource.ListItems;
                        sb.DataSource = results;
                    }
                }
            }
        }

        private List<SearchEntity> SuggestStrings(string needle)
        {
            if (Program.User == null)
                return null;

            List<SearchEntity> result = null;

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                switch (this.FillType)
                {
                    case Fillable.Account:
                        {
                            result = m_Context.Accounts.Where(q => q.Name.Contains(needle)).Select(q => new SearchEntity { ID = q.ID, Name = q.Name }).ToList();

                            break;
                        }
                    case Fillable.Item:
                        {

                            break;
                        }
                    case Fillable.User:
                        {

                            break;
                        }
                    case Fillable.Barcode:
                        {

                            break;
                        }
                }
            }

            return result;
        }

        private class SearchEntity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
