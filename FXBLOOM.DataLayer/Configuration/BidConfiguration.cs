using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Configuration
{
    class BidConfiguration: IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Amount).HasColumnType("decimal(18,4)").IsRequired();

        }
}
}
