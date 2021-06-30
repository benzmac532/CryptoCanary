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
    public class OverviewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<OverviewModel> overviewInformation = new ObservableCollection<OverviewModel>();
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ShowLoadingScreen;
        public event EventHandler HideLoadingScreen;

        public OverviewViewModel()
        {
            RetrieveCurrentData();
        }

        public void RefreshData()
        {
            RetrieveCurrentData();
        }

        private async void RetrieveCurrentData()
        {
            ShowLoadingScreen?.Invoke(this, new EventArgs());
            OverviewInformation = await APIDriver.GetOverviewInformation();
            HideLoadingScreen?.Invoke(this, new EventArgs());
        }

        public ObservableCollection<OverviewModel> OverviewInformation
        {
            get { return overviewInformation; }
            set
            {
                overviewInformation = value;
                OnPropertyChanged("OverviewInformation");
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
