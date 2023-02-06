using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterWeb.Models
{
    public class ExchangeItem
    {
        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }

        public double Result { get; set; }
    }
}
