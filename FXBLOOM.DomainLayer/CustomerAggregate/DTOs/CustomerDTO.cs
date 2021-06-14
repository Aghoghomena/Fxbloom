using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class CustomerCreationRequest
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get;  set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Residential address is required")]
        public string Address { get; set; }

        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Phonenumber is required")]
        [MaxLength(18, ErrorMessage = "Phonenumber cannot be more than 18 characters")]
        [MinLength(11, ErrorMessage = "Phonenumber cannot be less than 11 characters")]
        public string PhoneNo { get; set; }

        public string OtherName { get; set; }

        [Required(ErrorMessage = "Select a country")]
        public int  CountryId { get; set; }

        [Required(ErrorMessage = "Select a state")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Selfie is required")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Passport is required")]
        public DocumentDto Document { get; set; }

    }
}
