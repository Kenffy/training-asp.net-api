﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220825071625_SeedVillaTableWithCreatedDate")]
    partial class SeedVillaTableWithCreatedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Models.Villa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("occupancy")
                        .HasColumnType("int");

                    b.Property<double>("rate")
                        .HasColumnType("float");

                    b.Property<int>("sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            id = 1,
                            amenity = "",
                            createdAt = new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8758),
                            details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                            name = "Royal Villa",
                            occupancy = 4,
                            rate = 200.0,
                            sqft = 550,
                            updatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 2,
                            amenity = "",
                            createdAt = new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8797),
                            details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                            name = "Premium Pool Villa",
                            occupancy = 4,
                            rate = 300.0,
                            sqft = 550,
                            updatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 3,
                            amenity = "",
                            createdAt = new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8801),
                            details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                            name = "Luxury Pool Villa",
                            occupancy = 4,
                            rate = 400.0,
                            sqft = 750,
                            updatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 4,
                            amenity = "",
                            createdAt = new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8804),
                            details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                            name = "Diamond Villa",
                            occupancy = 4,
                            rate = 550.0,
                            sqft = 900,
                            updatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 5,
                            amenity = "",
                            createdAt = new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8807),
                            details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            imageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                            name = "Diamond Pool Villa",
                            occupancy = 4,
                            rate = 600.0,
                            sqft = 1100,
                            updatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
