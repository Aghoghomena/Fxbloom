using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.SharedKernel;
using SecurityCore.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public DateTime LastDateLoggedIn { get; private set; }

        public int? ClosedBids { get; private set; } = 0;
        public Customer():base(Guid.NewGuid())
        {
            _listings = new List<Listing>();
        }

        public static Customer CreateCustomer(CustomerCreationRequest customerDto)
        {
            Customer customer = new Customer();
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.OtherName = customerDto.OtherName;
            customer.PhoneNo = customerDto.PhoneNo;
            customer.PostalCode = customerDto.PostalCode;
            customer.Address = customerDto.Address;
            customer.Email = customerDto.Email;
            customer.Password = customerDto.Password.HashPassword();
            customer.CountryId = customerDto.CountryId;
            customer.StateId = customerDto.StateId;
            customer.Img = customerDto.Img;
            customer.CustomerStatus = CustomerStatus.PENDING;
            customer.Documentation = Document.CreateDocument(customerDto.Document);

            return customer;
        }

        public Listing AddListing(ListingDto listingDto)
        {
            Listing listing = Listing.CreateListing(Id, listingDto);
            _listings.Add(listing);
            return listing;
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

        public void UpdateStatus(CustomerStatus status)
        {
            if (status.Equals(CustomerStatus.CONFIRMED)){ DateConfirmed = System.DateTime.Now; }
            CustomerStatus = status;
        }

        public void UpdateCompleteBids(CustomerBidCountDto customerBidCount)
        {
            ClosedBids += 1;
        }

        public void ChangePassword(PasswordDto passwordDto)
        {
            Password = passwordDto.Password.HashPassword();
        }


        public IReadOnlyCollection<Listing> GetListings()
        {
            return Listings;
        }

        private bool RequiresAccountNumber()
        {
            if (ClosedBids > 2 )
            {
                return true;
            }

            return false;
        }


        public AuthenticationResponseDTO AuthenticateCustomer(string password)
        {
            AuthenticationResponseDTO response;
            var hashedPassword = password.HashPassword();
            if (string.Equals(hashedPassword, Password, StringComparison.OrdinalIgnoreCase))
            {
                LastDateLoggedIn = DateTime.Now;

                response = AuthenticationResponseDTO.GetAuthenticationResponse(token: GenerateSecurityToken(), isAuthenticated: true, firstName: FirstName,lastName: LastName);

                return response;
            }

            response = AuthenticationResponseDTO.GetAuthenticationResponse(isAuthenticated: false);

            return response;
        }

        public string GETJWT()
        {
            return GenerateSecurityToken();
        }

        private string GenerateSecurityToken()
        {
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email.Trim()),
                new Claim(ClaimTypes.Name, FirstName.ToSentenceCase()),
                new Claim(ClaimTypes.Surname, LastName.ToSentenceCase()),
                new Claim(FXBloomsClaimTypes.CustomerId, Id.ToString()),
                new Claim(ClaimTypes.Role, "Customer")
            });

            return TokenUtils.GenerateToken(claimsIdentity);
        }
    }
}
