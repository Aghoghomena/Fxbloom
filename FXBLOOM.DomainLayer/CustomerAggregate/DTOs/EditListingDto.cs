using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class EditListingDto
    {
        //public CurrencyDto AmountAvailable { get; set; }
        public CurrencyDto AmountNeeded { get; set; }
        public Guid CustomerId { get; set; }

        public Decimal MinExchangeAmount { get; set; }
        public Decimal ExchangeRate { get; set; }

        public Guid Id { get; set; }
    }
}
