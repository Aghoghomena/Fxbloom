using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.SharedKernel.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.DataLayer.Interface
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(Guid customerID);
        Task<PagedQueryResult<Customer>> GetConfirmedCustomers(PagedQueryRequest request);
        Task<PagedQueryResult<Customer>> GetRejectedCustomers(PagedQueryRequest request);
        Task<PagedQueryResult<Customer>> GetCustomersAwaitingConfirmation(PagedQueryRequest request);
    }
}
