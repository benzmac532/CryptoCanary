using CryptoCanary.ViewModel;
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

namespace CryptoCanary.View
{
    /// <summary>
    /// Interaction logic for OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        public event EventHandler<OverviewSelectedItemChangedEventArgs> OverviewViewSelectedItemChanged;

        public OverviewView()
        {
            InitializeComponent();
            OverviewViewModel vm = new OverviewViewModel();
            vm.ShowLoadingScreen += ShowProgressBar;
            vm.HideLoadingScreen += HideProgressBar;
            lvAllAssets.DataContext = vm;

        }        

        private void ShowProgressBar(object sender, EventArgs e)
        {
            spLoading.Visibility = Visibility.Visible;
            lvAllAssets.Visibility = Visibility.Collapsed;
            btnRefresh.Visibility = Visibility.Collapsed;
        }

        private void HideProgressBar(object sender, EventArgs e)
        {
            spLoading.Visibility = Visibility.Collapsed;
            lvAllAssets.Visibility = Visibility.Visible;
            btnRefresh.Visibility = Visibility.Visible;
        }

        private void lvAllAssets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            OverviewViewSelectedItemChanged?.Invoke(this, new OverviewSelectedItemChangedEventArgs(lv.SelectedItem));
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            OverviewViewModel vm = lvAllAssets.DataContext as OverviewViewModel;
            vm.RefreshData();
        }
    }
}
