using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor
{
    public class StockPricePanel : GraphPanel
    {
        public StockPricePanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {

        }
    }
}
