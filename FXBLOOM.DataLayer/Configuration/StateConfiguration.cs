using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Configuration
{
    class StateConfiguration: IEntityTypeConfiguration<State>
    {

            public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(e => e.StateId);
        builder.Property(e => e.StateId).ValueGeneratedOnAdd();
        builder.Property(e => e.Statename).HasMaxLength(500).IsRequired();

    }
}
}
