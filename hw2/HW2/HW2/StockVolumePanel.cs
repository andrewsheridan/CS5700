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

        }

        public override void Update()
        {
            newSeries.Points.Add(new DataPoint(GetNextPointIndex(), stocks[0].CurrentVolume));
            UpdateTextBox("Current Volume: " + stocks[0].CurrentVolume);
            
            newChart.Update();
        }
    }
}
