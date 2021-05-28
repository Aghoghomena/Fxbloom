using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.OwnsOne(e => e.Account, a =>
            {
                a.HasKey(d => d.Id);
                a.Property(d => d.AccountNumber).IsRequired();
                a.Property(d => d.BankName).IsRequired();
            });

            builder.OwnsOne(e => e.Documentation, f =>
            {
                f.Property(s => s.DocumentType).IsRequired();
                f.Property(s => s.IDNumber).HasMaxLength(50).IsRequired();
            });

            var listingNavigation = builder.Metadata.FindNavigation(nameof(Customer.Listings));
            listingNavigation.SetField("_listings");
            listingNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
