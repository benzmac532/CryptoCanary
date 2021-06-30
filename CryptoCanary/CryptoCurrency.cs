using CoinGecko.Entities.Response.Coins;
using CryptoCanary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCanary
{
    public class CryptoCurrency
    {
        public CryptoCurrency(CoinMarkets m)
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
                PriceChangePercent1Hour = (decimal)m.PriceChangePercentage1HInCurrency;
                PriceChangePercent24Hour = (decimal)m.PriceChangePercentage24H;
                PriceChangePercent7Day = (decimal)m.PriceChangePercentage7DInCurrency;
                PriceChangePercent14Day = (decimal)m.PriceChangePercentage14DInCurrency;
                PriceChangePercent30Day = (decimal)m.PriceChangePercentage30DInCurrency;
                PriceChangePercent200Day = (decimal)m.PriceChangePercentage200DInCurrency;
                PriceChangePercent1Year = (decimal)m.PriceChangePercentage1YInCurrency;
                Low24Hour = (decimal)m.Low24H;
                High24Hour = (decimal)m.High24H;
            }
        }

        public CryptoCurrency(OverviewModel o)
        {
            if (o != null)
            {
                ID = o.ID;
                ImageSource = o.ImageSource.ToString();
                Name = o.Name;
                Symbol = o.Symbol;
                CurrentPrice = (decimal)o.CurrentPrice;
                MarketCap = (decimal)o.MarketCap;
                TotalVolume = (decimal)o.TotalVolume;
            }
        }

        public string ID
        {
            get; set;
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

        public decimal PriceChangePercent1Hour
        {
            get; set;
        }

        public decimal PriceChangePercent24Hour
        {
            get; set;
        }

        public decimal PriceChangePercent7Day
        {
            get; set;
        }

        public decimal PriceChangePercent14Day
        {
            get; set;
        }

        public decimal PriceChangePercent30Day
        {
            get; set;
        }

        public decimal PriceChangePercent200Day
        {
            get; set;
        }

        public decimal PriceChangePercent1Year
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
    }
}
