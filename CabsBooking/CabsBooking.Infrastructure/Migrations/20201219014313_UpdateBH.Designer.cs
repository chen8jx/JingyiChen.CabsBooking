﻿// <auto-generated />
using System;
using CabsBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CabsBooking.Infrastructure.Migrations
{
    [DbContext(typeof(CabsBookingDbContext))]
    [Migration("20201219014313_UpdateBH")]
    partial class UpdateBH
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CabsBooking.Core.Entities.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("BookingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("cast(getdate() as date)");

                    b.Property<string>("BookingTime")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasDefaultValueSql("convert(varchar(5),getdate(),108)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("cast(getdate() as date)");

                    b.Property<string>("PickupTime")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasDefaultValueSql("convert(varchar(5),getdate(),108)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlace");

                    b.HasIndex("ToPlace");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.BookingsHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("BookingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("cast(getdate() as date)");

                    b.Property<string>("BookingTime")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasDefaultValueSql("convert(varchar(5),getdate(),108)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Charge")
                        .HasColumnType("money");

                    b.Property<string>("Comp_Time")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasDefaultValueSql("convert(varchar(5),getdate(),108)");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<int?>("FromPlace")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PickupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("cast(getdate() as date)");

                    b.Property<string>("PickupTime")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasDefaultValueSql("convert(varchar(5),getdate(),108)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ToPlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlace");

                    b.HasIndex("ToPlace");

                    b.ToTable("Bookings_History");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.CabTypes", b =>
                {
                    b.Property<int>("CabTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CabTypeName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("CabTypeId");

                    b.ToTable("CabTypes");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.Places", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PlaceName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.Bookings", b =>
                {
                    b.HasOne("CabsBooking.Core.Entities.CabTypes", "CabTypes")
                        .WithMany("Bookings")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("CabsBooking.Core.Entities.Places", "FromPlaces")
                        .WithMany("FromPlaces")
                        .HasForeignKey("FromPlace");

                    b.HasOne("CabsBooking.Core.Entities.Places", "ToPlaces")
                        .WithMany("ToPlaces")
                        .HasForeignKey("ToPlace");

                    b.Navigation("CabTypes");

                    b.Navigation("FromPlaces");

                    b.Navigation("ToPlaces");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.BookingsHistory", b =>
                {
                    b.HasOne("CabsBooking.Core.Entities.CabTypes", "CabTypes")
                        .WithMany("BookingsHistory")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("CabsBooking.Core.Entities.Places", "FromHistory")
                        .WithMany("FromHistory")
                        .HasForeignKey("FromPlace");

                    b.HasOne("CabsBooking.Core.Entities.Places", "ToHistory")
                        .WithMany("ToHistory")
                        .HasForeignKey("ToPlace");

                    b.Navigation("CabTypes");

                    b.Navigation("FromHistory");

                    b.Navigation("ToHistory");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.CabTypes", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("BookingsHistory");
                });

            modelBuilder.Entity("CabsBooking.Core.Entities.Places", b =>
                {
                    b.Navigation("FromHistory");

                    b.Navigation("FromPlaces");

                    b.Navigation("ToHistory");

                    b.Navigation("ToPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}