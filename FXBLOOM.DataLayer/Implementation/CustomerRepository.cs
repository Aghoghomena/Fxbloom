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

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await GetAll(e => e.Country).ToListAsync();

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
            var res = await AddAsync(customer);

            return res;
        }
    }
}
