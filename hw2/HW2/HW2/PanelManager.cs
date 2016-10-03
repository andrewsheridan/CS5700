using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor
{
    public class PanelManager
    {
        public enum PanelType { PorfolioStockPrices, IndividualStockPriceGraph, IndividualStockVolumeGraph };
        List<Panel> Panels { get; set; }

        public Panel createPanel(PanelType panelType, string panelName, List<string> stockNames)
        {

            return new Panel();
        }
    }
}
