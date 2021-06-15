using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                //validate the amount of completed bids to ensure customer enters their account number
                var response = await _listingRepository.AddListing(Listing.CreateListing(listingDto));
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Listing Created Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }


        [HttpGet]
        [Produces(typeof(ResponseWrapper<string>))]
        public IActionResult Get()
        {
            //return Ok("Hello World");

            return Ok(_listingRepository.GetListings());
        }

        [HttpPatch]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> UpdateList(EditListingDto editListingDto)
        {
            try
            {
                //can only update listings have bo bid
                var response = await _listingRepository.EditListing(editListingDto);
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Listing Edited Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpDelete]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> deleteListing(Guid listingId)
        {
            try
            {
                //can only update listings have bo bid
                var response = await _listingRepository.DeleteListing(listingId);
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Listing Removed Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }


    }
}
