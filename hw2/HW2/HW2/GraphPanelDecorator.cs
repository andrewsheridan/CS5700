
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace StockMonitor
{
    public delegate void ChangeTextDelegate(string newText);

    public abstract class
        GraphPanelDecorator : GraphPanel
    {
        private TextBox decoratorTextBox;
        private string TextBoxText;

        public void ChangeTextMethod(string text)
        {
            try
            {
                decoratorTextBox.Text = text;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ChangeTextDelegate TextChangeHandler;

        public GraphPanelDecorator(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            decoratorTextBox = new TextBox();
            decoratorTextBox.Location = new Point(50, 450);
            decoratorTextBox.Size = new Size(200, 50);
            panelControls.Add(decoratorTextBox);
            //TextBoxText = "Current ";
            //Binding newBinding = new Binding("Text", this, "TextBoxText");
            //decoratorTextBox.DataBindings.Add(newBinding);

        }


        
        protected void UpdateTextBox(string newText)
        {
            decoratorTextBox.Text = newText;
        }
        
        protected void UpdateTextBoxText(string newText)
        {
            TextBoxText = newText;
        }

        public override void Update() { }
    }
}
