
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;

namespace StockMonitor
{
    public class StockPricePanel : GraphPanelDecorator
    {
        public StockPricePanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            //chartArea.AxisY.
        }

        public override void Update()
        {
            UpdateTextBox("Current Price: $" + stocks[0].CurrentPrice);
            newSeries.Points.Add(new DataPoint(GetNextPointIndex(), stocks[0].CurrentPrice));
            newChart.Update();
            //newChart.Parent.Update();
            //newChart.Parent.Parent.Update();
        }
    }
}
