using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Implementation
{
    public class ListingRepository : ManagerBase<Listing>, IListingRepository
    {
        public ListingRepository(FXBloomContext context):base(context)
        {

        }
    }
}
