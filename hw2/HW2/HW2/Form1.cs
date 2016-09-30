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
            List<string> output = new List<string>();
            for(int i = 0; i < companyCheckedListBox.CheckedItems.Count; i++)
            {
                output.Add((string)companyCheckedListBox.CheckedItems[i]);
            }

            savePortfolioDialog.ShowDialog();
            if (savePortfolioDialog.FileName != "")
            {
                System.IO.File.WriteAllLines(savePortfolioDialog.FileName, output);
            }
        }

        private void loadPortfolioButton_Click(object sender, EventArgs e)
        {


            foreach(int i in companyCheckedListBox.CheckedIndices)
                companyCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            
            
        }
    }
}
