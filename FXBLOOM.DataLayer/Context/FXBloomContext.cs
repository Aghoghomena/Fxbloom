using FXBLOOM.DataLayer.Configuration;
using FXBLOOM.DomainLayer.CustomerAggregate;
using FXBLOOM.DomainLayer.SubsriptionAggregate;
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
        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Listing> Listing { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //move all this to their configuration folders
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new ListingConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new BidConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
