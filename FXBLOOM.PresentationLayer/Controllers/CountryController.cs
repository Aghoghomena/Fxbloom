﻿using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
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
    //[Authorize]
    public class CountryController : BaseController
    {
        private ILog _logger;
        private ICountryRepository _settingRepository;
        public CountryController(ILog logger, ICountryRepository settingRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _settingRepository = settingRepository;
        }


        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<Country>>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var country = await _settingRepository.GetCountries();

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
