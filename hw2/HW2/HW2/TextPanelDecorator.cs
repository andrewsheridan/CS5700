using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace StockMonitor
{
    public abstract class TextPanelDecorator : CustomPanel
    {
        protected RichTextBox richTextBox;

        public TextPanelDecorator(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            richTextBox = new RichTextBox();
            richTextBox.Location = new System.Drawing.Point(10, 50);
            richTextBox.Name = panelName;
            richTextBox.Size = new System.Drawing.Size(271, 447);

            richTextBox.ReadOnly = true ;
            richTextBox.Font = new Font("Georgia", 12);
            panelControls.Add(richTextBox);
        }

        public void UpdateRichTextBox(string header, List<String> entries)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action(() => SetRichText(header, entries)));
            }
            else
            {
                SetRichText(header, entries);
            }
        }

        private void SetRichText(string header, List<String> entries)
        {
            richTextBox.Text = header;
            foreach(String entry in entries)
            {
                richTextBox.Text += entry;
            }
        }
    }

}
