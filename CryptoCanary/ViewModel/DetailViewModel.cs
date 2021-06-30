using CryptoCanary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        private DetailModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        public DetailViewModel()
        {
            model = new DetailModel();
        }

        public string ImageSource
        {
            get
            {
                return model.ImageSource;
            }
            set
            {
                model.ImageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        public string Name
        {
            get { return model.Name; }
            set
            {
                model.Name = value;
                OnPropertyChanged("FullName");
            }
        }

        public string Symbol
        {
            get { return model.Symbol; }
            set
            {
                model.Symbol = value;
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get
            {
                if(string.IsNullOrEmpty(model.Name) && string.IsNullOrEmpty(model.Symbol))
                {
                    return "";
                }
                return model.Name + " (" + model.Symbol + ")";
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
