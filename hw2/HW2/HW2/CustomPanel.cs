using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    public abstract class CustomPanel // : Observer
    {
        
        private static UInt32 _nextPanelId = 0;
        public string Name { get; set; }
        protected List<Control> panelControls;
        protected List<Stock> stocks;
        protected CustomPanel(string panelName, List<Stock> panelStocks)
        {
            PanelId = GetNextId();
            Name = panelName;
            panelControls = new List<Control>();
            stocks = panelStocks;
        }

        public UInt32 PanelId {
            get;
            private set;
        }


        public abstract void Update();

        protected UInt32 GetNextId()
        {
            UInt32 nextId = _nextPanelId;
            if (_nextPanelId == UInt32.MaxValue)
                _nextPanelId = 1;
            else
                _nextPanelId++;
            return nextId;
        }

        public List<Control> GetControls() { return panelControls; }
    }
}
