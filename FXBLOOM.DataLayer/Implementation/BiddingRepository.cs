using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Implementation
{
   public class BiddingRepository : ManagerBase<Bid>,IBidRepository
    {
        private FXBloomContext _context;
        public BiddingRepository(FXBloomContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseModel> AddBid(Guid Id, BidDto bidDto)
        {
            var existinglist = await Schema<Listing>().GetAsync(e => e.Id == bidDto.ListingId, d => d.Bids).ConfigureAwait(false);
            if (existinglist is null) { return new ResponseModel { Message = "Oops!! Could not retrieve List ", Status = false }; }
            ResponseModel validate = new ResponseModel();
            validate = existinglist.ValidateBid(bidDto, Id);
            if(validate.Status == false) { return new ResponseModel { Message = "One or more validations error occurred", Status = false }; }
            AddEntity(existinglist.AddBid(bidDto, Id));
            var res = await Schema<Listing>().UpdateAsync(existinglist);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi , your bid was added successfully." : "Oops!! Something went wrong"
            };
        }

        public async Task<ResponseModel> DeleteListing(Guid bidId)
        {
            var existingbid = await GetAsync(e => e.Id == bidId).ConfigureAwait(false);
            if (existingbid is null) { return new ResponseModel { Status = false, Message = "Oops!! could not retrieve the currency Bidding info." }; }

            var existingListing = await Schema<Listing>().GetAsync(e => e.Id == existingbid.ListingId, d => d.Bids).ConfigureAwait(false);

            //existingListing.SetStatus(ListingStatus.REMOVED);
            //var res = await UpdateAsync(existingListing);

            return new ResponseModel
            {
                Status = true,
                //Message = res ? $"Hi, your currency listing was removed successfully." : "Oops!! Something went wrong"
            };
        }

        public async Task<ResponseModel<List<Bid>>> GetBidding(Guid Id)
        {
            ResponseModel<List<Bid>> responseModel = new ResponseModel<List<Bid>>();

            var bid = await GetAll().ToListAsync();
            if (bid is null)
            {
                return new ResponseModel<List<Bid>> { Message = "Oops!! Could not retrieve country list", Status = false };
            }

            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = bid;
            return responseModel;
        }

   
    }
}
