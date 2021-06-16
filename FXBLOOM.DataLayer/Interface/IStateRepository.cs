using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Interface
{
    public interface IStateRepository
    {
        Task<ResponseModel<List<State>>> GetState();

        Task<ResponseModel<List<State>>> GetCountryState(int countryid);

    }
}
