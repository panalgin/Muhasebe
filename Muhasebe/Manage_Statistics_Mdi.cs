using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Muhasebe
{
    public partial class Manage_Statistics_Mdi : Form
    {
        public Manage_Statistics_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Statistics_Mdi_Load(object sender, EventArgs e)
        {
            this.CalculateMetrics();
            this.RatePlace();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void RatePlace()
        {            

        }

        private void CalculateMetrics()
        {
            DateTime m_Now = DateTime.Now;
            DateTime m_Begin = new DateTime(m_Now.Year, m_Now.Month, m_Now.Day, 0, 0, 0);
            DateTime m_Monthly = m_Begin.Subtract(TimeSpan.FromDays(30.0));
            this.chart1.Series.Clear();

            MuhasebeEntities m_Context = new MuhasebeEntities();
            var m_RevData = m_Context.Incomes.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Monthly).
                    GroupBy(q => new { Year = q.CreatedAt.Value.Year, Month = q.CreatedAt.Value.Month, Day = q.CreatedAt.Value.Day }).
                    Select(q => new
                    {
                        Amount = q.Sum(x => x.Amount),
                        CreatedAt = q.FirstOrDefault().CreatedAt
                    }).OrderBy(q => q.CreatedAt).ToList();

            var m_ExpData = m_Context.Expenditures.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Monthly).
                GroupBy(q => new { Year = q.CreatedAt.Value.Year, Month = q.CreatedAt.Value.Month, Day = q.CreatedAt.Value.Day }).
                Select(q => new
                {
                    Amount = q.Sum(x => x.Amount),
                    CreatedAt = q.FirstOrDefault().CreatedAt
                }).OrderBy(q => q.CreatedAt).ToList();

            Series m_Revenues = new Series();
            m_Revenues.Name = "Gelirler";

            Series m_Expenditures = new Series();
            m_Expenditures.Name = "Giderler";

            double i = 0;
            m_RevData.All(q =>
            {
                DateTime m_DateKey = new DateTime(q.CreatedAt.Value.Year, q.CreatedAt.Value.Month, q.CreatedAt.Value.Day);
                DataPoint m_Point = new DataPoint(m_DateKey.ToOADate(), Convert.ToDouble(q.Amount));
                m_Point.AxisLabel = q.CreatedAt.Value.ToShortDateString();
                m_Point.LabelAngle = 0;
                m_Point.LabelFormat = "0.## TL";
                m_Revenues.MarkerStyle = MarkerStyle.Square;
                m_Revenues.MarkerSize = 7;
                m_Revenues.MarkerColor = Color.DarkGreen;
                m_Revenues.ChartType = SeriesChartType.Line;
                m_Revenues.BorderWidth = 2;
                m_Revenues.Points.Add(m_Point);

                i++;
                return true;
            });

            i = 0;
            m_ExpData.All(q =>
            {
                DateTime m_DateKey = new DateTime(q.CreatedAt.Value.Year, q.CreatedAt.Value.Month, q.CreatedAt.Value.Day);
                DataPoint m_Point = new DataPoint(m_DateKey.ToOADate(), Convert.ToDouble(q.Amount));
                m_Point.AxisLabel = q.CreatedAt.Value.ToShortDateString();
                m_Point.LabelAngle = 0;
                m_Point.LabelFormat = "0.## TL";
                m_Expenditures.MarkerStyle = MarkerStyle.Square;
                m_Expenditures.MarkerSize = 7;
                m_Expenditures.MarkerColor = Color.DarkRed;
                m_Expenditures.ChartType = SeriesChartType.Line;
                m_Expenditures.BorderWidth = 2;
                m_Expenditures.Points.Add(m_Point);

                i++;
                return true;
            });

          /*  m_Revenues.IsValueShownAsLabel = true;
            m_Revenues.SmartLabelStyle.Enabled = false;
            m_Expenditures.IsValueShownAsLabel = true;
            m_Expenditures.SmartLabelStyle.Enabled = false;*/
            this.chart1.Series.Add(m_Revenues);
            this.chart1.Series.Add(m_Expenditures);

        }

        Point? m_Point = null;
        ToolTip m_Tooltip = new ToolTip();

        void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var m_Pos = e.Location;
            if (m_Point.HasValue && m_Pos == m_Point.Value)
                return;
            m_Tooltip.RemoveAll();
            m_Point = m_Pos;
            var m_Results = chart1.HitTest(m_Pos.X, m_Pos.Y, false, ChartElementType.DataPoint);
            foreach (var m_Result in m_Results)
            {
                if (m_Result.ChartElementType == ChartElementType.DataPoint)
                {
                    var m_Prop = m_Result.Object as DataPoint;
                    if (m_Prop != null)
                    {
                        var m_Pointxpixel = m_Result.ChartArea.AxisX.ValueToPixelPosition(m_Prop.XValue);
                        var m_Pointypixel = m_Result.ChartArea.AxisY.ValueToPixelPosition(m_Prop.YValues[0]);

                        if (Math.Abs(m_Pos.X - m_Pointxpixel) < 4 &&
                            Math.Abs(m_Pos.Y - m_Pointypixel) < 4)
                        {
                            m_Tooltip.Show("Tutar=" + m_Prop.YValues[0] + "TL" + ", Tarih=" + m_Prop.AxisLabel, this.chart1, m_Pos.X, m_Pos.Y - 15);
                        }
                    }
                }
            }
        }
    }
}
