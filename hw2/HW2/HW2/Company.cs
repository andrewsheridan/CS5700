using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMonitor
{
    public class Company
    {
        public string Symbol { get; set; }
        public string Name { get; set; }

        public string NameWithSymbol { get; set; }
        public Company(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
            NameWithSymbol = $"{name} ({symbol})";
        }
    }
}
