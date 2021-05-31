using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    class CountryDTO
    {
        public int CountryId { get; private set; }
        public string CountryName { get; private set; }

        public static explicit operator Country(CountryDTO dt)
        {
            return JsonConvert.DeserializeObject<Country>(JsonConvert.SerializeObject(dt));
        }
    }
}
