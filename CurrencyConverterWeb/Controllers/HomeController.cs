using CurrencyConverter.Contract.Interfaces;
using CurrencyConverter.DomainService.HostedService;
using CurrencyConverter.Services;
using CurrencyConverterWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyConverterService _currencyConverter;

        public HomeController(ILogger<HomeController> logger, ICurrencyConverterService currencyConverter)
        {
            _logger = logger;
            _currencyConverter = currencyConverter;
        }

        public IActionResult Index()
        {
            TempData["Countries"] = GetCountries();
            return View(new ExchangeItem());
        }

        [HttpPost]
        public IActionResult Index(ExchangeItem model)
        {
            TempData["Countries"] = GetCountries();

            _currencyConverter.UpdateConfiguration(new List<Tuple<string, string, double>> { new Tuple<string, string, double>(model.From, model.To, 0) }.AsEnumerable());

            model.Result = _currencyConverter.Convert(model.From, model.To, model.Amount);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
        private List<Country> GetCountries()
        {
            var list = new List<Country>();
            list.Add(new Country { Name = "USD" });
            list.Add(new Country { Name = "AED" });
            list.Add(new Country { Name = "AFN" });
            list.Add(new Country { Name = "ALL" });
            list.Add(new Country { Name = "AMD" });
            list.Add(new Country { Name = "ANG" });
            list.Add(new Country { Name = "AOA" });
            list.Add(new Country { Name = "ARS" });
            list.Add(new Country { Name = "AUD" });
            list.Add(new Country { Name = "AWG" });
            list.Add(new Country { Name = "AZN" });
            list.Add(new Country { Name = "BAM" });
            list.Add(new Country { Name = "BBD" });
            list.Add(new Country { Name = "BDT" });
            list.Add(new Country { Name = "BGN" });
            list.Add(new Country { Name = "BHD" });
            list.Add(new Country { Name = "BIF" });
            list.Add(new Country { Name = "BMD" });
            list.Add(new Country { Name = "BND" });
            list.Add(new Country { Name = "BOB" });
            list.Add(new Country { Name = "BRL" });
            list.Add(new Country { Name = "BSD" });
            list.Add(new Country { Name = "BTN" });
            list.Add(new Country { Name = "BWP" });
            list.Add(new Country { Name = "BYN" });
            list.Add(new Country { Name = "BZD" });
            list.Add(new Country { Name = "CAD" });
            list.Add(new Country { Name = "CDF" });
            list.Add(new Country { Name = "CHF" });
            list.Add(new Country { Name = "CLP" });
            list.Add(new Country { Name = "CNY" });
            list.Add(new Country { Name = "COP" });
            list.Add(new Country { Name = "CRC" });
            list.Add(new Country { Name = "CUP" });
            list.Add(new Country { Name = "CVE" });
            list.Add(new Country { Name = "CZK" });
            list.Add(new Country { Name = "DJF" });
            list.Add(new Country { Name = "DKK" });
            list.Add(new Country { Name = "DOP" });
            list.Add(new Country { Name = "DZD" });
            list.Add(new Country { Name = "EGP" });
            list.Add(new Country { Name = "ERN" });
            list.Add(new Country { Name = "ETB" });
            list.Add(new Country { Name = "EUR" });
            list.Add(new Country { Name = "FJD" });
            list.Add(new Country { Name = "FKP" });
            list.Add(new Country { Name = "FOK" });
            list.Add(new Country { Name = "GBP" });
            list.Add(new Country { Name = "GEL" });
            list.Add(new Country { Name = "GGP" });
            list.Add(new Country { Name = "GHS" });
            list.Add(new Country { Name = "GIP" });
            list.Add(new Country { Name = "GMD" });
            list.Add(new Country { Name = "GNF" });
            list.Add(new Country { Name = "GTQ" });
            list.Add(new Country { Name = "GYD" });
            list.Add(new Country { Name = "HKD" });
            list.Add(new Country { Name = "HNL" });
            list.Add(new Country { Name = "HRK" });
            list.Add(new Country { Name = "HTG" });
            list.Add(new Country { Name = "HUF" });
            list.Add(new Country { Name = "IDR" });
            list.Add(new Country { Name = "ILS" });
            list.Add(new Country { Name = "IMP" });
            list.Add(new Country { Name = "INR" });
            list.Add(new Country { Name = "IQD" });
            list.Add(new Country { Name = "IRR" });
            list.Add(new Country { Name = "ISK" });
            list.Add(new Country { Name = "JEP" });
            list.Add(new Country { Name = "JMD" });
            list.Add(new Country { Name = "JOD" });
            list.Add(new Country { Name = "JPY" });
            list.Add(new Country { Name = "KES" });
            list.Add(new Country { Name = "KGS" });
            list.Add(new Country { Name = "KHR" });
            list.Add(new Country { Name = "KID" });
            list.Add(new Country { Name = "KMF" });
            list.Add(new Country { Name = "KRW" });
            list.Add(new Country { Name = "KWD" });
            list.Add(new Country { Name = "KYD" });
            list.Add(new Country { Name = "KZT" });
            list.Add(new Country { Name = "LAK" });
            list.Add(new Country { Name = "LBP" });
            list.Add(new Country { Name = "LKR" });
            list.Add(new Country { Name = "LRD" });
            list.Add(new Country { Name = "LSL" });
            list.Add(new Country { Name = "LYD" });
            list.Add(new Country { Name = "MAD" });
            list.Add(new Country { Name = "MDL" });
            list.Add(new Country { Name = "MGA" });
            list.Add(new Country { Name = "MKD" });
            list.Add(new Country { Name = "MMK" });
            list.Add(new Country { Name = "MNT" });
            list.Add(new Country { Name = "MOP" });
            list.Add(new Country { Name = "MRU" });
            list.Add(new Country { Name = "MUR" });
            list.Add(new Country { Name = "MVR" });
            list.Add(new Country { Name = "MWK" });
            list.Add(new Country { Name = "MXN" });
            list.Add(new Country { Name = "MYR" });
            list.Add(new Country { Name = "MZN" });
            list.Add(new Country { Name = "NAD" });
            list.Add(new Country { Name = "NGN" });
            list.Add(new Country { Name = "NIO" });
            list.Add(new Country { Name = "NOK" });
            list.Add(new Country { Name = "NPR" });
            list.Add(new Country { Name = "NZD" });
            list.Add(new Country { Name = "OMR" });
            list.Add(new Country { Name = "PAB" });
            list.Add(new Country { Name = "PEN" });
            list.Add(new Country { Name = "PGK" });
            list.Add(new Country { Name = "PHP" });
            list.Add(new Country { Name = "PKR" });
            list.Add(new Country { Name = "PLN" });
            list.Add(new Country { Name = "PYG" });
            list.Add(new Country { Name = "QAR" });
            list.Add(new Country { Name = "RON" });
            list.Add(new Country { Name = "RSD" });
            list.Add(new Country { Name = "RUB" });
            list.Add(new Country { Name = "RWF" });
            list.Add(new Country { Name = "SAR" });
            list.Add(new Country { Name = "SBD" });
            list.Add(new Country { Name = "SCR" });
            list.Add(new Country { Name = "SDG" });
            list.Add(new Country { Name = "SEK" });
            list.Add(new Country { Name = "SGD" });
            list.Add(new Country { Name = "SHP" });
            list.Add(new Country { Name = "SLE" });
            list.Add(new Country { Name = "SLL" });
            list.Add(new Country { Name = "SOS" });
            list.Add(new Country { Name = "SRD" });
            list.Add(new Country { Name = "SSP" });
            list.Add(new Country { Name = "STN" });
            list.Add(new Country { Name = "SYP" });
            list.Add(new Country { Name = "SZL" });
            list.Add(new Country { Name = "THB" });
            list.Add(new Country { Name = "TJS" });
            list.Add(new Country { Name = "TMT" });
            list.Add(new Country { Name = "TND" });
            list.Add(new Country { Name = "TOP" });
            list.Add(new Country { Name = "TRY" });
            list.Add(new Country { Name = "TTD" });
            list.Add(new Country { Name = "TVD" });
            list.Add(new Country { Name = "TWD" });
            list.Add(new Country { Name = "TZS" });
            list.Add(new Country { Name = "UAH" });
            list.Add(new Country { Name = "UGX" });
            list.Add(new Country { Name = "UYU" });
            list.Add(new Country { Name = "UZS" });
            list.Add(new Country { Name = "VES" });
            list.Add(new Country { Name = "VND" });
            list.Add(new Country { Name = "VUV" });
            list.Add(new Country { Name = "WST" });
            list.Add(new Country { Name = "XAF" });
            list.Add(new Country { Name = "XCD" });
            list.Add(new Country { Name = "XDR" });
            list.Add(new Country { Name = "XOF" });
            list.Add(new Country { Name = "XPF" });
            list.Add(new Country { Name = "YER" });
            list.Add(new Country { Name = "ZAR" });
            list.Add(new Country { Name = "ZMW" });
            list.Add(new Country { Name = "ZWL" });

            return list;
        }
    }
}
