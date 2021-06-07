using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class CustomerDTO
    {
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public DocumentDto Document { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNo { get; set; }

        public string OtherName { get; set; }

        public int  CountryId { get; set; }

        public int StateId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Img { get; set; }


    }
}
