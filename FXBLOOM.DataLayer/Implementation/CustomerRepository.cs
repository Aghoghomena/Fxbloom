using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Query;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using Microsoft.EntityFrameworkCore;
using FXBLOOM.DomainLayer;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DataLayer.Implementation
{
    public class CustomerRepository : ManagerBase<Customer>, ICustomerRepository
    {
        private FXBloomContext _context;
        public CustomerRepository(FXBloomContext context):base(context)
        {
            _context = context;
        }


        public async Task<ResponseModel<AuthenticationResponseDTO>> AuthenticateCustomer(string username, string password)
        {
            ResponseModel<AuthenticationResponseDTO> responseModel = new ResponseModel<AuthenticationResponseDTO>();
            var customer = await GetAsync(e => e.Email == username).ConfigureAwait(false);
            if(customer is null) { 
                return new ResponseModel<AuthenticationResponseDTO> { Message = "Username or Password is not correct", Status = false }; 
            }

            var authRes = customer.AuthenticateCustomer(password);
            if(authRes.IsAuthenticated is false) { 
                return new ResponseModel<AuthenticationResponseDTO> { Message = "Username or Password is not correct", Status = false };
            }
            
            responseModel.Data = authRes;
            responseModel.Status = true;
            return responseModel;
        }


        public Task<List<Customer>> GetCustomers()
        {
            var customers =  GetAll(e => e.Country, f => f.State).ToListAsync();
            return customers;

        }

        public async Task<Customer> GetCustomer(Guid customerID)
        {
            var customer = await GetAsync(e => e.Id == customerID, d => d.Listings).ConfigureAwait(false);

            return customer;
        }

        public async Task<PagedQueryResult<Customer>> GetConfirmedCustomers(PagedQueryRequest request)
        {
            var confirmedCustomers = await GetAllAsync<Customer, DateTime>(e => e.CustomerStatus == Enumerations.CustomerStatus.CONFIRMED, x => x.DateCreated,request);
            return confirmedCustomers;
        }

        public async Task<PagedQueryResult<Customer>> GetRejectedCustomers(PagedQueryRequest request)
        {
            var confirmedCustomers = await GetAllAsync<Customer, DateTime>(e => e.CustomerStatus == Enumerations.CustomerStatus.REJECTED, x => x.DateCreated, request);
            return confirmedCustomers;
        }

        public async Task<PagedQueryResult<Customer>> GetCustomersAwaitingConfirmation(PagedQueryRequest request)
        {
            var confirmedCustomers = await GetAllAsync<Customer, DateTime>(e => e.CustomerStatus == Enumerations.CustomerStatus.CONFIRMED, x => x.DateCreated, request);
            return confirmedCustomers;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {

            var res = await AddAsync(customer);

            return res;
        }


        public async Task<ResponseModel> AddAccount(Guid customerID, AccountDTO accountDTO)
        {
            var existingcustomer = await GetAsync(e => e.Id == customerID).ConfigureAwait(false);
            if(existingcustomer is null) { return new ResponseModel { Message = "Oops!! Could not retrieve your profile", Status = false }; }

            if (accountDTO.AccountType.Equals(AccountType.FOREIGN))
            {
                existingcustomer.AddForeignAccount(accountDTO);
            }else if (accountDTO.AccountType.Equals(AccountType.DOMESTIC))
            {
                existingcustomer.AddDomesticAccount(accountDTO);
            }


            var res = await UpdateAsync(existingcustomer);
            return new ResponseModel {
                Message = res?"Account was added successfully":"Oops!! something went wrong while trying to complete the process",
                Status = res
            };
        }


        public async Task<ResponseModel> UpdateStatus(Guid customerID, CustomerStatus status)
        {

            var existingcustomer = await GetAsync(e => e.Id == customerID).ConfigureAwait(false);
            if(existingcustomer is null) { return new ResponseModel { Status = false, Message = "Oops!! Could not retrieve your profile" }; }

            existingcustomer.UpdateStatus(status);
            var res = await UpdateAsync(existingcustomer);

            return new ResponseModel { Message = res ? $"{existingcustomer.FirstName.ToSentenceCase()}'s status was updated successfully" : "Oops!! something went wrong", Status = res };
        }

        public async Task<ResponseModel> ChangePassword(PasswordDto passwordDto)
        {
            var existingcustomer = await GetAsync(e => e.Id == passwordDto.CustomerId).ConfigureAwait(false);
            if(existingcustomer is null) { return new ResponseModel { Status = false, Message = "Oops!! Could not retrieve your profile" }; }
            existingcustomer.ChangePassword(passwordDto);
            var res = await UpdateAsync(existingcustomer);

            return new ResponseModel { Message = res ? $"Hi {existingcustomer.FirstName.ToSentenceCase()}, your password was changed successfully" : "Oops!! something went wrong", Status = res };
        }

        public async Task<ResponseModel> UpdateCompleteBidCount(CustomerBidCountDto customerBidCountDto)
        {
            var existingcustomer = await GetAsync(e => e.Id == customerBidCountDto.CustomerId).ConfigureAwait(false);
            if(existingcustomer is null) { return new ResponseModel { Message = "Oops!! Could not retrieve your profile", Status = false }; }
            existingcustomer.UpdateCompleteBids(customerBidCountDto);
            var res = await UpdateAsync(existingcustomer);
            return new ResponseModel { Message = res ? $"Hi, {existingcustomer.FirstName.ToSentenceCase()},your bid status was updated successfully" : "Oops!! something went wrong", Status = res };
        }
    }
}
