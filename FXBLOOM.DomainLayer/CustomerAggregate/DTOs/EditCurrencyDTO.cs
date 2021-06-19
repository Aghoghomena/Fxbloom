using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class EditCurrencyDTO
    {

        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Enter a valid Amount")]
        [Required(ErrorMessage = "Amount is Required")]
        public decimal Amount { get; set; }
    }
}
