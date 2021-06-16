using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Implementation
{
    public class CountryRepository : ManagerBase<Country>, ICountryRepository
    {

        private FXBloomContext _context;
        public CountryRepository(FXBloomContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<Country>>> GetCountries()
        {
            ResponseModel<List<Country>> responseModel = new ResponseModel<List<Country>>();
            var country =  await GetAll().ToListAsync();

            if (country.Count == 0) { return new ResponseModel<List<Country>> { Message = "Oops!! Could not retrieve country list", Status = false }; }

            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = country;
           

            return responseModel;
        }
 
    }
}
