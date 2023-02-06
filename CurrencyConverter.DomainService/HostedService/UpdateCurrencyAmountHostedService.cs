using CurrencyConverter.Contract.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.DomainService.HostedService
{
    public class UpdateCurrencyAmountHostedService : IUpdateCurrencyAmountHostedService
    {
        private Timer _timer;
        private IReadCurrencyApiService _readCurrencyApiService;

        public UpdateCurrencyAmountHostedService(IReadCurrencyApiService readCurrencyApiService)
        {
            _readCurrencyApiService = readCurrencyApiService;
            CurrencyRates = new Dictionary<string, float>();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoSomething, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void DoSomething(object state)
        {
            CurrencyRates = _readCurrencyApiService.GetCountryCurrencies();
        }



        public override void Dispose()
        {
            _timer.Dispose();
        }
    }
}
