﻿using System;
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
        Communicator communicator;
        public List<CustomPanel> Panels { get; set; }
        public enum PanelType { PorfolioStockPrices, IndividualStockPriceGraph, IndividualStockVolumeGraph };
        public Form1()
        {
            InitializeComponent();
            communicator = new Communicator();
            portfolioManager = new PortfolioManager("../../../CompanyList.csv", communicator);
            panelManager = new PanelManager();
            foreach (Company c in portfolioManager.CompanyList)
            {
                companyCheckedListBox.Items.Add(c.NameWithSymbol);
            }
            //communicator.RemoteEndPoint = EndPointParser.Parse("127.0.0.1:12099"); //Local Instance
            communicator.RemoteEndPoint = EndPointParser.Parse("54.191.47.218:12099"); //EC2 Instance
            communicator.Start();
        }

        ~Form1()
        {
            communicator.Stop();
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
                List<CustomPanel> toDelete = new List<CustomPanel>();
                foreach(CustomPanel p in panelManager.Panels)
                {
                    Stock s = portfolioManager.GetStockByFullName((string)companyCheckedListBox.Items[e.Index]);
                    if (p.ContainsStock(s))
                    {
                        toDelete.Add(p);
                    }
                }
                foreach(CustomPanel deleting in toDelete)
                {
                    stockTabControl.Controls.RemoveByKey(deleting.Name);
                    currentPanelListBox.Items.Remove(deleting.Name);
                    deleting.Delete();
                }
                portfolioManager.RemoveStock((string)companyCheckedListBox.Items[e.Index]);
                stocksListBox.Items.Remove((string)companyCheckedListBox.Items[e.Index]);
            }
        }

        private void panelTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)panelTypeComboBox.SelectedItem)
            {
                case "Portfolio Stock Prices" :
                    stocksListBox.SelectionMode = SelectionMode.MultiSimple;
                    break;
                default:
                    stocksListBox.SelectionMode = SelectionMode.One;
                    break;
            }
        }
      

        private void newPanelButton_Click(object sender, EventArgs e)
        {
            if ((string)panelTypeComboBox.SelectedItem == "Select Panel Type" || panelTypeComboBox.SelectedItem == null)
                return;

            if (newPanelNameTextBox.Text == null || newPanelNameTextBox.Text == "Input panel name here")
                return;

            TabPage newTab = createNewTab(newPanelNameTextBox.Text);
            stockTabControl.TabPages.Add(newTab);

            Label newLabel = createNewLabel(newPanelNameTextBox.Text);
            if (newLabel != null)
                newTab.Controls.Add(newLabel);
            else return;
            
            List<Stock> panelStocks = new List<Stock>();
            for(int i = 0; i < stocksListBox.SelectedItems.Count; i++)
            {
                string stockName = stocksListBox.SelectedItems[i].ToString();
                Stock toAdd = portfolioManager.GetStockByFullName(stockName);
                if(toAdd != null)
                    panelStocks.Add(toAdd);
            }

            if (panelStocks.Count == 0)
                return;

            List<Control> newControls = panelManager.CreatePanel((string)panelTypeComboBox.SelectedItem, newPanelNameTextBox.Text, panelStocks);
            if(newControls != null)
            {
                foreach (Control c in newControls)
                {
                    newTab.Controls.Add(c);
                }
            }
        }

        private void removePanelButton_Click(object sender, EventArgs e)
        {
            object item = currentPanelListBox.SelectedItem;
            if(item != null)
            {
                string panelName = (string)currentPanelListBox.SelectedItem;
                panelManager.Remove(panelName);
                stockTabControl.TabPages.RemoveByKey(panelName);
                currentPanelListBox.Items.Remove(item);
            }
            
        }

        public TabPage createNewTab(string tabName)
        {
            //Todo: Create new label with tab
            TabPage myTabPage = new TabPage(tabName);
            myTabPage.Name = tabName;
            myTabPage.Location = new System.Drawing.Point(4, 22);
            myTabPage.Padding = new System.Windows.Forms.Padding(3);
            myTabPage.Size = new System.Drawing.Size(289, 511);
            myTabPage.TabIndex = 1;
            myTabPage.UseVisualStyleBackColor = true;


            currentPanelListBox.Items.Add(newPanelNameTextBox.Text);

            return myTabPage;
        }

        public Label createNewLabel(string text)
        {
            Label newLabel = new Label();
            string selectedItem = (string)panelTypeComboBox.SelectedItem;
            
            if (text == null || text == "Input panel name here")
                return null;

            newLabel.Text = text;
            newLabel.AutoSize = true;
            newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newLabel.Location = new System.Drawing.Point(45, 19);
            newLabel.Size = new System.Drawing.Size(207, 26);

            return newLabel;
        }


    }
}
