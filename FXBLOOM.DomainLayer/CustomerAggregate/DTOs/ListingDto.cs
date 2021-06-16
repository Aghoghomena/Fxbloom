using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class ListingDto
    {

        public CurrencyDto AmountAvailable { get;  set; }
        public CurrencyDto AmountNeeded { get;  set; }
        public decimal MinExchangeAmount { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
