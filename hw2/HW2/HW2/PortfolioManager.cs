using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

namespace StockMonitor
{
    public class PortfolioManager
    {
        private Communicator communicator;
        public List<Company> CompanyList { get; set; }
        private StockPortfolio Portfolio { get; set; }
        

        public PortfolioManager(string filename, Communicator com)
        {
            CompanyList = LoadCompanyList(filename);
            communicator = com;
            Portfolio = new StockPortfolio();
            communicator.Portfolio = Portfolio;
        }
        
        public void SavePortfolio(string filename, List<string> companyNames) {
            string output = "";
            foreach(string name in companyNames)
            {
                Company match = CompanyList.Find(e => e.NameWithSymbol == name);
                output += match.Symbol + Environment.NewLine;
            }
            System.IO.File.WriteAllText(filename, output);
        }

        public List<string> LoadPortfolio(string filename)
        {
            Portfolio.Clear();
            List<string> companyNames = new List<string>();
            string[] companySymbols = System.IO.File.ReadAllLines(filename);

            foreach(string symbol in companySymbols)
            {
                Company match = CompanyList.Find(e => e.Symbol == symbol);
                companyNames.Add(match.NameWithSymbol);
            }

            return companyNames;
        }
        
        public List<Company> LoadCompanyList(string filename)
        {
            List<Company> companyList = new List<Company>();

            using (var textReader = new StreamReader(filename))
            {
                string line = textReader.ReadLine();
                while(line!= null)
                {
                    string[] columns = line.Split(',');
                    Company company = new Company(columns[0], columns[1]);
                    companyList.Add(company);
                    line = textReader.ReadLine();
                }
            }
            
            return companyList;
        }

        public void AddStock(string companyName)
        {
            Company match = CompanyList.Find(e => e.NameWithSymbol == companyName);
            if(match != null)
            {
                Stock stock = new Stock(match.Symbol, match.Name);
                Portfolio.Add(match.Symbol, stock);
                communicator.Stop();
                communicator.Start();
            }
        }

        public void RemoveStock(string companyName)
        {
            Company match = CompanyList.Find(e => e.NameWithSymbol == companyName);
            if(match != null)
            {
                Portfolio.Remove(match.Symbol);
                communicator.Stop();
                communicator.Start();
            }
        }

        public Stock GetStockByFullName(string fullName)
        {
            Company company = CompanyList.Find(x => x.NameWithSymbol == fullName);
            Stock stock = Portfolio[company.Symbol];
            return stock;
        }

        public Stock GetStockBySymbol(string symbol)
        {
            return Portfolio[symbol];
        }
    }
}
