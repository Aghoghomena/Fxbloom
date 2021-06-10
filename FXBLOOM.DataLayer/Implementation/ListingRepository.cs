using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
