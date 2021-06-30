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

namespace CryptoCanary
{
    public class APIDriver
    {
        public static async Task<ObservableCollection<OverviewModel>> GetOverviewInformation()
        {
            ObservableCollection<OverviewModel> collection = new ObservableCollection<OverviewModel>();
            CoinGeckoClient client = new CoinGeckoClient();
            int currentPage = 1;
            int totalNumberDesired = 1500;
            int totalPerPage = 250;

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
    }
}
