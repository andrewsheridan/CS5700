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
            this.currentPanelListBox = new System.Windows.Forms.ListBox();
            this.managePanelsLabel = new System.Windows.Forms.Label();
            this.savePortfolioDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadPortfolioDialog = new System.Windows.Forms.OpenFileDialog();
            this.stockTabControl.SuspendLayout();
            this.portfolioTab.SuspendLayout();
            this.panelManagerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockTabControl
            // 
            this.stockTabControl.Controls.Add(this.portfolioTab);
            this.stockTabControl.Controls.Add(this.panelManagerTab);
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
            this.portfolioLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelManagerTab
            // 
            this.panelManagerTab.Controls.Add(this.currentPanelListBox);
            this.panelManagerTab.Controls.Add(this.managePanelsLabel);
            this.panelManagerTab.Location = new System.Drawing.Point(4, 22);
            this.panelManagerTab.Name = "panelManagerTab";
            this.panelManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.panelManagerTab.Size = new System.Drawing.Size(289, 511);
            this.panelManagerTab.TabIndex = 1;
            this.panelManagerTab.Text = "Panels";
            this.panelManagerTab.UseVisualStyleBackColor = true;
            // 
            // currentPanelListBox
            // 
            this.currentPanelListBox.FormattingEnabled = true;
            this.currentPanelListBox.Location = new System.Drawing.Point(41, 65);
            this.currentPanelListBox.Name = "currentPanelListBox";
            this.currentPanelListBox.Size = new System.Drawing.Size(211, 160);
            this.currentPanelListBox.TabIndex = 1;
            // 
            // managePanelsLabel
            // 
            this.managePanelsLabel.AutoSize = true;
            this.managePanelsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managePanelsLabel.Location = new System.Drawing.Point(36, 20);
            this.managePanelsLabel.Name = "managePanelsLabel";
            this.managePanelsLabel.Size = new System.Drawing.Size(216, 26);
            this.managePanelsLabel.TabIndex = 0;
            this.managePanelsLabel.Text = "Manage Your Panels";
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
    }
}

