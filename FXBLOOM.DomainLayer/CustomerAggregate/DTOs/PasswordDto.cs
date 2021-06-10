using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class PasswordDto
    {

        public string Password { get; set; }

        public Guid CustomerId { get; set; }
    }
}
