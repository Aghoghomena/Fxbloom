using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Configuration
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.OwnsOne(e => e.AmountAvailable, d =>
            {
                d.Property(a => a.Amount).IsRequired();
                d.Property(a => a.CurrencyType).IsRequired();
                d.Property(e => e.Amount).HasColumnType("decimal(18,4)").IsRequired();
            });

            builder.OwnsOne(e => e.AmountNeeded, d =>
            {
                d.Property(a => a.Amount).IsRequired();
                d.Property(e => e.Amount).HasColumnType("decimal(18,4)").IsRequired();
                d.Property(a => a.CurrencyType).IsRequired();
            });

            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.Status).IsRequired();

            var bidNavigation = builder.Metadata.FindNavigation(nameof(Listing.Bids));
            bidNavigation.SetField("_bids");
            bidNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
