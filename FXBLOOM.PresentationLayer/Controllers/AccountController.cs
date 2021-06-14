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
    public class AccountController : BaseController
    {
        private ILog _logger;
        private ICustomerRepository _customerRepository;
        public AccountController(ILog logger, ICustomerRepository customerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository;
        }



        [HttpPost]
        [Produces(typeof(ResponseWrapper<string>))]
        public async Task<IActionResult> AddAccount([FromBody]AccountDTO accountDTO)
        {
            var profileIdClaim = User.Claims.FirstOrDefault(c => c.Type == FXBloomsClaimTypes.CustomerId);
            var customerId = Guid.Parse(profileIdClaim.Value);

            var response = await _customerRepository.AddAccount(customerId, accountDTO);
            if (response.Status is false)
            {
                return Error(response.Message);
            }

            return Ok(response.Message);
        }

    }
}
