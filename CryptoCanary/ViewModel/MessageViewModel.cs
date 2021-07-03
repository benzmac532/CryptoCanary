using CryptoCanary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary.ViewModel
{
    public class MessageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MessageModel model;

        public MessageViewModel()
        {
            model = new MessageModel();
        }

        public void AddMessage(string message, LogLevels level)
        {
            model.AddMessage(message, level);
            OnPropertyChanged("Messages");
        }

        public ObservableCollection<Messages> Messages
        {
            get { return model.Messages; }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
