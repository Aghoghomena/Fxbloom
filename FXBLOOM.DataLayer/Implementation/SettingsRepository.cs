using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Implementation
{
    public class SettingsRepository : ManagerBase<Country>, ISettingRepository
    {

        private FXBloomContext _context;
        public SettingsRepository(FXBloomContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Country>> GetCountries()
        {
            ResponseModel<Country> responseModel = new ResponseModel<Country>();
            var country = await GetAllAsync();

            responseModel.Message = "Sucesss";
            responseModel.Data = (Country)country;

            return responseModel;
            //return country;
        }

        //public async Task<IEnumerable<Customer>> GetCustomers()
        //{
        //    var customers = await GetAllAsync().ConfigureAwait(false);

        //    return customers;
        //}
    }
}
