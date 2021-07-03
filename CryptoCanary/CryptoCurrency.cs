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
                CurrentPrice = (m.CurrentPrice != null) ? (decimal)m.CurrentPrice : 0;
                MarketCap = (m.MarketCap != null) ? (decimal)m.MarketCap : 0;
                TotalVolume = (m.TotalVolume != null) ? (decimal)m.TotalVolume : 0;
                PriceChangePercent1Hour = (m.PriceChangePercentage1HInCurrency != null) ? (decimal)m.PriceChangePercentage1HInCurrency : 0;
                PriceChangePercent24Hour = (m.PriceChangePercentage24H != null) ? (decimal)m.PriceChangePercentage24H : 0;
                PriceChangePercent7Day = (m.PriceChangePercentage7DInCurrency != null) ? (decimal)m.PriceChangePercentage7DInCurrency : 0;
                PriceChangePercent14Day = (m.PriceChangePercentage14DInCurrency != null) ? (decimal)m.PriceChangePercentage14DInCurrency : 0;
                PriceChangePercent30Day = (m.PriceChangePercentage30DInCurrency != null) ? (decimal)m.PriceChangePercentage30DInCurrency : 0;
                PriceChangePercent200Day = (m.PriceChangePercentage200DInCurrency != null) ? (decimal)m.PriceChangePercentage200DInCurrency : 0;
                PriceChangePercent1Year = (m.PriceChangePercentage1YInCurrency != null) ? (decimal)m.PriceChangePercentage1YInCurrency : 0;
                Low24Hour = (m.Low24H != null) ? (decimal)m.Low24H : 0;
                High24Hour = (m.High24H != null) ? (decimal)m.High24H : 0;
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
