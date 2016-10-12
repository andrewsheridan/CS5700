
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;
using System;


namespace StockMonitor
{
    public class StockPricePanel : GraphPanelDecorator
    {
        public StockPricePanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
        }

        public override void UpdatePanel()
        {
            PlotGraphPoint(stocks[0].CurrentPrice);
            UpdateTextBox(stocks[0].CurrentPrice);
        }

        public override void UpdateTextBox(double newValue)
        {
            SetText("Current Price: " + newValue);
        }
    }
}
