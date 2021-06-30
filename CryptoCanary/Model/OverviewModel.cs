using CoinGecko.Entities.Response.Coins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary.Model
{
    public class OverviewModel
    {
        public OverviewModel(CoinMarkets m)
        {
            ID = m.Id;
            ImageSource = m.Image.ToString();
            Name = m.Name;
            Symbol = m.Symbol;
            CurrentPrice = (decimal)m.CurrentPrice;
            MarketCap = (decimal)m.MarketCap;
            TotalVolume = (decimal)m.TotalVolume;
        }

        public string ImageSource
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Symbol
        {
            get; set;
        }

        public decimal CurrentPrice
        {
            get; set;
        }

        public decimal MarketCap
        {
            get; set;
        }

        public decimal TotalVolume
        {
            get; set;
        }

        public string ID
        {
            get; set;
        }

    }
}
