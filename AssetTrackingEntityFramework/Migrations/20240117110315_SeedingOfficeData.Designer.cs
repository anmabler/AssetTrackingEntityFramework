﻿// <auto-generated />
using System;
using AssetTrackingEntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetTrackingEntityFramework.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240117110315_SeedingOfficeData")]
    partial class SeedingOfficeData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssetTrackingEntityFramework.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndOfLife")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Computers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Apple",
                            EndOfLife = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "MacBook",
                            Price = 1500,
                            PurchaseDate = new DateTime(2020, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Asus",
                            EndOfLife = new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "ROG 550",
                            Price = 900,
                            PurchaseDate = new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Lenovo",
                            EndOfLife = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "D300",
                            Price = 750,
                            PurchaseDate = new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AssetTrackingEntityFramework.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CurrencyRate")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Sweden",
                            Currency = "SEK",
                            CurrencyRate = 10.46f
                        },
                        new
                        {
                            Id = 2,
                            Country = "USA",
                            Currency = "USD",
                            CurrencyRate = 1f
                        },
                        new
                        {
                            Id = 3,
                            Country = "Iceland",
                            Currency = "ISK",
                            CurrencyRate = 137.4f
                        });
                });

            modelBuilder.Entity("AssetTrackingEntityFramework.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndOfLife")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Apple",
                            EndOfLife = new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "IPhone 14",
                            Price = 1400,
                            PurchaseDate = new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Samsung",
                            EndOfLife = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "Galaxy S20+",
                            Price = 1000,
                            PurchaseDate = new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Nokia",
                            EndOfLife = new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Model = "3310",
                            Price = 100,
                            PurchaseDate = new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AssetTrackingEntityFramework.Computer", b =>
                {
                    b.HasOne("AssetTrackingEntityFramework.Office", null)
                        .WithMany("ComputersList")
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("AssetTrackingEntityFramework.Phone", b =>
                {
                    b.HasOne("AssetTrackingEntityFramework.Office", null)
                        .WithMany("PhonesList")
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("AssetTrackingEntityFramework.Office", b =>
                {
                    b.Navigation("ComputersList");

                    b.Navigation("PhonesList");
                });
#pragma warning restore 612, 618
        }
    }
}