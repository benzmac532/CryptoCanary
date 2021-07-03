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
        private const int TOTAL_NUMBER_TO_GET = 25;// 300;
        private const int TOTAL_PER_PAGE = 10; //150;

        public static async Task<ObservableCollection<OverviewModel>> GetOverviewInformation()
        {
            ObservableCollection<OverviewModel> collection = new ObservableCollection<OverviewModel>();
            CoinGeckoClient client = new CoinGeckoClient();
            int currentPage = 1;

            while((TOTAL_PER_PAGE * currentPage) < TOTAL_NUMBER_TO_GET)
            {
                IReadOnlyList<CoinMarkets> allCoins = await client.CoinsClient.GetCoinMarkets("usd", new string[0], "", TOTAL_PER_PAGE, currentPage, false, "", "");

                foreach (CoinMarkets coinMarket in allCoins)
                {
                    OverviewModel m = new OverviewModel(coinMarket);
                    collection.Add(m);
                }

                currentPage++;
            }

            return collection;
        }

        public static async Task<ObservableCollection<CryptoCurrency>> GetCurrentCryptocurrencyList()
        {
            ObservableCollection<CryptoCurrency> cryptoList = new ObservableCollection<CryptoCurrency>();
            CoinGeckoClient client = new CoinGeckoClient();
            int currentPage = 1;

            while ((TOTAL_PER_PAGE * currentPage) < TOTAL_NUMBER_TO_GET)
            {
                IReadOnlyList<CoinMarkets> allCoins = await client.CoinsClient.GetCoinMarkets("usd", new string[0], "", TOTAL_PER_PAGE, currentPage, false, "", "");

                foreach (CoinMarkets coinMarket in allCoins)
                {
                    cryptoList.Add(new CryptoCurrency(coinMarket));
                }

                currentPage++;
            }

            return cryptoList;
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

        public static async Task<CryptoCurrency> GetSpecificCrypto(string ID)
        {
            ObservableCollection<CryptoCurrency> collection = new ObservableCollection<CryptoCurrency>();
            CoinGeckoClient client = new CoinGeckoClient();
            int currentPage = 1;
            int totalPerPage = 1;

            IReadOnlyList<CoinMarkets> coin = await client.CoinsClient.GetCoinMarkets("usd", new string[1] { ID }, "", totalPerPage, currentPage, false, "", "");
            CryptoCurrency c = new CryptoCurrency(coin[0]);

            return c;
        }
    }
}
