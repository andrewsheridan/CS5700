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
        public Form1()
        {
            InitializeComponent();
            portfolioManager = new PortfolioManager("../../../CompanyList.csv");
            foreach (Company c in portfolioManager.CompanyList)
            {
                companyCheckedListBox.Items.Add(c.NameWithSymbol);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
