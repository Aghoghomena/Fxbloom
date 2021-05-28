using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class BidDto
    {
        public Guid CustomerId { get; set; }
        public Currency Amount { get; set; }
    }
}
