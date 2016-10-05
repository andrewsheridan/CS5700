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
        public List<CustomPanel> Panels { get; set; }
        public enum PanelType { PorfolioStockPrices, IndividualStockPriceGraph, IndividualStockVolumeGraph };
        public Form1()
        {
            InitializeComponent();
            Communicator communicator = new Communicator();
            portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
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
            Label newLabel = new Label();

            switch ((string)panelTypeComboBox.SelectedItem)
            {
                case "Portfolio Stock Prices":
                    //TODO: check if there is already a portfolio stock prices panel
                    TabPage newTab = createNewTab();
                    stockTabControl.TabPages.Add(newTab);
                
                    newLabel.Text = "Portfolio Stock Prices";
                    newLabel.Name = "porfolioStockPricesLabel";
                    newLabel.AutoSize = true;
                    newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newLabel.Location = new System.Drawing.Point(41, 19);
                    newLabel.Size = new System.Drawing.Size(207, 26);

                    newTab.Controls.Add(newLabel);
                    break;
                default:

                    break;
            }
            
        }

        private TabPage createNewTab()
        {
            string selectedItem = (string)panelTypeComboBox.SelectedItem;
            if (selectedItem == "Select Panel Type")
                return null;
            if (newPanelNameTextBox.Text == null || newPanelNameTextBox.Text == "Input panel name here")
                return null;
            
            TabPage myTabPage = new TabPage(newPanelNameTextBox.Text);
            myTabPage.Name = newPanelNameTextBox.Text;
            myTabPage.Location = new System.Drawing.Point(4, 22);
            myTabPage.Padding = new System.Windows.Forms.Padding(3);
            myTabPage.Size = new System.Drawing.Size(289, 511);
            myTabPage.TabIndex = 1;
            myTabPage.UseVisualStyleBackColor = true;
            

            currentPanelListBox.Items.Add(newPanelNameTextBox.Text);

            return myTabPage;
        }

        private void removePanelButton_Click(object sender, EventArgs e)
        {
            object item = currentPanelListBox.SelectedItem;
            if(item != null)
            {
                stockTabControl.TabPages.RemoveByKey((string)currentPanelListBox.SelectedItem);
                currentPanelListBox.Items.Remove(item);
            }
            
        }
    }
}
