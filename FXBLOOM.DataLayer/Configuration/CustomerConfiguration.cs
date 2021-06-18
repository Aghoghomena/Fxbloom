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
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(500);
            builder.Property(e => e.Img).HasMaxLength(500);
            builder.Property(e => e.PostalCode).HasMaxLength(100);
            builder.Property(e => e.Password);
            builder.OwnsOne(e => e.DomesticAcct, a =>
            {
                a.Property(d => d.AccountNumber).HasMaxLength(500).IsRequired();
                a.Property(d => d.BankName).HasMaxLength(100).IsRequired();
            });

            builder.OwnsOne(e => e.ForeignAcct, a =>
            {
                a.Property(d => d.AccountNumber).HasMaxLength(500).IsRequired();
                a.Property(d => d.BankName).HasMaxLength(100).IsRequired();
            });


            builder.OwnsOne(e => e.Documentation, f =>
             {
                 f.Property(s => s.DocumentType).IsRequired();
                 f.Property(s => s.IDNumber).HasMaxLength(50).IsRequired();

             });

            builder.HasOne(d => d.Country)
                     .WithMany(p => p.Customers)
                     .HasForeignKey(d => d.CountryId)
                     .HasConstraintName("CustomerCountry").IsRequired(false);

            var listingNavigation = builder.Metadata.FindNavigation(nameof(Customer.Listings));
            listingNavigation.SetField("_listings");
            listingNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
