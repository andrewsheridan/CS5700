using StockMonitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Collections.Generic;

namespace StockMonitorTesting
{
    [TestClass]
    public class PanelTesting
    {
        [TestMethod]
        public void TestPanelRegistration()
        {
            PortfolioManager portfolioManager;
            PanelManager panelManager;
            Communicator communicator;
            communicator = new Communicator();
            portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
            panelManager = new PanelManager();

            Company c = portfolioManager.CompanyList[100];
            portfolioManager.AddStockBySymbol(c.Symbol);
            Stock newStock = portfolioManager.GetStockBySymbol(c.Symbol);

            Assert.AreEqual(0, newStock.GetSubscriberCount());

            List<Stock> stockList = new List<Stock>();
            stockList.Add(newStock);
            panelManager.CreatePanel("Stock Volume Graph", "Test Panel", stockList);
            Assert.AreEqual(1, newStock.GetSubscriberCount());

            newStock.Unsubscribe(newStock.Subscribers[0]);
            Assert.AreEqual(0, newStock.GetSubscriberCount());
        }

        [TestMethod]
        public void TestPanelCreation()
        {
            PortfolioManager portfolioManager;
            PanelManager panelManager;
            Communicator communicator;
            communicator = new Communicator();
            portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
            panelManager = new PanelManager();

            Company c = portfolioManager.CompanyList[100];
            portfolioManager.AddStockBySymbol(c.Symbol);
            Stock newStock = portfolioManager.GetStockBySymbol(c.Symbol);

            Assert.AreEqual(0, panelManager.GetPanelCount());

            List<Stock> stockList = new List<Stock>();
            stockList.Add(newStock);
            panelManager.CreatePanel("Stock Volume Graph", "Test Panel", stockList);

            Assert.AreEqual(1, panelManager.GetPanelCount());
            panelManager.Remove("Test Panel");
            Assert.AreEqual(0, panelManager.GetPanelCount());

            panelManager.CreatePanel("Stock Price Graph", "Test Panel 2", stockList);
            Assert.AreEqual(1, panelManager.GetPanelCount());
            panelManager.Remove("Test Panel 2");
            Assert.AreEqual(0, panelManager.GetPanelCount());

            panelManager.CreatePanel("Portfolio Stock Prices", "Test Panel 3", stockList);
            Assert.AreEqual(1, panelManager.GetPanelCount());
            panelManager.Remove("This panel doesnt exist");
            Assert.AreEqual(1, panelManager.GetPanelCount());
            panelManager.Remove("Test Panel 3");
            Assert.AreEqual(0, panelManager.GetPanelCount());

            panelManager.CreatePanel("Not really a panel type", "Test Panel", stockList);
            Assert.AreEqual(0, panelManager.GetPanelCount());
        }


    }
}
