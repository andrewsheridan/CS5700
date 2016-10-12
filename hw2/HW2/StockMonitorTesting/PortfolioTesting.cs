using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockMonitor;
using System.Collections.Generic;

namespace StockMonitorTesting
{
    [TestClass]
    public class PortfolioTesting
    {
        [TestMethod]
        public void StockAddRemoveTest()
        {
            Communicator communicator = new Communicator();
            PortfolioManager portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);

            Company c = portfolioManager.CompanyList[5];
            Assert.AreEqual(0, portfolioManager.GetStockCount());

            portfolioManager.AddStockBySymbol(c.Symbol);
            Assert.AreEqual(1, portfolioManager.GetStockCount());

            portfolioManager.AddStock(portfolioManager.CompanyList[100].NameWithSymbol);
            Assert.AreEqual(2, portfolioManager.GetStockCount());

            portfolioManager.RemoveStock(c.NameWithSymbol);
            Assert.AreEqual(1, portfolioManager.GetStockCount());

            portfolioManager.RemoveStock(portfolioManager.CompanyList[100].NameWithSymbol);
            Assert.AreEqual(0, portfolioManager.GetStockCount());

            portfolioManager.AddStock("Not really a stock");
            Assert.AreEqual(0, portfolioManager.GetStockCount());
        }

        [TestMethod]
        public void PortfolioSaveLoadTest()
        {
            Communicator communicator = new Communicator();
            PortfolioManager portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
            int[] companiesToAdd = { 1, 50, 231 , 1001};
            List<String> companyList = new List<String>();
            foreach (int companyIndex in companiesToAdd)
            {
                Company c = portfolioManager.CompanyList[companyIndex];
                portfolioManager.AddStockBySymbol(c.Symbol);
                companyList.Add(c.NameWithSymbol);
            }

            portfolioManager.SavePortfolio("SavePortfolioTest.txt", companyList);

            Assert.AreEqual(companyList.Count, companiesToAdd.GetLength(0));
            Assert.AreEqual(portfolioManager.GetStockCount(), companiesToAdd.GetLength(0));

            PortfolioManager loadingPortfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
            loadingPortfolioManager.LoadPortfolio("SavePortfolioTest.txt");

            Assert.AreEqual(loadingPortfolioManager.GetStockCount(), companiesToAdd.GetLength(0));
            foreach(String s in companyList)
            {
                Assert.IsNotNull(loadingPortfolioManager.GetStockByFullName(s));
            }
        }
    }
}
