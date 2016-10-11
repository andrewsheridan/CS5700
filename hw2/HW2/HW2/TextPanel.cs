using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    public class TextPanel : CustomPanel
    {
        public TextPanel(string panelName, List<Stock> stocks) : base(panelName, stocks)
        {
            RichTextBox newBox = new RichTextBox();
            newBox.Location = new System.Drawing.Point(10, 50);
            newBox.Name = panelName;
            newBox.Size = new System.Drawing.Size(271, 447);
            System.Drawing.Font boldFont = new System.Drawing.Font("VVerdana", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, false);
            newBox.Text = "Stock \t Current \t Bid \t Ask" + System.Environment.NewLine;
            newBox.Enabled = false;
            panelControls.Add(newBox);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

}
