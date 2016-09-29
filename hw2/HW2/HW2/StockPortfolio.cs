using System;
using System.Collections.Generic;

namespace StockMonitor
{
    public class StockPortfolio : Dictionary<String, Stock>
    {
        public void Update(TickerMessage message)
        {
            if (message == null) return;

            if (ContainsKey(message.Symbol))
                this[message.Symbol].Update(message);
        }
    }
}
