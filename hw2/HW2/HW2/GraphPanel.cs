using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace StockMonitor
{
    public class GraphPanel : CustomPanel
    {
        protected Series newSeries;
        protected ChartArea chartArea;
        protected Chart newChart;
        private static UInt32 nextPointIndex = 0;

        public GraphPanel(string panelName, List<Stock> stocks): base(panelName, stocks)
        {
            newSeries = new Series();
            chartArea = new ChartArea();
            newChart = new Chart();

            chartArea.Name = panelName + "ChartArea";
            chartArea.AxisX.LabelStyle.Enabled = false;
            newChart.ChartAreas.Add(chartArea);
            newChart.Location = new System.Drawing.Point(3, 38);
            newChart.Name = panelName + "Chart";

            newSeries.ChartArea = panelName + "ChartArea";
            newSeries.Name = panelName + "Series";
            newSeries.ChartType = SeriesChartType.Line;
            
            newChart.Series.Add(newSeries);
            newChart.Size = new System.Drawing.Size(271, 400);
            newChart.TabIndex = 5;
            newChart.Text = panelName;

            panelControls.Add(newChart);
        }

        public override void Update() { }

        protected UInt32 GetNextPointIndex()
        {
            UInt32 nextIndex = nextPointIndex;
            if (nextPointIndex == UInt32.MaxValue)
                nextPointIndex = 1;
            else
                nextPointIndex++;
            return nextIndex;
        }
    }
}
