﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMonitor
{
    public abstract class CustomPanel : StockObserver
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
            foreach(Stock s in stocks)
            {
                s.Subscribe(this);
            }
        }

        public UInt32 PanelId {
            get;
            private set;
        }

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

        public abstract void UpdatePanel();

        public void Delete()
        {
            foreach(Stock s in stocks)
            {
                s.Unsubscribe(this);
            }
            foreach(Control c in panelControls)
            {
                c.Dispose();
            }
        }

        public void Update()
        {
            UpdatePanel();
        }

        public bool ContainsStock(Stock s)
        {
            int index = stocks.FindIndex(x => x.Symbol == s.Symbol);
            if(index >=0 && index < stocks.Count)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool ContainsStock(string symbol)
        {
            int index = stocks.FindIndex(x => x.Symbol == symbol);
            if (index >= 0 && index < stocks.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
