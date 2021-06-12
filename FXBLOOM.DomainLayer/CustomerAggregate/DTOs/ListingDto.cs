﻿using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class ListingDto
    {

        public CurrencyDto AmountAvailable { get;  set; }
        public CurrencyDto AmountNeeded { get;  set; }
        public Guid CustomerId { get; set; }

        public Decimal MinExchangeAmount { get; set; }
        public Decimal ExchangeRate { get; set; }
    }
}
