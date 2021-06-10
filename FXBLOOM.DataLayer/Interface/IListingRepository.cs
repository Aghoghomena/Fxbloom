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
    }
}
