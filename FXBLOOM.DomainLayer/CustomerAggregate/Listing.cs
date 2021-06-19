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
            listing.AmountAvailable = Currency.CreateCurrency(listingDto.AmountAvailable);
            listing.AmountNeeded = Currency.CreateCurrency(listingDto.AmountNeeded);
            listing.MinExchangeAmount = listingDto.MinExchangeAmount;
            listing.ExchangeRate = listingDto.ExchangeRate;
            listing.Status = ListingStatus.OPEN;
            listing.DateCreated = System.DateTime.Now;
            listing.CustomerId = customerId;
      
           

            return listing;
        }

        public void EditListing(EditListingDto editListingDto)
        {

             AmountNeeded = Currency.CreateCurrency(editListingDto.AmountNeeded);
             AmountAvailable = Currency.UpdateAmount(editListingDto.AmountAvailable.Amount, AmountAvailable);
             ExchangeRate = editListingDto.ExchangeRate;
             MinExchangeAmount = editListingDto.MinExchangeAmount;
        }

        internal static ResponseModel ValidateListing(ListingDto listingDto)
        {
            ResponseModel response = new ResponseModel();
            if (listingDto.AmountAvailable.CurrencyType ==  listingDto.AmountNeeded.CurrencyType)
            {
                response.Message = "AMount needed currency and Amount Available Currency cannot be the same";
                response.Status = false; return response;
             
            }
            response.Status = true;
           response.Message = "Bid has been added successfully";
            return response;
        }

        public IReadOnlyCollection<Bid> GetBids()
        {
            return Bids;
        }

        //public ResponseModel AddBid(BidDto bid, Guid customerId)
        //{
        //    _ = bid ?? throw new ArgumentNullException($"{nameof(bid)} null object detected");
        //    ResponseModel response = new ResponseModel();
        //    if (bid.Amount == null || customerId == default(Guid))
        //    {
        //        response.Message = "Invalid Bid";
        //        response.Status = false; return response;
        //    }

        //    //if (bid.Amount.CurrencyType != AmountNeeded.CurrencyType) {
        //    //    response.Message = "Not expected currency";
        //    //    response.Status = false;
        //    //    return response;
        //    //}


        //    if (HasReachedBiddingLimit())
        //    {
        //        response.Message = "Bidding limit has been reached";
        //        response.Status = false;
        //        return response;
        //    }

        //    _bids.Add(Bid.AddBid(Id, bid, customerId));
        //    response.Status = true;
        //    response.Message = "Bid has been added successfully";
        //    return response;
        //}

        public ResponseModel ValidateBid(BidDto bid, Guid customerId)
        {
            _ = bid ?? throw new ArgumentNullException($"{nameof(bid)} null object detected");
            ResponseModel response = new ResponseModel();
            if (bid.Amount == null || customerId == default(Guid))
            {
                response.Message = "Invalid Bid";
                response.Status = false; return response;
            }

            //if (bid.Amount.CurrencyType != AmountNeeded.CurrencyType) {
            //    response.Message = "Not expected currency";
            //    response.Status = false;
            //    return response;
            //}

            if(bid.Amount.Amount <= 0)
            {
                response.Message = "Bidding amount must a valid number";
                response.Status = false;
                return response;
            }

            if (HasReachedBiddingLimit())
            {
                response.Message = "Bidding limit has been reached";
                response.Status = false;
                return response;
            }
            var checkbid = _bids.Where(e => e.CustomerId == customerId && e.ListingId == bid.ListingId).FirstOrDefault();
            if(checkbid != null)
            {
                response.Message = "Multiple bidding not allowed by a customer on the same bid";
                response.Status = false;
                return response;
            }

            response.Status = true;
            response.Message = "Bid has been validated successfully";
            return response;
        }

        public Bid AddBid(BidDto bidDto, Guid customerId)
        {
            Bid bid = Bid.createBid(bidDto, customerId);
            _bids.Add(bid);
            return bid;
        }

        public void SetStatus(ListingStatus listingStatus)
        {
            Status = listingStatus;
        }


        public void UpdateStatus(ListingStatus listingStatus)
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
