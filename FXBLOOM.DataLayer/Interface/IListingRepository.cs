using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DataLayer.Interface
{
    public interface IListingRepository
    {

        Task<ResponseModel> AddListing(Guid Id, ListingDto listing);

        Task<ResponseModel<List<Listing>>> GetListings();

        Task<ResponseModel> EditListing(EditListingDto editListingDto);

        Task<ResponseModel> DeleteListing(Guid listingId);

        Task<ResponseModel> UpdateStatus(ListingStatusDTO listingStatusDTO);

        Task<ResponseModel<List<Listing>>> GetFilteredListings(ListingStatus listingStatus);

        Task<ResponseModel<Listing>> GetListing(Guid listingId);
    }
}
