using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary.Model
{
    public class MessageModel
    {
        public ObservableCollection<Messages> Messages;

        public MessageModel()
        {
            Messages = new ObservableCollection<Messages>();
        }

        public void AddMessage(string message, LogLevels level)
        {
            Messages.Add(new Model.Messages(message, level));
        }
    }

    public class Messages
    {
        public Messages(string message, LogLevels level)
        {
            Message = message;
            Level = level;
        }

        public string Message
        {
            get; set;
        }

        public LogLevels Level
        {
            get; set;
        }
    }
}
