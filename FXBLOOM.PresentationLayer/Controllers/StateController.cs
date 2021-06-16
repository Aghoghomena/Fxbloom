using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
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
    public class StateController : BaseController
    {

        private ILog _logger;
        private IStateRepository _settingRepository;
        public StateController(ILog logger, IStateRepository settingRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _settingRepository = settingRepository;
        }


        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<State>>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var country = await _settingRepository.GetState();

                if (country.Status is false)
                {
                    return Error(country.Message);
                }

                return Ok(country);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);

            }
        }


        [HttpGet]
        [Route("country/{countryId}")]
        [Produces(typeof(ResponseWrapper<List<State>>))]
        public async Task<IActionResult> GetCountryState(int countryId)
        {
            try
            {
                var country = await _settingRepository.GetCountryState(countryId);

                if (country.Status is false)
                {
                    return Error(country.Message);
                }

                return Ok(country);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);

            }
        }

    }
}
