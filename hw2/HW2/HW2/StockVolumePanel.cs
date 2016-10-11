using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockMonitor
{
    public class StockVolumePanel : GraphPanel
    {
        public StockVolumePanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {

        }

        public override void Update()
        {
            newSeries.Points.Add(new DataPoint(GetNextPointIndex(), stocks[0].CurrentVolume));
            newChart.Update();
        }
    }
}
