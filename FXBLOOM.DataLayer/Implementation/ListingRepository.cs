using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
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

        public async Task<bool> AddListing(Listing listing)
        {
            //var existingcustomer = await GetAsync(e => e.Id == listingDto.CustomerId).ConfigureAwait(false);
            var res = await AddAsync(listing);

            return res;
        }

        public async Task<bool> DeleteListing(Guid listingId)
        {
            var existingListing = await GetAsync(e => e.Id == listingId).ConfigureAwait(false);

            existingListing.SetStatus(ListingStatus.REMOVED);
            var res = await UpdateAsync(existingListing);

            return res;
        }

        public async Task<bool> EditListing(EditListingDto editListingDto)
        {
            var existingListing = await GetAsync(e => e.Id == editListingDto.Id).ConfigureAwait(false);

            existingListing.EditListing(editListingDto);
            var res = await UpdateAsync(existingListing);

            return res;
        }

        public  Task<List<Listing>> GetListings()
        {
            var listings = GetAll(e => e.AmountAvailable, b=> b.AmountNeeded).ToListAsync();
            return listings;
        }
    }
}
