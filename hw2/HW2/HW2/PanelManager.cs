using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    public class PanelManager
    {
        private Form form;
        public PanelManager(Form f)
        {
            form = f;
        }
        
        List<Panel> Panels { get; set; }

        //public void createPanel(PanelType panelType, string panelName, List<string> stockNames)
        //{
        //    //Create new tab.
        //    //Create new panel.
        //    //Create title for panel.
        //    // Add additional components in the decorators.
        //    Panel newPanel = new Panel();

        //    newPanel.Name = panelName;

        //}
    }
}
