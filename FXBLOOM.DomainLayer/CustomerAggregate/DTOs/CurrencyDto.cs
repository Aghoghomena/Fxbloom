﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FXBLOOM.SharedKernel.Enumerations;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    public class CurrencyDto
    {
        [EnumDataType(typeof(CurrencyType), ErrorMessage = "Enter a valid Currency Type")]
        [Required(ErrorMessage = "Currency Type is Required")]
        public CurrencyType CurrencyType { get; set; }

        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Enter a valid Amount")]
        [Required(ErrorMessage = "Amount is Required")]
        public decimal Amount { get; set; }
    }
}
