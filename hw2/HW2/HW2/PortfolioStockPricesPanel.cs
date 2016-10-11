using System;
using System.Collections.Generic;

namespace StockMonitor
{
    class PortfolioStockPricesPanel : TextPanel
    {
        
        public PortfolioStockPricesPanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            
        }
        

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
