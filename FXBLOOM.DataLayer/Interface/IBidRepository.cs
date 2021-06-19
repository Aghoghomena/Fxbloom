using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Interface
{
    public interface IBidRepository
    {
        Task<ResponseModel> AddBid(Guid Id, BidDto bidDto);

        Task<ResponseModel<List<Bid>>> GetBidding(Guid Id);
        Task<ResponseModel> DeleteListing(Guid bidId);
    }
}
