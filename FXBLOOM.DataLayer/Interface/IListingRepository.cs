using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Interface
{
    public interface IListingRepository
    {

        Task<ResponseModel> AddListing(Guid Id, ListingDto listing);

        Task<List<Listing>> GetListings();

        Task<ResponseModel> EditListing(EditListingDto editListingDto);

        Task<ResponseModel> DeleteListing(Guid listingId);
    }
}
