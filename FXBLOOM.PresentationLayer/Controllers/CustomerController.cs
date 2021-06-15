﻿using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.PresentationLayer.Model;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCore.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : BaseController
    {
        private ILog _logger;
        private ICustomerRepository _customerRepository;
        public CustomerController(ILog logger, ICustomerRepository customerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository;
        }




        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<Customer>>))]
        public IActionResult Get()
        {
            return Ok(_customerRepository.GetCustomers());
        }


        [HttpGet]
        [Route("{customerId}")]
        [Produces(typeof(ResponseWrapper<Customer>))]
        public async Task<IActionResult> GetCustomer()
        {
            var profileIdClaim = User.Claims.FirstOrDefault(c => c.Type == FXBloomsClaimTypes.CustomerId);
            var customerId = Guid.Parse(profileIdClaim.Value);

            var customer = await _customerRepository.GetCustomer(customerId);

            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound($"Customer with Id: {customerId} was not found");
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationRequest customerDTO)
        {
            try
            {
                var response = await _customerRepository.AddCustomer(Customer.CreateCustomer(customerDTO));
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Customer Created Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }



        }

        [HttpPost("Status")]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> CustomerStatus([FromQuery] CustomerStatus status)
        {
            var profileIdClaim = User.Claims.FirstOrDefault(c => c.Type == FXBloomsClaimTypes.CustomerId);
            var customerID = Guid.Parse(profileIdClaim.Value);

            var response = await _customerRepository.UpdateStatus(customerID, status);
            if (response.Status is false)
            {
                return Error(response.Message);
            }

            return Ok(response.Message);
        }

        [HttpPost("Password")]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> Password([FromBody] PasswordDto passwordDto)
        {
            try
            {
                var response = await _customerRepository.ChangePassword(passwordDto);
                if (response == false)
                {
                    return Error("Oops!! Something went wrong with the code");
                }
                return Ok("Customer password changed Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }


        [HttpPost("CompleteBid")]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> CompleteBid([FromBody] CustomerBidCountDto customerBidCountDto)
        {
            try
            {


                var response = await _customerRepository.UpdateCompleteBidCount(customerBidCountDto);
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Customer Completed Bids Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPost("Login")]
        [Produces(typeof(ResponseWrapper<AuthenticationResponseDTO>))]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequestModel authenticationRequest)
        {
            _ = authenticationRequest ?? throw new ArgumentNullException(nameof(AuthenticationRequestModel));

            var response = await _customerRepository.AuthenticateCustomer(authenticationRequest.Username, authenticationRequest.Password);
            if(response.Status is false)
            {
                return Error(response.Message);
            }

            return Ok(response.Data);
        }
    }
}
