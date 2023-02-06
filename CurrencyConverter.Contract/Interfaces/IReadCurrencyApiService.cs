using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Contract.Interfaces
{
    public interface IReadCurrencyApiService 
    {
        Dictionary<string, float>   GetCountryCurrencies();
    }
}
