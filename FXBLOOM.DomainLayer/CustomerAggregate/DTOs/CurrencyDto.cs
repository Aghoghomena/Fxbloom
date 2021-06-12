using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class CurrencyDto
    {
        public CurrencyType CurrencyType { get; set; }

        public decimal Amount { get; set; }
    }
}
