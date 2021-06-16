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
    public class StateRepository: ManagerBase<State>, IStateRepository
    {

        private FXBloomContext _context;

        public StateRepository(FXBloomContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<State>>> GetCountryState(int countryid)
        {

            ResponseModel<List<State>> responseModel = new ResponseModel<List<State>>();
            var state = await GetAll(e => e.CountryId == countryid).ToListAsync();

            if (state.Count == 0) { return new ResponseModel<List<State>> { Message = "Oops!! Could not retrieve state list", Status = false }; }

            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = state;


            return responseModel;
        }

        public async Task<ResponseModel<List<State>>> GetState()
        {
            ResponseModel<List<State>> responseModel = new ResponseModel<List<State>>();
            var state = await GetAll().ToListAsync();

            if (state.Count == 0) { return new ResponseModel<List<State>> { Message = "Oops!! Could not retrieve state list", Status = false }; }

            responseModel.Message = "Sucesss";
            responseModel.Status = true;
            responseModel.Data = state;


            return responseModel;
        }
    }
}
