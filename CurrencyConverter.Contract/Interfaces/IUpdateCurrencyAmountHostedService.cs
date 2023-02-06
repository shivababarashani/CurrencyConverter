using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.Contract.Interfaces
{
    public abstract class IUpdateCurrencyAmountHostedService : IHostedService, IDisposable
    {

        public Dictionary<string, float> CurrencyRates;
        public virtual void Dispose() => throw new NotImplementedException();
        public virtual Task StartAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        public virtual Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
