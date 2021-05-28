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

        public int Id { get; set; }

        internal static Currency CreateCurrency(CurrencyType type, decimal amount)
        {
            Currency currency = new Currency();
            currency.CurrencyType = type;
            currency.Amount = amount;

            return currency;
        }

        internal void UpdateAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}
