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

        public DetailViewModel(DetailModel newModel)
        {
            model = newModel;
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

        public string ImageSource
        {
            get { return model.ImageSource; }
            set
            {
                model.ImageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        public string ID
        {
            get { return model.Name; }
            set
            {
                model.Name = value;
                OnPropertyChanged("ID");
            }
        }

        public decimal CurrentPrice
        {
            get { return model.CurrentPrice; }
            set
            {
                model.CurrentPrice = value;
                OnPropertyChanged("CurrentPrice");
            }
        }

        public decimal MarketCap
        {
            get { return model.MarketCap; }
            set
            {
                model.MarketCap = value;
                OnPropertyChanged("MarketCap");
            }
        }

        public long MarketCapRank
        {
            get { return model.MarketCapRank; }
            set
            {
                model.MarketCapRank = value;
                OnPropertyChanged("MarketCapRank");
            }
        }

        public decimal TotalVolume
        {
            get { return model.TotalVolume; }
            set
            {
                model.TotalVolume = value;
                OnPropertyChanged("TotalVolume");
            }
        }

        public decimal Low24Hour
        {
            get { return model.Low24Hour; }
            set
            {
                model.Low24Hour = value;
                OnPropertyChanged("Low24Hour");
            }
        }

        public decimal High24Hour
        {
            get { return model.High24Hour; }
            set
            {
                model.High24Hour = value;
                OnPropertyChanged("High24Hour");
            }
        }

        public decimal PriceChange24Hour
        {
            get { return model.PriceChange24Hour; }
            set
            {
                model.PriceChange24Hour = value;
                OnPropertyChanged("PriceChange24Hour");
            }
        }

        public decimal PriceChangePercentage24Hour
        {
            get { return model.PriceChangePercentage24Hour; }
            set
            {
                model.PriceChangePercentage24Hour = value;
                OnPropertyChanged("PriceChangePercentage24Hour");
            }
        }

        public decimal MarketCapChange24Hour
        {
            get { return model.MarketCapChange24Hour; }
            set
            {
                model.MarketCapChange24Hour = value;
                OnPropertyChanged("MarketCapChange24Hour");
            }
        }

        public decimal MarketCapChangePercentage24Hour
        {
            get { return model.MarketCapChangePercentage24Hour; }
            set
            {
                model.MarketCapChangePercentage24Hour = value;
                OnPropertyChanged("MarketCapChangePercentage24Hour");
            }
        }

        public string CirculatingSupply
        {
            get { return model.CirculatingSupply; }
            set
            {
                model.CirculatingSupply = value;
                OnPropertyChanged("CirculatingSupply");
            }
        }

        public decimal TotalSupply
        {
            get { return model.TotalSupply; }
            set
            {
                model.TotalSupply = value;
                OnPropertyChanged("TotalSupply");
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
