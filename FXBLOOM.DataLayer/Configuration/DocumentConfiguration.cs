using FXBLOOM.DomainLayer.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FXBLOOM.DataLayer.Configuration
{
    class DocumentConfiguration:IEntityTypeConfiguration<Document>
    {

        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(s => s.DocumentType).IsRequired();
            builder.Property(s => s.IDNumber).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Img).IsRequired();
        }

    }
}
