using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Interface
{
    public interface ISettingRepository
    {
        Task<ResponseModel<Country>> GetCountries();

    }
}
