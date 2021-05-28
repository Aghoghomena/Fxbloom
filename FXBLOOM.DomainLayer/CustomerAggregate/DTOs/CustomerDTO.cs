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
    }
}
