using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.SharedKernel
{
    public static class Enumerations
    {
        public enum DocumentType
        {
            NIMC,
            DRIVERS_LICENSE,
            INTERNATIONAL_PASSPORT
        }

        public enum ListingStatus
        {
            OPEN = 1,
            REMOVED = 2,
            NEGOTIATION = 3,
            FINALIZED = 4
        }

        public enum CurrencyType
        {
            NGN = 1,
            EUR = 2
        }

        public enum CustomerStatus
        {
            CONFIRMED = 1,
            REJECTED = 2,
            PENDING = 3
        }
    }
}
