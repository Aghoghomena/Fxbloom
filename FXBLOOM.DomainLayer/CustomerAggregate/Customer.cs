﻿using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
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

        //public State CustomerState { get; set; }

        public string PostalCode { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
        public CustomerStatus CustomerStatus { get; private set; }
        public Account Account { get; private set; }
        public Document Documentation { get; private set; }

        public List<Listing> _listings;
        public IReadOnlyCollection<Listing> Listings => _listings;
        public DateTime DateCreated { get; set; }
        public DateTime DateConfirmed { get; set; }

        public Customer():base(Guid.NewGuid())
        {
            _listings = new List<Listing>();
        }

        public static Customer CreateCustomer(CustomerDTO customerDto)
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

      

        public IReadOnlyCollection<Listing> GetListings()
        {
            return Listings;
        }
    }
}
