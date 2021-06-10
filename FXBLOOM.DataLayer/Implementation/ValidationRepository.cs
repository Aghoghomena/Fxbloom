using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.DomainLayer.ValidationAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Implementation
{
    public class ValidationRepository : IValidation
    {
        public PrivateResponse ValidateCustomer(DocumentDTO customerDTO)
        {

            string response = "";
            StringBuilder sb = new StringBuilder();
            int counterror = 0;
            PrivateResponse pr = new PrivateResponse();

            if (customerDTO.FirstName == "") { sb.Append("FirstName cannnot be empty"); counterror++; };
            if (customerDTO.LastName == null) { sb.Append("LastName cannnot be empty"); counterror++; };
            if (customerDTO.Password == null) { sb.Append("Password cannnot be empty"); counterror++; };
            if (customerDTO.Email == null) { sb.Append("FirstName cannnot be empty"); counterror++; };

            if (counterror == 0)
            {
                pr.status_code = 200;

            }
            else
            {
                pr.status_code = 422;
                pr.message = sb.ToString();
            }
            return pr;

        }

        public PrivateResponse ValidateLogin(string Username, string Password)
        {

            string response = "";
            StringBuilder sb = new StringBuilder();
            int counterror = 0;
            PrivateResponse pr = new PrivateResponse();

            if (Username == "") { sb.Append("Username cannot be empty"); counterror++; };
            if (Password == "") { sb.Append("Password cannnot be empty"); counterror++; };

            if (counterror == 0)
            {
                pr.status_code = 200;

            }
            else
            {
                pr.status_code = 422;
                pr.message = sb.ToString();
            }
            return pr;

        }
    }
}
