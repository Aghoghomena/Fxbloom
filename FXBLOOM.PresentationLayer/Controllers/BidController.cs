using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCore.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BidController : BaseController
    {

        private ILog _logger;
        private IBidRepository _bidRepository;
        public BidController(ILog logger, IBidRepository bidRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bidRepository = bidRepository;
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> AddBid(BidDto bidDto)
        {
            try
            {

                var profileIdClaim = User.Claims.FirstOrDefault(c => c.Type == FXBloomsClaimTypes.CustomerId);
                var customerID = Guid.Parse(profileIdClaim.Value);

                var response = await _bidRepository.AddBid(customerID, bidDto);
                if (response.Status == false)
                {
                    return Error(response.Message);
                }

                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            //validate the amount of completed bids to ensure customer enters their account number

        }

        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<Bid>>))]
        public async Task<IActionResult> Get(Guid ListingId)
        {
            try
            {
                var bid = await _bidRepository.GetBidding(ListingId);

                if (bid.Status is false)
                {
                    return Error(bid.Message);
                }

                return Ok(bid);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);

            }
        }
    }
}
