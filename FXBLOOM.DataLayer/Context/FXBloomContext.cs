using FXBLOOM.DomainLayer.CustomerAggregate;
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
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //handle the migrations
            ///base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Account>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Currency>()
              .Property(b => b.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<Document>()
             .Property(b => b.Id)
             .ValueGeneratedOnAdd();

            modelBuilder.Entity<Currency>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,4)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration Configuration = builder.Build();

            optionsBuilder.UseSqlServer(
                Configuration.GetConnectionString("server=DESKTOP-74QMUAQ\\TEW_SQLEXPRESSdatabase=FxBloom;Trusted_Connection=true;"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
