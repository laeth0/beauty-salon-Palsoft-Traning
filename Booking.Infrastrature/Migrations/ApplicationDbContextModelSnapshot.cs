﻿// <auto-generated />
using System;
using Booking.Infrastrature.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.Infrastrature.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking.Domain.Entities.Amenity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Amenities", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDateUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Discounts", null, t =>
                        {
                            t.HasCheckConstraint("CK_Percentage", "[Percentage] >= 0 AND [Percentage] <= 100");

                            t.HasCheckConstraint("CK_StartAndEndDate", "[EndDateUtc] > [StartDateUtc]");
                        });
                });

            modelBuilder.Entity("Booking.Domain.Entities.Residence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("EmailAddress", true);

                    b.Property<int>("FloorsNumber")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Phone", true);

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<Guid>("ResidenceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ResidenceTypeId");

                    b.ToTable("Residences", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.ResidenceBooking", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("CheckInDateUtc")
                        .HasColumnType("date");

                    b.Property<DateOnly>("CheckOutDateUtc")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestRemarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("UserId", "ResidenceId", "Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("ResidenceBookings", null, t =>
                        {
                            t.HasCheckConstraint("CK_CorrectDates", "[CheckOutDateUtc] > [CheckInDateUtc]");
                        });
                });

            modelBuilder.Entity("Booking.Domain.Entities.ResidenceOwner", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<float>("OwnershipPercentage")
                        .HasColumnType("real");

                    b.Property<DateOnly>("PurchaseDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("SaleDate")
                        .HasColumnType("date");

                    b.HasKey("UserId", "ResidenceId", "Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("ResidenceOwners", null, t =>
                        {
                            t.HasCheckConstraint("CK_OwnershipPercentage", "[OwnershipPercentage] >= 0 AND [OwnershipPercentage] <= 100");

                            t.HasCheckConstraint("CK_PurchaseAndSaleDates", "[SaleDate] > [PurchaseDate]");
                        });
                });

            modelBuilder.Entity("Booking.Domain.Entities.ResidenceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ResidenceTypes", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdultsCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PricePerNight")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.RoomAmenity", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AmenityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomId", "AmenityId", "Id");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenities", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.RoomBooking", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResidenceBookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResidenceBookingResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResidenceBookingUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoomId", "ResidenceBookingId", "Id");

                    b.HasIndex("ResidenceBookingUserId", "ResidenceBookingResidenceId", "ResidenceBookingId");

                    b.ToTable("RoomBookings", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Entities.City", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Discount", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Room", "Room")
                        .WithMany("Discounts")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Residence", b =>
                {
                    b.HasOne("Booking.Domain.Entities.City", "City")
                        .WithMany("Residences")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.ResidenceType", "ResidenceType")
                        .WithMany("Residences")
                        .HasForeignKey("ResidenceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("ResidenceType");
                });

            modelBuilder.Entity("Booking.Domain.Entities.ResidenceBooking", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Residence", "Residence")
                        .WithMany("ResidenceBookings")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.ApplicationUser", "User")
                        .WithMany("ResidenceBookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Booking.Domain.Entities.ResidenceOwner", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Residence", "Residence")
                        .WithMany("ResidenceOwners")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.ApplicationUser", "User")
                        .WithMany("ResidenceOwners")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Review", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Residence", "Residence")
                        .WithMany("Reviews")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residence");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Room", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Residence", "Residence")
                        .WithMany("Rooms")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Residence");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Booking.Domain.Entities.RoomAmenity", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Booking.Domain.Entities.RoomBooking", b =>
                {
                    b.HasOne("Booking.Domain.Entities.Room", "Room")
                        .WithMany("RoomBookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.ResidenceBooking", "ResidenceBooking")
                        .WithMany()
                        .HasForeignKey("ResidenceBookingUserId", "ResidenceBookingResidenceId", "ResidenceBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResidenceBooking");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Booking.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Booking.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Booking.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Domain.Entities.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Booking.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ResidenceBookings");

                    b.Navigation("ResidenceOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Booking.Domain.Entities.City", b =>
                {
                    b.Navigation("Residences");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Residence", b =>
                {
                    b.Navigation("ResidenceBookings");

                    b.Navigation("ResidenceOwners");

                    b.Navigation("Reviews");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Booking.Domain.Entities.ResidenceType", b =>
                {
                    b.Navigation("Residences");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Room", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("RoomAmenities");

                    b.Navigation("RoomBookings");
                });

            modelBuilder.Entity("Booking.Domain.Entities.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
