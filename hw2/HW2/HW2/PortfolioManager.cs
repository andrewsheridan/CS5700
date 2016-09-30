using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;

namespace StockMonitor
{
    public class PortfolioManager
    {
        public List<Company> CompanyList { get; set; }
        private StockPortfolio Portfolio { get; set; }

        public PortfolioManager(string filename)
        {
            CompanyList = LoadCompanyList(filename);
        }
        
        public void SavePortfolio(string filename) {

        }

        public void LoadPortfolio(string filename)
        {

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
    }
}
