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

        public async Task<ResponseModel> AddListing(Guid Id,ListingDto listing)
        {
            var existingcustomer = await Schema<Customer>().GetAsync(e => e.Id == Id, d => d.Listings).ConfigureAwait(false);
            if(existingcustomer is null) { return new ResponseModel { Message = "Oops!! Could not retrieve your profile", Status = false }; }

            AddEntity(existingcustomer.AddListing(listing));
            var res = await Schema<Customer>().UpdateAsync(existingcustomer);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi {existingcustomer.FirstName.ToSentenceCase()}, your currency listing was added successfully.":"Oops!! Something went wrong"
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

            existingListing.EditListing(editListingDto);
            var res = await UpdateAsync(existingListing);

            return new ResponseModel
            {
                Status = res,
                Message = res ? $"Hi, your currency listing was edited successfully." : "Oops!! Something went wrong"
            };
        }

        public  Task<List<Listing>> GetListings()
        {
            var listings = GetAll(e => e.Status == ListingStatus.OPEN).ToListAsync();
            return listings;
        }
    }
}
