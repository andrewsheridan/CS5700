
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace StockMonitor
{
    delegate void ChangeTextDelegate(string newText);

    public abstract class
        GraphPanelDecorator : GraphPanel
    {
        protected TextBox decoratorTextBox;

        public GraphPanelDecorator(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            decoratorTextBox = new TextBox();
            decoratorTextBox.Location = new Point(50, 450);
            decoratorTextBox.Size = new Size(200, 50);
            panelControls.Add(decoratorTextBox);
        }

        
        protected void UpdateTextBox(string newText)
        {
            decoratorTextBox.Text = newText;
        }
        

        public override void Update() { }
    }
}
