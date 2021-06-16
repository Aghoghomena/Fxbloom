using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate
{
    public class State
    {
        public int StateId { get; private set; }
        public string Statename { get; private set; }

        public int CountryId { get; private set; }

        public DateTime? Dateadded { get; private set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Customer Customers { get; private set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Country Country { get; private set; }

    }
}
