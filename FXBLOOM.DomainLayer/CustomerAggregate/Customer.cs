using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class Customer:Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string OtherName { get; private set; }

        public string PhoneNo { get; private set; }

        public int CountryId { get; private set; }
        public virtual Country Country { get; set; }

        public int? StateId { get; private set; }

        public virtual State State { get;  private set; }

        public string PostalCode { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Img { get; private set; }

        public string Address { get; private set; }
        public CustomerStatus CustomerStatus { get; private set; }
        public Account ForeignAcct{ get; private set; }

        public Account DomesticAcct { get; private set; }
        public Document Documentation { get; private set; }

        public List<Listing> _listings;
        public IReadOnlyCollection<Listing> Listings => _listings;
        public DateTime DateCreated { get; private set; } = System.DateTime.Now;
        public DateTime? DateConfirmed { get; private set; }

        public int? ClosedBids { get; private set; } = 0;
        public Customer():base(Guid.NewGuid())
        {
            _listings = new List<Listing>();
            //ForeignAcct = Account.CreateAccount("", "");
            //DomesticAcct = Account.CreateAccount("", "");
        }
        public static Customer CreateCustomer(DocumentDTO customerDto)
        {
            Customer customer = new Customer();
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.OtherName = customerDto.OtherName;
            customer.PhoneNo = customerDto.PhoneNo;
            customer.PostalCode = customerDto.PostalCode;
            customer.Address = customerDto.Address;
            customer.Email = customerDto.Email;
            customer.Password = customerDto.Password;
            customer.CountryId = customerDto.CountryId;
            customer.StateId = customerDto.StateId;
            customer.Img = customerDto.Img;
            customer.CustomerStatus = CustomerStatus.PENDING;
            customer.Documentation = Document.CreateDocument(customerDto.Document);

            return customer;
        }

        public void AddListing(ListingDto listingDto)
        {
            Listing listing = Listing.CreateListing(Id, listingDto);
            _listings.Add(listing);
        }

        public Listing GetListing(Guid listingId)
        {
            var listing = _listings.SingleOrDefault(e => e.Id == listingId);
            return listing;
        }

        public void AddForeignAccount(AccountDTO accountDTO)
        {
            ForeignAcct = Account.CreateAccount(accountDTO.AccountNumber, accountDTO.BankName);
        }

        public void AddDomesticAccount(AccountDTO accountDTO)
        {
            DomesticAcct = Account.CreateAccount(accountDTO.AccountNumber, accountDTO.BankName);
        }

        public void UpdateStatus(CustomerStatusDto customerStatusDto)
        {
            CustomerStatus = customerStatusDto.CustomerStatus;
        }

        public void ChangePassword(PasswordDto passwordDto)
        {
            Password = passwordDto.Password;
        }


        public IReadOnlyCollection<Listing> GetListings()
        {
            return Listings;
        }
    }
}
