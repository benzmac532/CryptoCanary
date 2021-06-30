using CoinGecko.Entities.Response.Coins;
using CryptoCanary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCanary.View
{
    /// <summary>
    /// Interaction logic for DetailView.xaml
    /// </summary>
    public partial class DetailView : UserControl
    {
        private Dictionary<string, DetailViewModel> seenCryptos = new Dictionary<string, DetailViewModel>();

        public DetailView()
        {
            InitializeComponent();
        }

        public void ClearSeenCryptos(object sender, EventArgs e)
        {
            seenCryptos.Clear();
        }

        public void RegisterToOverviewItemChange(OverviewView view)
        {
            view.OverviewViewSelectedItemChanged += OverviewItemChanged;
        }

        public void RegisterToRefreshCryptos(OverviewView view)
        {
            view.RefreshCryptos += ClearSeenCryptos;
        }

        private void OverviewItemChanged(object sender, OverviewSelectedItemChangedEventArgs e)
        {
            GetDetailInformation(e.selectedItem as CryptoCurrency);
        }

        private async void GetDetailInformation(CryptoCurrency c)
        {
            if(c != null && !string.IsNullOrEmpty(c.ID))
            {
                if (!seenCryptos.ContainsKey(c.ID))
                {
                    DataContext = await APIDriver.GetDetailViewInformation(c.ID);
                    seenCryptos.Add(c.ID, DataContext as DetailViewModel);
                }
                else
                {
                    DataContext = seenCryptos[c.ID];
                }
            }
        }
    }
}
