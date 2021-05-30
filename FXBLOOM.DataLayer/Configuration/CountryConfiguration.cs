using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Configuration
{
    class CountryConfiguration: IEntityTypeConfiguration<Country>
    {

            public void Configure(EntityTypeBuilder<Country> builder)
            {
                builder.HasKey(e => e.CountryId);
                builder.Property(e => e.CountryId).ValueGeneratedOnAdd();
                builder.Property(e => e.CountryName).HasMaxLength(500).IsRequired();

            }

        
    }
}
