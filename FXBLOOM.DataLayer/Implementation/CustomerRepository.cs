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

namespace FXBLOOM.DataLayer.Implementation
{
    public class CustomerRepository : ManagerBase<Customer>, ICustomerRepository
    {
        private FXBloomContext _context;
        public CustomerRepository(FXBloomContext context):base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Customer>> GetCustomers()
        //{
        //    var customers = await GetAllAsync().ConfigureAwait(false);

        //    return customers;
        //}
        public Task<List<Customer>> GetCustomers()
        {
            var customers =  GetAll(e => e.Country, f => f.State).ToListAsync();

            //var customers2 = await _context.Customers.Include(a => a.Country.).ToListAsync();
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
            //validate 

            var res = await AddAsync(customer);

            return res;
        }


        public async Task<bool> AddAccount(AccountDTO accountDTO)
        {
            var existingcustomer = await GetAsync(e => e.Id == accountDTO.CustomerId).ConfigureAwait(false);
            if (accountDTO.AccountType == 0) {
                existingcustomer.AddForeignAccount(accountDTO);
                var res = await UpdateAsync(existingcustomer);

                return res;
            }
            else
            {
                existingcustomer.AddForeignAccount(accountDTO);
                var res = await UpdateAsync(existingcustomer);

                return res;
            }

        }

   
        public async Task<bool> UpdateStatus(CustomerStatusDto customerStatusDto)
        {
            var existingcustomer = await GetAsync(e => e.Id == customerStatusDto.CustomerId).ConfigureAwait(false);
            
                existingcustomer.UpdateStatus(customerStatusDto);
                var res = await UpdateAsync(existingcustomer);

                return res;
           

        }

        
        public async Task<Customer> CustomerLogin(String username, string password)
        {
            var customer = await GetAsync(e => e.Email == username && e.Password == password  ).ConfigureAwait(false);

            return customer;
        }

        public async Task<bool> ChangePassword(PasswordDto passwordDto)
        {
            var existingcustomer = await GetAsync(e => e.Id == passwordDto.CustomerId).ConfigureAwait(false);

            existingcustomer.ChangePassword(passwordDto);
            var res = await UpdateAsync(existingcustomer);

            return res;
        }

        public async Task<bool> UpdateCompleteBidCount(CustomerBidCountDto customerBidCountDto)
        {
            var existingcustomer = await GetAsync(e => e.Id == customerBidCountDto.CustomerId).ConfigureAwait(false);

            existingcustomer.UpdateCompleteBids(customerBidCountDto);
            var res = await UpdateAsync(existingcustomer);

            return res;
        }
    }
}
