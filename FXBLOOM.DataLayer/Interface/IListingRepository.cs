using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Interface
{
    public interface IListingRepository
    {

        Task<bool> AddListing(Listing listing);

        Task<List<Listing>> GetListings();

        Task<bool> EditListing(EditListingDto editListingDto);

        Task<bool> DeleteListing(Guid listingId);
    }
}
