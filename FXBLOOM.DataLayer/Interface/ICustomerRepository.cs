using FXBLOOM.DomainLayer;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DataLayer.Interface
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(Customer customer);
        //Task<IEnumerable<Customer>> GetCustomers();

        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(Guid customerID);
        Task<PagedQueryResult<Customer>> GetConfirmedCustomers(PagedQueryRequest request);
        Task<PagedQueryResult<Customer>> GetRejectedCustomers(PagedQueryRequest request);
        Task<PagedQueryResult<Customer>> GetCustomersAwaitingConfirmation(PagedQueryRequest request);

        Task<ResponseModel> AddAccount(Guid customerID, AccountDTO account);

        Task<ResponseModel> UpdateStatus(Guid customerID, CustomerStatus status);


        Task<ResponseModel> ChangePassword(PasswordDto passwordDto);


        Task<ResponseModel> UpdateCompleteBidCount(CustomerBidCountDto customerBidCountDto);

        Task<ResponseModel<AuthenticationResponseDTO>> AuthenticateCustomer(string username, string password);
    }
}
