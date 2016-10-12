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
        public PanelManager() {
            Panels = new List<CustomPanel>();
        }

        List<CustomPanel> Panels { get; set; }
        
        public List<Control> CreatePanel(string panelType, string panelName, List<Stock> stocks)
        {
            CustomPanel newPanel;
            switch (panelType)
            {
                case "Portfolio Stock Prices":
                    newPanel = new PortfolioStockPricesPanel(panelName, stocks);
                    break;
                case "Stock Volume Graph":
                    newPanel = new StockVolumePanel(panelName, stocks);
                    break;
                case "Stock Price Graph":
                    newPanel = new StockPricePanel(panelName, stocks);
                    break;
                default:
                    return null;
            }
            Panels.Add(newPanel);
            return newPanel.GetControls();
        }

        public void Remove(string panelName)
        {
            int index = Panels.FindIndex(x => x.Name == panelName);
            if(index >= 0 && index < Panels.Count)
            {
                Panels[index].Delete();
                Panels.RemoveAt(index);
            }
            
        }

        public int GetPanelCount()
        {
            return Panels.Count;
        }
    }
}
