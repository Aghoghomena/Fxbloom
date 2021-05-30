﻿using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class Country
    {


        public int CountryId { get; private set; }
        public string CountryName { get; private set; }

        public DateTime? Dateadded { get; private set; }

        //public virtual Customer Customers { get; set; }
        public ICollection<Customer> Customers { get;  set; }


    }
}
