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
    /// Interaction logic for DetailView.xaml
    /// </summary>
    public partial class DetailView : UserControl
    {
        public DetailView()
        {
            InitializeComponent();
            DataContext = new DetailViewModel();
        }

        public void RegisterToOverviewItemChange(OverviewView view)
        {
            view.OverviewViewSelectedItemChanged += OverviewItemChanged;
        }

        private void OverviewItemChanged(object sender, OverviewSelectedItemChangedEventArgs e)
        {
            DetailViewModel model = DataContext as DetailViewModel;
            CryptoCurrency c = e.selectedItem;

            model.Name = c.Name;
            model.Symbol = c.Symbol;
            model.ImageSource = c.ImageSource;
        }
    }
}
