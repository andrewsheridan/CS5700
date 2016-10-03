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
        public int OpeningPrice { get; set; }
        public int PreviousClosingPrice { get; set; }
        public int CurrentPrice { get; set; }
        public int BidPrice { get; set; }
        public int AskPrice { get; set; }
        public int CurrentVolume { get; set; }
        public int AverageVolume { get; set; }

        public Stock(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }

        public void Update(TickerMessage message)
        {
            OpeningPrice = message.OpeningPrice;
            PreviousClosingPrice = message.PreviousClosingPrice;
            CurrentPrice = message.CurrentPrice;
            BidPrice = message.BidPrice;
            AskPrice = message.AskPrice;
            CurrentVolume = message.CurrentVolume;
            AverageVolume = message.AverageVolume;
        }
    }
}
