using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    class PortfolioStockPricesPanel : PanelDecorator
    {
        public override List<Control> Create(List<Stock> stocks, string panelName, Form1 form)
        {
            List<Control> newControls = new List<Control>();
            Control[] result = form.Controls.Find("stockTabControl", true);
            
            Panel newPanel = new Panel();
            //newPanel.
            return newControls;
        }

        public override void Update(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
