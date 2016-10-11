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
        public PanelManager() { }

        List<Panel> Panels { get; set; }
        
        public List<Control> CreatePanel(string panelType, string panelName, List<Stock> stocks)
        {
            CustomPanel newPanel;
            switch (panelType)
            {
                case "Portfolio Stock Prices":
                    newPanel = new PortfolioStockPricesPanel(panelName, stocks);
                    return newPanel.GetControls();
                case "Stock Volume Graph":
                    newPanel = new StockVolumePanel(panelName, stocks);
                    return newPanel.GetControls();
                case "Stock Price Graph":
                    newPanel = new StockPricePanel(panelName, stocks);
                    return newPanel.GetControls() ;                    
                default:

                    break;
            }

            return new List<Control>();
        }
    }
}
