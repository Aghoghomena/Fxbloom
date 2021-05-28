using FXBLOOM.DomainLayer.AdminAggregate.DTOs;
using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DomainLayer.AdminAggregate
{
    public class Admin : Entity<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Admin(): base(Guid.NewGuid())
        {

        }

        public static Admin GetAdmin(AdminDto adminDto)
        {
            Admin admin = new Admin();
            admin.FirstName = adminDto.FirstName;
            admin.LastName = adminDto.LastName;

            return admin;
        }
    }
}
