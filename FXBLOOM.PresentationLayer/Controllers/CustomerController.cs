using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private ILog _logger;
        private ICustomerRepository _customerRepository;
        private IValidation _validation;
        public CustomerController(ILog logger, ICustomerRepository customerRepository, IValidation validation)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository;
            _validation = validation;
        }




        [HttpGet]
        [Produces(typeof(ResponseWrapper<string>))]
        public IActionResult Get()
        {
            //return Ok("Hello World");

            return Ok(_customerRepository.GetCustomers());
        }

        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult>  CreateCustomer(DocumentDTO customerDTO)
        {
            try
            {
                //validate the request
                var check_data = _validation.ValidateCustomer(customerDTO);
                if (check_data.status_code == 422)
                {
                    return Error("Validation Error");
                }
                //set documentation 

                var response = await _customerRepository.AddCustomer(Customer.CreateCustomer(customerDTO));
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Customer Created Sucessfully");
            }
            catch(Exception ex)
            {
                return Error(ex.Message);
            }
           
            

        }

        [HttpPost("Status")]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> CustomerStatus(CustomerStatusDto customerStatusDto)
        {
            try
            {
               

                var response = await _customerRepository.UpdateStatus(customerStatusDto);
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Customer Status Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPost("Password")]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> Password(PasswordDto passwordDto)
        {
            try
            {


                var response = await _customerRepository.ChangePassword(passwordDto);
                if (response == false)
                {
                    return Error("OOPS Something went wrong with the code");
                }
                return Ok("Customer password changed Sucessfully");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }



        //[HttpPost]
        //[Produces(typeof(ResponseWrapper<string>))]
        //public async Task<IActionResult> CustomerLogin(string username, string password)
        //{
        //    //validate the request
        //    var check_data = _validation.ValidateLogin(username, password);
        //    if (check_data.status_code == 422)
        //    {
        //        return Error("Validation Error");
        //    }
        //    var response = await _customerRepository.CustomerLogin(username,password);
        //    //if (response == false)
        //    //{
        //    //    return Error("OOPS Something went wrong with the code");
        //    //}
        //    return Ok(response);


        //}


    }
}
