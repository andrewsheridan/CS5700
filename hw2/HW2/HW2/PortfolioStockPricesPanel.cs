using System;
using System.Collections.Generic;

namespace StockMonitor
{
    class PortfolioStockPricesPanel : TextPanelDecorator
    {
        string header;
        const int padding = 10;
        public PortfolioStockPricesPanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            header = "Stock".PadRight(padding) + "Current".PadRight(padding) + "Bid".PadRight(padding) + "Ask" + Environment.NewLine;
        }
       

        public override void UpdatePanel()
        {
            List<String> entries = new List<String>();
            foreach(Stock s in stocks)
            {
                String entry = s.Symbol.PadRight(padding) + s.CurrentPrice.ToString().PadRight(padding) + s.BidPrice.ToString().PadRight(padding) + s.AskPrice.ToString().PadRight(padding) + Environment.NewLine;
                entries.Add(entry);
            }
            UpdateRichTextBox(header, entries);
        }

    }
}
