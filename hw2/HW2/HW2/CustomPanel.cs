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
        public static int _nextPanelId = 1;

        public abstract List<Control> Create(List<Stock> stocks, string panelName, Form1 form);

        public abstract void Update(Stock stock);

        private int GetNextId()
        {
            int nextId = _nextPanelId;
            if (_nextPanelId == Int32.MaxValue)
                _nextPanelId = 1;
            else
                _nextPanelId++;
            return nextId;
        }
    }
}
