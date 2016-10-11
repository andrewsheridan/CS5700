using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockMonitor
{
    public class GraphPanel : CustomPanel
    {
        public GraphPanel(string panelName, List<Stock> stocks): base(panelName, stocks)
        {
            System.Windows.Forms.DataVisualization.Charting.Series newSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Chart newChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

            chartArea.Name = "chartArea";
            newChart.ChartAreas.Add(chartArea);
            newChart.Location = new System.Drawing.Point(3, 38);
            newChart.Name = "chart1";

            newSeries.ChartArea = "chartArea";
            newSeries.Name = "newSeries";
            newChart.Series.Add(newSeries);
            newChart.Size = new System.Drawing.Size(271, 458);
            newChart.TabIndex = 5;
            newChart.Text = "chart1";
        }

        public override void Update(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
