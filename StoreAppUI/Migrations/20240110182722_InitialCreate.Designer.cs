﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.DataAccess.Context;

#nullable disable

namespace StoreAppUI.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20240110182722_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("StoreApp.Model.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3891),
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 30000m,
                            ProductName = "Laptop"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3897),
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1000m,
                            ProductName = "Keyboard"
                        },
                        new
                        {
                            Id = 3,
                            CreatedTime = new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3899),
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 500m,
                            ProductName = "Mouse"
                        },
                        new
                        {
                            Id = 4,
                            CreatedTime = new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3901),
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 5000m,
                            ProductName = "Monitor"
                        },
                        new
                        {
                            Id = 5,
                            CreatedTime = new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3902),
                            ModifiedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 1500m,
                            ProductName = "Deck"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}