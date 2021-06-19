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
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DataLayer.Implementation
{
    public class ListingRepository : ManagerBase<Listing>, IListingRepository
    {
        private FXBloomContext _context;
        public ListingRepository(FXBloomContext context):base(context)
        {

            _context = context;
        
    }

        //public async Task<ResponseModel> AddListing(Guid Id,ListingDto listing)
        //{
        //    var existingcustomer = await Schema<Customer>().GetAsync(e => e.Id == Id, d => d.Listings).ConfigureAwait(false);
        //    if(existingcustomer is null) { return new ResponseModel { Message = "Oops!! Could not retrieve your profile", Status = false }; }

        //    existingcustomer.AddListing(listing);
        //    var res = false;
        //    try {  res = await Schema<Customer>().UpdateAsync(existingcustomer); }
        //    catch(Exception ex)
        //    {

        //    }


        //    return new ResponseModel
        //    {
        //        Status = res,
        //        Message = res ? $"Hi {existingcustomer.FirstName.ToSentenceCase()}, your currency listing was added successfully.":"Oops!! Something went wrong"
        //    };
        //}

        public async Task<ResponseModel> AddListing(Guid Id, ListingDto listing)
        {
            ResponseModel response = new ResponseModel();
            var existingcustomer = await Schema<Customer>().GetAsync(e => e.Id == Id, d => d.Listings).ConfigureAwait(false);
            if (existingcustomer is null) { return new ResponseModel { Message = "Oops!! Could not retrieve your listing", Status = false }; }
            response = existingcustomer.ValidateListing(listing);
            if(response.Status == false) { return new ResponseModel { Message = "Oops!! Validation error " + response.Message, Status = false }; }
            AddEntity(existingcustomer.AddListing(listing));
            var res = await Schema<Customer>().UpdateAsync(existingcustomer);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi {existingcustomer.FirstName.ToSentenceCase()}, your currency listing was added successfully." : "Oops!! Something went wrong"
            };
        }

        public async Task<ResponseModel> DeleteListing(Guid listingId)
        {
            var existingListing = await GetAsync(e => e.Id == listingId).ConfigureAwait(false);
            if (existingListing is null) { return new ResponseModel { Status = false, Message = "Oops!! could not retrieve the currency listing info." }; }

            existingListing.SetStatus(ListingStatus.REMOVED);
            var res = await UpdateAsync(existingListing);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi, your currency listing was removed successfully." : "Oops!! Something went wrong"
            };
        }

        public async Task<ResponseModel> EditListing(EditListingDto editListingDto)
        {
            var existingListing = await GetAsync(e => e.Id == editListingDto.Id).ConfigureAwait(false);
            if(existingListing is null) { return new ResponseModel { Status = false, Message = "Oops!! could not retrieve the currency listing info." }; }
            if(existingListing.Status != ListingStatus.OPEN) { return new ResponseModel { Status = false, Message = "Oops!! can only edit Open Listing." }; }
            existingListing.EditListing(editListingDto);
            var res = await UpdateAsync(existingListing);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi, your currency listing was edited successfully." : "Oops!! Something went wrong"
            };
        }

        public async Task<ResponseModel<List<Listing>>> GetFilteredListings(ListingStatus listingStatus)
        {
            ResponseModel<List< Listing >> responseModel = new ResponseModel<List<Listing>>();
            var listings = await GetAll(e => e.Status == listingStatus).ToListAsync();
            if (listings.Count == 0)
            {
                return new ResponseModel<List<Listing>> { Message = "Oops!! Could not retrieve Listings", Status = false };
            }

            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = listings;


            return responseModel;
        }

        public async Task<ResponseModel<Listing>> GetListing(Guid listingId)
        {
            
            ResponseModel<Listing> responseModel = new ResponseModel<Listing>();
            var lsiting = await GetAsync(e => e.Id == listingId, d => d.Bids).ConfigureAwait(false);
            if (lsiting is null)
            {
                return new ResponseModel<Listing> { Message = "Oops!! Could not retrieve listing details", Status = false };
            }
            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = lsiting;


            return responseModel;
        }

        public async Task<ResponseModel<List<Listing>>> GetListings()
        {
            ResponseModel<List<Listing>> responseModel = new ResponseModel<List<Listing>>();
            var listings = await GetAll(e => e.Status == ListingStatus.OPEN).ToListAsync();
            if (listings is null)
            {
                return new ResponseModel<List<Listing>> { Message = "Oops!! Could not retrieve Listngs", Status = false };
            }

            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = listings;


            return responseModel;
        }

        public async Task<ResponseModel> UpdateStatus(ListingStatusDTO listingStatus)
        {
            var existingListing = await GetAsync(e => e.Id == listingStatus.listingId).ConfigureAwait(false);
            if (existingListing is null) { return new ResponseModel { Status = false, Message = "Oops!! could not retrieve the currency listing info." }; }

            existingListing.UpdateStatus(listingStatus.listingStatus);
            var res = await UpdateAsync(existingListing);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi, your currency listing status was updated sucessfully." : "Oops!! Something went wrong"
            };
        }
    }
}
