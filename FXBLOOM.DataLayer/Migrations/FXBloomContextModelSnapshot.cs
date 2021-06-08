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

                    b.Property<DateTime?>("DateConfirmed")
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

                    b.Property<string>("Img")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId")
                        .IsUnique()
                        .HasFilter("[StateId] IS NOT NULL");

                    b.ToTable("Customers");
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

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dateadded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Statename")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.SubsriptionAggregate.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("emailSent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
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

                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.State", "State")
                        .WithOne("Customers")
                        .HasForeignKey("FXBLOOM.DomainLayer.CustomerAggregate.Customer", "StateId");

                    b.OwnsOne("FXBLOOM.DomainLayer.CustomerAggregate.Account", "Account", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AccountNumber")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("BankName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("FXBLOOM.DomainLayer.CustomerAggregate.Document", "Documentation", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("DocumentType")
                                .HasColumnType("int");

                            b1.Property<string>("IDNumber")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Img")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Country");

                    b.Navigation("Documentation");

                    b.Navigation("State");
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

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.State", b =>
                {
                    b.HasOne("FXBLOOM.DomainLayer.CustomerAggregate.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Country", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Customer", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.Listing", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("FXBLOOM.DomainLayer.CustomerAggregate.State", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
