using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class CustomerStatusDto
    {
        [EnumDataType(typeof(CustomerStatus), ErrorMessage = "Enter a valid Currency Type")]
        [Required(ErrorMessage = "Customer Status is Required")]
        public CustomerStatus CustomerStatus { get; set; }
    }
}
