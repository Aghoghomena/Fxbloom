using FXBLOOM.DataLayer.Configuration;
using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Context
{
    public class FXBloomContext: DbContext
    {
        public FXBloomContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        //public DbSet<Currency> Currencies { get; set; }

        //public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //move all this to their configuration folders
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer()
        //}

    }
}
