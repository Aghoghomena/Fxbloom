using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.CustomerAggregate.DTOs
{
    class StateDTO
    {
        public int StateId { get; private set; }
        public int CountryId { get; private set; }
        public string Statename { get; private set; }

        public static explicit operator State(StateDTO dt)
        {
            return JsonConvert.DeserializeObject<State>(JsonConvert.SerializeObject(dt));
        }
    }
}
