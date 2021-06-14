using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class Currency:ValueObject<Currency>
    {
        public CurrencyType CurrencyType { get; private set; }

        public decimal Amount { get; private set; }

        internal static Currency CreateCurrency(CurrencyDto currencyDto)
        {
            Currency currency = new Currency();
            currency.CurrencyType = currencyDto.CurrencyType;
            currency.Amount = currencyDto.Amount;

            return currency;
        }

        internal void UpdateAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}
