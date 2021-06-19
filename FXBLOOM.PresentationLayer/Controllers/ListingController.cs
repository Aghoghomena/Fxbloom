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
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> AddListing([FromBody] ListingDto listingDto)
        {
            try
            {

                var profileIdClaim = User.Claims.FirstOrDefault(c => c.Type == FXBloomsClaimTypes.CustomerId);
                var customerID = Guid.Parse(profileIdClaim.Value);

                var response = await _listingRepository.AddListing(customerID, listingDto);
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
        [Produces(typeof(ResponseWrapper<List<Listing>>))]
        public async Task<IActionResult> Get()
        {
            //return Ok("Hello World");

            var response = await _listingRepository.GetListings();
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response);
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> UpdateList(EditListingDto editListingDto)
        {
            //can only update listings have bo bid
            var response = await _listingRepository.EditListing(editListingDto);
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response);

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
            return Ok(response);

        }


        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> UpdateListingStatus(ListingStatusDTO listingStatusDTO)
        {
            //can only update listings have bo bid
            var response = await _listingRepository.UpdateStatus(listingStatusDTO);
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response);

        }

        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<Listing>>))]
        public async Task<IActionResult> filterListing(ListingStatus listingStatus)
        {
            //return Ok("Hello World");

            var response = await _listingRepository.GetFilteredListings(listingStatus);
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response);
        }


        [HttpGet]
        [Route("{listingId}")]
        [Produces(typeof(ResponseWrapper<List<Listing>>))]
        public async Task<IActionResult> Get(Guid listingId)
        {
            //return Ok("Hello World");

            var response = await _listingRepository.GetListing(listingId);
            if (response.Status == false)
            {
                return Error(response.Message);
            }
            return Ok(response);
        }
    }
}
