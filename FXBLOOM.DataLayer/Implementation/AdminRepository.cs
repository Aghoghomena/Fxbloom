using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.AdminAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Implementation
{
    public class AdminRepository:ManagerBase<Admin>, IAdminRepository
    {
        public AdminRepository(FXBloomContext context):base(context)
        {

        }
    }
}
