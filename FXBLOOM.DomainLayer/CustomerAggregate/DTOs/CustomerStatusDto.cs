using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class CustomerStatusDto
    {
        public Guid CustomerId { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
    }
}
