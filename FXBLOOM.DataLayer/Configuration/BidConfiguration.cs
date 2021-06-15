using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Configuration
{
    class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(e => e.Amount, a => 
            {
                a.Property(d => d.Amount).HasColumnType("decimal(18,4)").IsRequired();
                a.Property(d => d.CurrencyType).IsRequired();
            });

        }
    }
}
