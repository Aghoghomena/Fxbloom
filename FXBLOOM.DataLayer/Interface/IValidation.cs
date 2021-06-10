using FXBLOOM.DomainLayer.CustomerAggregate.DTOs;
using FXBLOOM.DomainLayer.ValidationAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Interface
{
    public interface IValidation
    {
        public PrivateResponse ValidateCustomer(DocumentDTO customerDTO);

        public PrivateResponse ValidateLogin(String Username, string Password);

    }
}
