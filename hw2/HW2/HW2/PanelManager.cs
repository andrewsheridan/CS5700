using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    public class PanelManager
    {
        private Form form;
        public PanelManager(Form f)
        {
            form = f;
        }
        public enum PanelType { PorfolioStockPrices, IndividualStockPriceGraph, IndividualStockVolumeGraph };
        List<Panel> Panels { get; set; }

        public void createPanel(PanelType panelType, string panelName, List<string> stockNames)
        {
            Panel newPanel = new Panel();

            newPanel.Name = panelName;

        }
    }
}
