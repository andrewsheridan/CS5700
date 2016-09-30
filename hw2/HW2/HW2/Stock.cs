using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }

        public Stock(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }
        public void Update(TickerMessage message)
        {


        }
    }
}
