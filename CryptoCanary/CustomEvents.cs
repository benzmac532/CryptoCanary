using CryptoCanary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary
{
    public class OverviewSelectedItemChangedEventArgs : EventArgs
    {
        public CryptoCurrency selectedItem;

        public OverviewSelectedItemChangedEventArgs(object o)
        {
            selectedItem = new CryptoCurrency(o as OverviewModel);
        }
    }

    public class LoggerMessageArgs : EventArgs
    {
        public string Message;
        public LogLevels Level;

        public LoggerMessageArgs(string message, LogLevels level)
        {
            Message = message;
            Level = level;
        }
    }
}
