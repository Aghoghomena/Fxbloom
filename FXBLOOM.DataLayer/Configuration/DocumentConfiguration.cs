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
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            //builder.HasForeignKey("CustomerId");
           

        }
    
    }
}
