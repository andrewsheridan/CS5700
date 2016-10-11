
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace StockMonitor
{
    public abstract class
        GraphPanelDecorator : GraphPanel
    {
        protected TextBox decoratorTextBox;
        public GraphPanelDecorator(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            decoratorTextBox = new TextBox();
            decoratorTextBox.ReadOnly = true;
            decoratorTextBox.Location = new Point(50, 450);
            decoratorTextBox.Size = new Size(200, 50);
            panelControls.Add(decoratorTextBox);
        }

        protected void UpdateTextBox(string newText)
        {
            //decoratorTextBox.ReadOnly = false;
            decoratorTextBox.Text = newText;
            //decoratorTextBox.ReadOnly = true;
        }

        public override void Update() { }
    }
}
