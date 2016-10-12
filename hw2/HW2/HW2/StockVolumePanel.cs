using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace StockMonitor
{
    public class StockVolumePanel : GraphPanelDecorator
    {
        public StockVolumePanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            chartArea.AxisX.MajorGrid.Enabled = false;
            newSeries.ChartType = SeriesChartType.Column;
        }

        public override void UpdatePanel()
        {
            PlotGraphPoint(stocks[0].CurrentVolume);
            UpdateTextBox(stocks[0].CurrentVolume);
        }

        public override void UpdateTextBox(double newValue)
        {
            SetText("Current Volume: " + newValue);
        }
    }
}
