using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class Listing : Entity<Guid>
    {
        
        public Currency AmountAvailable { get; private set; }
        public Currency AmountNeeded { get; private set; }
        private List<Bid> _bids;
        public IReadOnlyCollection<Bid> Bids => _bids;
        public DateTime DateCreated { get; private set; }
        public DateTime DateFinalized { get; private set; }
        public ListingStatus Status { get; private  set; }

        public Decimal MinExchangeAmount { get; private set; }
        public Decimal ExchangeRate { get; private set; }
        public Guid CustomerId { get; private set; }

        public Listing() : base(Guid.NewGuid())
        {
            _bids = new List<Bid>();
        }

        internal static Listing CreateListing(Guid customerId, ListingDto listingDto)
        {
            Listing listing = new Listing();

            return listing;
        }

        public IReadOnlyCollection<Bid> GetBids()
        {
            return Bids;
        }

        public ResponseModel AddBid(BidDto bid)
        {
            _ = bid ?? throw new ArgumentNullException($"{nameof(bid)} null object detected");
            ResponseModel response = new ResponseModel();
            if(bid.Amount == null || bid.CustomerId == default(Guid)) { response.Message = "Invalid Bid";
                                    response.Status = false; return response; }

            //if (bid.Amount.CurrencyType != AmountNeeded.CurrencyType) {
            //    response.Message = "Not expected currency";
            //    response.Status = false;
            //    return response;
            //}

            if (HasReachedBiddingLimit())
            {
                response.Message = "Bidding limit has been reached";
                response.Status = false;
                return response;
            }

            _bids.Add(Bid.AddBid(Id, bid));
            response.Status = true;
            response.Message = "Bid has been added successfully";
            return response;
        }

        public static Listing CreateListing(ListingDto listingDto)
        {
            Listing listing = new Listing();
            listing.AmountAvailable = Currency.CreateCurrency(listingDto.AmountAvailable);
            listing.AmountNeeded = Currency.CreateCurrency(listingDto.AmountNeeded);
            listing.CustomerId = listingDto.CustomerId;
            listing.DateCreated = System.DateTime.Now;
            listing.Status = ListingStatus.OPEN;
            listing.ExchangeRate = listingDto.ExchangeRate;
            listing.MinExchangeAmount = listingDto.MinExchangeAmount;

            return listing;
        }

        public void SetStatus(ListingStatus listingStatus)
        {
            Status = listingStatus;
        }

        public void RemoveBid(Guid customerId)
        {
            if (_bids.Any())
            {
                var bid = _bids.Where(e => e.CustomerId == customerId).FirstOrDefault();
                if (bid != null)
                    _bids.Remove(bid);
            }
        }

        public void EditListing(EditListingDto editListingDto)
        {

             AmountNeeded = Currency.CreateCurrency(editListingDto.AmountNeeded);
            CustomerId = editListingDto.CustomerId;
            ExchangeRate = editListingDto.ExchangeRate;
            MinExchangeAmount = editListingDto.MinExchangeAmount;


        }
        private bool HasReachedBiddingLimit()
        {
            if(Bids.Count < 2)
            {
                return false;
            }

            return true;
        }

        private bool HasActiveBidding()
        {
            if (Bids.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
