using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    public partial class Form1 : Form
    {
        PortfolioManager portfolioManager;
        PanelManager panelManager;
        public List<Panel> panels;
        public Form1()
        {
            InitializeComponent();
            Communicator communicator = new Communicator();
            portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
            panels = new List<Panel>();
            panelManager = new PanelManager(this);
            foreach (Company c in portfolioManager.CompanyList)
            {
                companyCheckedListBox.Items.Add(c.NameWithSymbol);
            }
            communicator.RemoteEndPoint = EndPointParser.Parse("127.0.0.1:12099");
            communicator.Start();
        }
        

        private void savePortfolioButton_Click(object sender, EventArgs e)
        {
            List<string> companyNames = new List<string>();
            for(int i = 0; i < companyCheckedListBox.CheckedItems.Count; i++)
            {
                companyNames.Add((string)companyCheckedListBox.CheckedItems[i]);
            }

            savePortfolioDialog.ShowDialog();
            if (savePortfolioDialog.FileName != "")
            {
                portfolioManager.SavePortfolio(savePortfolioDialog.FileName, companyNames);
            }
        }

        private void loadPortfolioButton_Click(object sender, EventArgs e)
        {
            loadPortfolioDialog.ShowDialog();
            if(loadPortfolioDialog.FileName != "")
            {
                foreach (int i in companyCheckedListBox.CheckedIndices)
                    companyCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);

                List<string> companyNames = portfolioManager.LoadPortfolio(loadPortfolioDialog.FileName);
                foreach(string name in companyNames)
                {
                    int index = companyCheckedListBox.Items.IndexOf((object)name);
                    companyCheckedListBox.SetItemCheckState(index, CheckState.Checked);
                }
            }
        }

        private void companyCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                portfolioManager.AddStock((string)companyCheckedListBox.Items[e.Index]);
                stocksListBox.Items.Add((string)companyCheckedListBox.Items[e.Index]);
            } 
            else
            {
                portfolioManager.RemoveStock((string)companyCheckedListBox.Items[e.Index]);
                stocksListBox.Items.Remove((string)companyCheckedListBox.Items[e.Index]);
            }
        }

        private void panelTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      

        private void newPanelButton_Click(object sender, EventArgs e)
        {
            if((string)panelTypeComboBox.SelectedItem == "Portfolio Stock Prices")
            {
                stockTabControl.TabPages.Add("Stock Prices");
            }
            
        }
        

    }
}
