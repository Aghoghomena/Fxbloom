using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class EditListingDto
    {
        //public CurrencyDto AmountAvailable { get; set; }
        public CurrencyDto AmountNeeded { get; set; }

        public EditCurrencyDTO AmountAvailable { get; set; }
        //public Guid CustomerId { get; set; }

        public Decimal MinExchangeAmount { get; set; }

        [Required(ErrorMessage = "Exchange Rate is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid exchange Rate")]
        public Decimal ExchangeRate { get; set; }

        public Guid Id { get; set; }
    }
}
