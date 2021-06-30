using CoinGecko.Entities.Response.Coins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary.Model
{
    public  class DetailModel
    {
        public DetailModel()
        {

        }

        public DetailModel(CoinMarkets m)
        {
            if (m != null)
            {
                ID = m.Id;
                ImageSource = m.Image.ToString();
                Name = m.Name;
                Symbol = m.Symbol;
                CurrentPrice = (decimal)m.CurrentPrice;
                MarketCap = (decimal)m.MarketCap;
                TotalVolume = (decimal)m.TotalVolume;
                MarketCapRank = (long)m.MarketCapRank;
                Low24Hour = (decimal)m.Low24H;
                High24Hour = (decimal)m.High24H;
                PriceChange24Hour = (decimal)m.PriceChange24H;
                PriceChangePercentage24Hour = (decimal)m.PriceChangePercentage24H;
                MarketCapChange24Hour = (decimal)m.MarketCapChange24H;
                MarketCapChangePercentage24Hour = (decimal)m.MarketCapChangePercentage24H;
                CirculatingSupply = m.CirculatingSupply;
                TotalSupply = (m.TotalSupply == null) ? decimal.MaxValue : (decimal)m.TotalSupply;                
            }
        }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Symbol))
                {
                    return "";
                }
                return Name + " (" + Symbol + ")";
            }
        }

        public string ImageSource
        {
            get; set;
        }

        public string ID
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

        public long MarketCapRank
        {
            get; set;
        }

        public decimal TotalVolume
        {
            get; set;
        }

        public decimal Low24Hour
        {
            get; set;
        }

        public decimal High24Hour
        {
            get; set;
        }

        public decimal PriceChange24Hour
        {
            get; set;
        }

        public decimal PriceChangePercentage24Hour
        {
            get; set;
        }

        public decimal MarketCapChange24Hour
        {
            get; set;
        }

        public decimal MarketCapChangePercentage24Hour
        {
            get; set;
        }

        public string CirculatingSupply
        {
            get; set;
        }

        public decimal TotalSupply
        {
            get; set;
        }
    }
}
