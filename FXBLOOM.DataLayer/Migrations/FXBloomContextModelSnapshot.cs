﻿// <auto-generated />
using System;
using FXBLOOM.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FXBLOOM.DataLayer.Migrations
{
    [DbContext(typeof(FXBloomContext))]
    partial class FXBloomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Bid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AmountId")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ListingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AmountId");

                    b.HasIndex("ListingId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dateadded")
                        .HasColumnType("datetime2");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateConfirmed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OtherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("IDNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Document");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Listing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AmountAvailableId")
                        .HasColumnType("int");

                    b.Property<int?>("AmountNeededId")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinalized")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmountAvailableId");

                    b.HasIndex("AmountNeededId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Listing");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Bid", b =>
                {
                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Currency", "Amount")
                        .WithMany()
                        .HasForeignKey("AmountId");

                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Listing", null)
                        .WithMany("Bids")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amount");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Customer", b =>
                {
                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Country", "Country")
                        .WithMany("Customers")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("CustomerCountry");

                    b.OwnsOne("FXBLOOM.DomainLayer.CustomerAggregate.Account", "Account", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("AccountNumber")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("BankName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId")
                                .IsUnique();

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Document", b =>
                {
                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Customer", null)
                        .WithOne("Documentation")
                        .HasForeignKey("FXBLOOM.DomainLayer.CustomerAggregate.Document", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Listing", b =>
                {
                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Currency", "AmountAvailable")
                        .WithMany()
                        .HasForeignKey("AmountAvailableId");

                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Currency", "AmountNeeded")
                        .WithMany()
                        .HasForeignKey("AmountNeededId");

                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Customer", null)
                        .WithMany("Listings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmountAvailable");

                    b.Navigation("AmountNeeded");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Country", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Customer", b =>
                {
                    b.Navigation("Documentation");

                    b.Navigation("Listings");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Listing", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
