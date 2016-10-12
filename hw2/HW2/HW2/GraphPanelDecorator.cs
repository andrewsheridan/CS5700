
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockMonitor
{
    public abstract class
    GraphPanelDecorator : CustomPanel
    {
        protected Series newSeries;
        protected ChartArea chartArea;
        protected Chart newChart;
        private int nextPointIndex;
        private TextBox textBox;

        public GraphPanelDecorator(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            textBox = new TextBox();
            textBox.Location = new Point(50, 450);
            textBox.Size = new Size(200, 50);
            textBox.ReadOnly = true;
            panelControls.Add(textBox);

            nextPointIndex = 0;
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

        protected double GetNextPointIndex()
        {
            double nextIndex = nextPointIndex;
            if (nextPointIndex == int.MaxValue)
                nextPointIndex = 1;
            else
                nextPointIndex++;
            return nextIndex;
        }

        public void SetText(string text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => textBox.Text = text));
            }
            else
            {
                textBox.Text = text;
            }
        }
        
        public abstract void UpdateTextBox(double newValue);

        protected void PlotGraphPoint(int y)
        {
            DataPoint p = new DataPoint(GetNextPointIndex(), y);
            if (newChart.InvokeRequired)
            {
                newChart.Invoke(new Action(() => newSeries.Points.Add(p)));
            } else
            {
                newSeries.Points.Add(p);
            }
        }
    }
}
