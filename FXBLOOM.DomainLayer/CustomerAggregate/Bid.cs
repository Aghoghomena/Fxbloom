using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class Bid :Entity<Guid>
    {
        public Guid CustomerId { get; private set; }
        public Currency Amount { get; private set; }
        public Guid ListingId { get; private set; }

        public Bid():base(Guid.NewGuid())
        {

        }
        internal static Bid AddBid(Guid listingId, BidDto bidDto)
        {
            // Add checks to ensure amount is not 0

            return new Bid
            {
                Amount = bidDto.Amount,
                CustomerId = bidDto.CustomerId
            };
        }
    }
}
