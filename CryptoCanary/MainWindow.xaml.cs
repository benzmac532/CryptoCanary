using System;
using System.Collections.Generic;
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

using CoinGecko;
using CoinGecko.Clients;
using CoinGecko.Entities.Response;
using CoinGecko.Entities.Response.Coins;
using CryptoCanary.ViewModel;

namespace CryptoCanary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!DatabaseDriver.DatabaseExists())
            {
                DatabaseDriver.CreateInitialDatabase();
            }

            vwDetail.RegisterToOverviewItemChange(vwOverview);
        }

        private void btnOverview_Click(object sender, RoutedEventArgs e)
        {
            vwOverview.Visibility = Visibility.Visible;
            vwDetail.Visibility = Visibility.Visible;
        }

        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            vwOverview.Visibility = Visibility.Collapsed;
            vwDetail.Visibility = Visibility.Visible;
        }

        private void btnDiscover_Click(object sender, RoutedEventArgs e)
        {
            vwOverview.Visibility = Visibility.Collapsed;
            vwDetail.Visibility = Visibility.Collapsed;
        }
    }
}
