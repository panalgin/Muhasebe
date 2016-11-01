using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe.Custom
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ListView))]
    public class ListViewEx : ListView
    {
        public Dictionary<int, int> BaseColumnWidths = new Dictionary<int, int>();

        public ListViewEx()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            this.HandleCreated += ListViewEx_HandleCreated;
        }

        private void ListViewEx_HandleCreated(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (this.View == View.Details)
                {
                    RestoreColumnSettings();
                    this.ColumnWidthChanged += ListViewEx_ColumnWidthChanged;
                }
            }
        }

        private void RestoreColumnSettings()
        {
            DeserializeSettings();

            this.BaseColumnWidths.All(delegate (KeyValuePair<int, int> m_Pair)
            {
                this.Columns[m_Pair.Key].Width = m_Pair.Value;

                return true;
            });
        }

        private void ListViewEx_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (this.BaseColumnWidths.Keys.Contains(e.ColumnIndex))
            {
                if (this.BaseColumnWidths[e.ColumnIndex] != this.Columns[e.ColumnIndex].Width)
                {
                    int oldWidth = this.BaseColumnWidths[e.ColumnIndex];
                    int newWidth = this.Columns[e.ColumnIndex].Width;

                    this.BaseColumnWidths[e.ColumnIndex] = newWidth;

                    SerializeSettings();
                }
            }
            else
            {
                this.BaseColumnWidths.Add(e.ColumnIndex, this.Columns[e.ColumnIndex].Width);
            }
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        private void SerializeSettings()
        {
            if (!DesignMode)
            {
                string m_FilePath = Path.Combine(Application.StartupPath, "Settings");

                if (!Directory.Exists(m_FilePath))
                    Directory.CreateDirectory(m_FilePath);

                m_FilePath = Path.Combine(m_FilePath, string.Format("ListViewSettings-{0}.bin", this.Name));

                IFormatter formatter = new BinaryFormatter();

                using (Stream stream = new FileStream(m_FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, this.BaseColumnWidths);
                }
            }
        }

        private void DeserializeSettings()
        {
            if (!DesignMode)
            {
                IFormatter formatter = new BinaryFormatter();

                string m_FilePath = Path.Combine(Application.StartupPath, "Settings", string.Format("ListViewSettings-{0}.bin", this.Name));

                if (File.Exists(m_FilePath))
                {
                    using (Stream stream = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        this.BaseColumnWidths = formatter.Deserialize(stream) as Dictionary<int, int>;
                    }
                }
            }
        }
    }
}
