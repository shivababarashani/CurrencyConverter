using CurrencyConverter.Contract.Interfaces;
using CurrencyConverter.DomainService.HostedService;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private readonly IUpdateCurrencyAmountHostedService _updateCurrencyAmountHostedService;
        private IEnumerable<Tuple<string, string, double>> currencyRateResult;

        public CurrencyConverterService(IUpdateCurrencyAmountHostedService updateCurrencyAmountHostedService)
        {
            _updateCurrencyAmountHostedService = updateCurrencyAmountHostedService as UpdateCurrencyAmountHostedService;
     
            ClearConfiguration();
        }

        public void ClearConfiguration()
        {
            _updateCurrencyAmountHostedService.StopAsync(new System.Threading.CancellationToken());
            _updateCurrencyAmountHostedService.StartAsync(new System.Threading.CancellationToken());
            currencyRateResult = Enumerable.Empty<Tuple<string, string, double>>();
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {
            var rateValue = currencyRateResult.FirstOrDefault(i => i.Item1 == fromCurrency && i.Item2 == toCurrency)?.Item3;
            if (rateValue.HasValue)
            {
                return amount * rateValue.Value;
            }

            return -1;
        }

        public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
        {

            var except = currencyRateResult.Except(conversionRates);

            currencyRateResult = _updateCurrencyAmountHostedService.CurrencyRates.Where(item => conversionRates.Select(i => i.Item1).Contains(item.Key)).AsParallel().
                                 SelectMany(item => _updateCurrencyAmountHostedService.CurrencyRates.Where(c => conversionRates.Select(i => i.Item2).Contains(c.Key)),
                                                    (l1, l2) => new Tuple<string, string, double>(l1.Key, l2.Key, (l2.Value / l1.Value))).AsEnumerable().Union(except).ToList();


        }

    }
}
