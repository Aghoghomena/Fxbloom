using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class ListingDto
    {

        public CurrencyDto AmountAvailable { get;  set; }
        public CurrencyDto AmountNeeded { get;  set; }

        public decimal MinExchangeAmount { get; set; }

        [Required(ErrorMessage = "Exchange Rate is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid exchange Rate")]
        public decimal ExchangeRate { get; set; }

    }
}
