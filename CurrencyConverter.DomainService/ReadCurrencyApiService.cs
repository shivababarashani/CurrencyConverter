using CurrencyConverter.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DomainService
{
    public class ReadCurrencyApiService : IReadCurrencyApiService
    {
        public Dictionary<string, float> GetCountryCurrencies()
        {
            string url = "https://v6.exchangerate-api.com/v6/56ecd5966905d230a53a0ee0/latest/USD";
            using (var client = new HttpClient())
            {

                var result = JsonConvert.DeserializeObject<ConversionRate>(client.GetStringAsync(url).Result);

                return result.conversion_rates;
            }
        }

        private sealed class ConversionRate
        {
            public Dictionary<string, float> conversion_rates { get; set; }
        }
    }
}
