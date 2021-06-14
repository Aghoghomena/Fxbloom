using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }

        public AccountType AccountType { get; set; }
    }
}
