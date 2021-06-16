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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListingController : BaseController
    {

        private ILog _logger;
        private IListingRepository _listingRepository;
        public ListingController(ILog logger, IListingRepository listingRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _listingRepository = listingRepository;
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> AddListing(ListingDto listingDto)
        {
            //validate the amount of completed bids to ensure customer enters their account number

            var profileIdClaim = User.Claims.FirstOrDefault(c => c.Type == FXBloomsClaimTypes.CustomerId);
            var customerID = Guid.Parse(profileIdClaim.Value);

            var response = await _listingRepository.AddListing(customerID, listingDto);
            if (response.Status == false)
            {
                return Error(response.Message);
            }

            return Ok(response.Message);
        }


        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<Listing>>))]
        public IActionResult Get()
        {
            //return Ok("Hello World");

            return Ok(_listingRepository.GetListings());
        }

        [HttpPatch]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> UpdateList(EditListingDto editListingDto)
        {
            //can only update listings have bo bid
            var response = await _listingRepository.EditListing(editListingDto);
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response.Message);

        }

        [HttpDelete]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> deleteListing(Guid listingId)
        {
            //can only update listings have bo bid
            var response = await _listingRepository.DeleteListing(listingId);
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response.Message);

        }
    }
}
