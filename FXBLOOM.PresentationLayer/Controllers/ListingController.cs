using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
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
    public class ListingController : ControllerBase
    {

        private ILog _logger;
        private ICustomerRepository _customerRepository;
        private IValidation _validation;
        public ListingController(ILog logger, ICustomerRepository customerRepository, IValidation validation)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository;
            _validation = validation;
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> AddListing(ListingDto listingDto)
        {
            //try
            //{
            //    var response = await _customerRepository.AddCustomer(Listing.CreateListing(listingDto.CustomerId,listingDto));
            //    if (response == false)
            //    {
            //        return Error("OOPS Something went wrong with the code");
            //    }
            //    return Ok("Customer Created Sucessfully");
            //}
            //catch (Exception ex)
            //{
            //    return Error(ex.Message);
            //}

            return Ok("Customer Created Sucessfully");

        }

    }
}
