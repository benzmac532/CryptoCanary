using CryptoCanary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoinGecko;
using CoinGecko.Clients;
using CoinGecko.Entities.Response;
using CoinGecko.Entities.Response.Coins;
using CryptoCanary.ViewModel;

namespace CryptoCanary
{
    public class APIDriver
    {
        public static async Task<ObservableCollection<OverviewModel>> GetOverviewInformation()
        {
            ObservableCollection<OverviewModel> collection = new ObservableCollection<OverviewModel>();
            CoinGeckoClient client = new CoinGeckoClient();
            int currentPage = 1;
            int totalNumberDesired = 300;
            int totalPerPage = 150;

            while((totalPerPage * currentPage) < totalNumberDesired)
            {
                IReadOnlyList<CoinMarkets> allCoins = await client.CoinsClient.GetCoinMarkets("usd", new string[0], "", totalPerPage, currentPage, false, "", "");

                foreach (CoinMarkets coinMarket in allCoins)
                {
                    OverviewModel m = new OverviewModel(coinMarket);
                    collection.Add(m);
                }

                currentPage++;
            }

            return collection;
        }

        public static async Task<DetailViewModel> GetDetailViewInformation(string ID)
        {
            ObservableCollection<DetailModel> collection = new ObservableCollection<DetailModel>();
            CoinGeckoClient client = new CoinGeckoClient();
            int currentPage = 1;
            int totalPerPage = 1;

            IReadOnlyList<CoinMarkets> coin = await client.CoinsClient.GetCoinMarkets("usd", new string[1] { ID } , "", totalPerPage, currentPage, false, "", "");
            DetailModel model = new DetailModel(coin[0]);
            DetailViewModel vm = new DetailViewModel(model);

            return vm;
        }
    }
}
