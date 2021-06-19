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
        internal static Bid AddBid(Guid listingId, BidDto bidDto, Guid customerId)
        {
            // Add checks to ensure amount is not 0

            return new Bid
            {
                Amount = Currency.CreateCurrency(bidDto.Amount),
                CustomerId = customerId
            };
        }

        internal static Bid createBid(BidDto bidDto, Guid customerId)
        {
            Bid bid = new Bid();
            bid.Amount = Currency.CreateCurrency(bidDto.Amount);
            bid.CustomerId  = customerId;
            bid.ListingId = bidDto.ListingId;

            return bid;
        }
    }
}
