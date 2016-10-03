using System.Collections.Generic;

namespace StockMonitor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stockTabControl = new System.Windows.Forms.TabControl();
            this.portfolioTab = new System.Windows.Forms.TabPage();
            this.loadPortfolioButton = new System.Windows.Forms.Button();
            this.savePortfolioButton = new System.Windows.Forms.Button();
            this.companyCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.portfolioLabel = new System.Windows.Forms.Label();
            this.panelManagerTab = new System.Windows.Forms.TabPage();
            this.stocksListBox = new System.Windows.Forms.ListBox();
            this.removePanelButton = new System.Windows.Forms.Button();
            this.panelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.managePanelsLabel = new System.Windows.Forms.Label();
            this.newPanelLabel = new System.Windows.Forms.Label();
            this.currentPanelListBox = new System.Windows.Forms.ListBox();
            this.newPanelButton = new System.Windows.Forms.Button();
            this.savePortfolioDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadPortfolioDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newPanelTitle = new System.Windows.Forms.Label();
            this.stockTabControl.SuspendLayout();
            this.portfolioTab.SuspendLayout();
            this.panelManagerTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockTabControl
            // 
            this.stockTabControl.Controls.Add(this.portfolioTab);
            this.stockTabControl.Controls.Add(this.panelManagerTab);
            this.stockTabControl.Controls.Add(this.tabPage1);
            this.stockTabControl.Location = new System.Drawing.Point(12, 12);
            this.stockTabControl.Name = "stockTabControl";
            this.stockTabControl.SelectedIndex = 0;
            this.stockTabControl.Size = new System.Drawing.Size(297, 537);
            this.stockTabControl.TabIndex = 0;
            // 
            // portfolioTab
            // 
            this.portfolioTab.Controls.Add(this.loadPortfolioButton);
            this.portfolioTab.Controls.Add(this.savePortfolioButton);
            this.portfolioTab.Controls.Add(this.companyCheckedListBox);
            this.portfolioTab.Controls.Add(this.portfolioLabel);
            this.portfolioTab.Location = new System.Drawing.Point(4, 22);
            this.portfolioTab.Name = "portfolioTab";
            this.portfolioTab.Padding = new System.Windows.Forms.Padding(3);
            this.portfolioTab.Size = new System.Drawing.Size(289, 511);
            this.portfolioTab.TabIndex = 0;
            this.portfolioTab.Text = "Portfolio";
            this.portfolioTab.UseVisualStyleBackColor = true;
            // 
            // loadPortfolioButton
            // 
            this.loadPortfolioButton.Location = new System.Drawing.Point(149, 460);
            this.loadPortfolioButton.Name = "loadPortfolioButton";
            this.loadPortfolioButton.Size = new System.Drawing.Size(107, 23);
            this.loadPortfolioButton.TabIndex = 3;
            this.loadPortfolioButton.Text = "Load Portfolio";
            this.loadPortfolioButton.UseVisualStyleBackColor = true;
            this.loadPortfolioButton.Click += new System.EventHandler(this.loadPortfolioButton_Click);
            // 
            // savePortfolioButton
            // 
            this.savePortfolioButton.Location = new System.Drawing.Point(32, 460);
            this.savePortfolioButton.Name = "savePortfolioButton";
            this.savePortfolioButton.Size = new System.Drawing.Size(107, 23);
            this.savePortfolioButton.TabIndex = 1;
            this.savePortfolioButton.Text = "Save Portfolio";
            this.savePortfolioButton.UseVisualStyleBackColor = true;
            this.savePortfolioButton.Click += new System.EventHandler(this.savePortfolioButton_Click);
            // 
            // companyCheckedListBox
            // 
            this.companyCheckedListBox.FormattingEnabled = true;
            this.companyCheckedListBox.Location = new System.Drawing.Point(6, 57);
            this.companyCheckedListBox.Name = "companyCheckedListBox";
            this.companyCheckedListBox.ScrollAlwaysVisible = true;
            this.companyCheckedListBox.Size = new System.Drawing.Size(277, 379);
            this.companyCheckedListBox.TabIndex = 2;
            this.companyCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.companyCheckedListBox_ItemCheck);
            // 
            // portfolioLabel
            // 
            this.portfolioLabel.AutoSize = true;
            this.portfolioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioLabel.Location = new System.Drawing.Point(27, 18);
            this.portfolioLabel.Name = "portfolioLabel";
            this.portfolioLabel.Size = new System.Drawing.Size(229, 26);
            this.portfolioLabel.TabIndex = 1;
            this.portfolioLabel.Text = "Manage Your Portfolio";
            // 
            // panelManagerTab
            // 
            this.panelManagerTab.Controls.Add(this.stocksListBox);
            this.panelManagerTab.Controls.Add(this.removePanelButton);
            this.panelManagerTab.Controls.Add(this.panelTypeComboBox);
            this.panelManagerTab.Controls.Add(this.managePanelsLabel);
            this.panelManagerTab.Controls.Add(this.newPanelLabel);
            this.panelManagerTab.Controls.Add(this.currentPanelListBox);
            this.panelManagerTab.Controls.Add(this.newPanelButton);
            this.panelManagerTab.Location = new System.Drawing.Point(4, 22);
            this.panelManagerTab.Name = "panelManagerTab";
            this.panelManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.panelManagerTab.Size = new System.Drawing.Size(289, 511);
            this.panelManagerTab.TabIndex = 1;
            this.panelManagerTab.Text = "Panels";
            this.panelManagerTab.UseVisualStyleBackColor = true;
            // 
            // stocksListBox
            // 
            this.stocksListBox.FormattingEnabled = true;
            this.stocksListBox.Location = new System.Drawing.Point(37, 79);
            this.stocksListBox.Name = "stocksListBox";
            this.stocksListBox.Size = new System.Drawing.Size(211, 134);
            this.stocksListBox.TabIndex = 7;
            // 
            // removePanelButton
            // 
            this.removePanelButton.Location = new System.Drawing.Point(37, 475);
            this.removePanelButton.Name = "removePanelButton";
            this.removePanelButton.Size = new System.Drawing.Size(211, 23);
            this.removePanelButton.TabIndex = 6;
            this.removePanelButton.Text = "Remove Panel";
            this.removePanelButton.UseVisualStyleBackColor = true;
            // 
            // panelTypeComboBox
            // 
            this.panelTypeComboBox.FormattingEnabled = true;
            this.panelTypeComboBox.Items.AddRange(new object[] {
            "Portfolio Stock Prices"});
            this.panelTypeComboBox.Location = new System.Drawing.Point(37, 48);
            this.panelTypeComboBox.Name = "panelTypeComboBox";
            this.panelTypeComboBox.Size = new System.Drawing.Size(211, 21);
            this.panelTypeComboBox.TabIndex = 4;
            this.panelTypeComboBox.Text = "Select Panel Type";
            this.panelTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.panelTypeComboBox_SelectedIndexChanged);
            // 
            // managePanelsLabel
            // 
            this.managePanelsLabel.AutoSize = true;
            this.managePanelsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managePanelsLabel.Location = new System.Drawing.Point(32, 280);
            this.managePanelsLabel.Name = "managePanelsLabel";
            this.managePanelsLabel.Size = new System.Drawing.Size(216, 26);
            this.managePanelsLabel.TabIndex = 0;
            this.managePanelsLabel.Text = "Manage Your Panels";
            // 
            // newPanelLabel
            // 
            this.newPanelLabel.AutoSize = true;
            this.newPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPanelLabel.Location = new System.Drawing.Point(41, 19);
            this.newPanelLabel.Name = "newPanelLabel";
            this.newPanelLabel.Size = new System.Drawing.Size(207, 26);
            this.newPanelLabel.TabIndex = 3;
            this.newPanelLabel.Text = "Create a New Panel";
            // 
            // currentPanelListBox
            // 
            this.currentPanelListBox.FormattingEnabled = true;
            this.currentPanelListBox.Location = new System.Drawing.Point(37, 309);
            this.currentPanelListBox.Name = "currentPanelListBox";
            this.currentPanelListBox.ScrollAlwaysVisible = true;
            this.currentPanelListBox.Size = new System.Drawing.Size(211, 160);
            this.currentPanelListBox.TabIndex = 1;
            // 
            // newPanelButton
            // 
            this.newPanelButton.Location = new System.Drawing.Point(37, 224);
            this.newPanelButton.Name = "newPanelButton";
            this.newPanelButton.Size = new System.Drawing.Size(211, 23);
            this.newPanelButton.TabIndex = 2;
            this.newPanelButton.Text = "Create Panel";
            this.newPanelButton.UseVisualStyleBackColor = true;
            this.newPanelButton.Click += new System.EventHandler(this.newPanelButton_Click);
            // 
            // savePortfolioDialog
            // 
            this.savePortfolioDialog.DefaultExt = "txt";
            this.savePortfolioDialog.Filter = "Text Files (*.txt)|*.txt";
            this.savePortfolioDialog.Title = "Save Portfolio";
            // 
            // loadPortfolioDialog
            // 
            this.loadPortfolioDialog.DefaultExt = "txt";
            this.loadPortfolioDialog.FileName = "loadPortfolioDialog";
            this.loadPortfolioDialog.Filter = "Text Files (*.txt) | *.txt";
            this.loadPortfolioDialog.Title = "Load Portfolio";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(289, 511);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newPanelTitle);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 499);
            this.panel1.TabIndex = 0;
            // 
            // newPanelTitle
            // 
            this.newPanelTitle.AutoSize = true;
            this.newPanelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPanelTitle.Location = new System.Drawing.Point(51, 9);
            this.newPanelTitle.Name = "newPanelTitle";
            this.newPanelTitle.Size = new System.Drawing.Size(164, 26);
            this.newPanelTitle.TabIndex = 4;
            this.newPanelTitle.Text = "New Panel Title";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 561);
            this.Controls.Add(this.stockTabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.stockTabControl.ResumeLayout(false);
            this.portfolioTab.ResumeLayout(false);
            this.portfolioTab.PerformLayout();
            this.panelManagerTab.ResumeLayout(false);
            this.panelManagerTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.TabControl stockTabControl;
        private System.Windows.Forms.TabPage portfolioTab;
        private System.Windows.Forms.TabPage panelManagerTab;
        private System.Windows.Forms.Label portfolioLabel;
        private System.Windows.Forms.CheckedListBox companyCheckedListBox;
        private System.Windows.Forms.Button savePortfolioButton;
        private System.Windows.Forms.Button loadPortfolioButton;
        private System.Windows.Forms.ListBox currentPanelListBox;
        private System.Windows.Forms.Label managePanelsLabel;
        private System.Windows.Forms.SaveFileDialog savePortfolioDialog;
        private System.Windows.Forms.OpenFileDialog loadPortfolioDialog;
        private System.Windows.Forms.ListBox stocksListBox;
        private System.Windows.Forms.Button removePanelButton;
        private System.Windows.Forms.ComboBox panelTypeComboBox;
        private System.Windows.Forms.Label newPanelLabel;
        private System.Windows.Forms.Button newPanelButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label newPanelTitle;
    }
}

