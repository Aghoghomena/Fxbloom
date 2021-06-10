using System;
using System.Collections.Generic;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class ListingDto
    {

        public Currency AmountAvailable { get; private set; }
        public Currency AmountNeeded { get; private set; }
        public DateTime DateCreated { get; private set; } = System.DateTime.Now;
        public DateTime? DateFinalized { get; private set; }
        public ListingStatus Status { get; private set; }
        public Guid CustomerId { get; private set; }
    }
}
