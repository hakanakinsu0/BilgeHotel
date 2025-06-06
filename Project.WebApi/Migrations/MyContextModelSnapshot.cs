﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.WebApi.Models.ContextClasses;

#nullable disable

namespace Project.WebApi.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.WebApi.Models.Entities.UserCardInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CardLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpiryMonth")
                        .HasColumnType("int");

                    b.Property<int>("ExpiryYear")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CardInfoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 50000m,
                            CVV = "123",
                            CardLimit = 50000m,
                            CardNumber = "1111 1111 1111 1111",
                            CardUserName = "Hakan Akinsu",
                            CreatedDate = new DateTime(2025, 4, 10, 17, 48, 29, 238, DateTimeKind.Local).AddTicks(2937),
                            ExpiryMonth = 12,
                            ExpiryYear = 2026,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Balance = 75000m,
                            CVV = "456",
                            CardLimit = 75000m,
                            CardNumber = "2222 2222 2222 2222",
                            CardUserName = "Test Member",
                            CreatedDate = new DateTime(2025, 4, 10, 17, 48, 29, 238, DateTimeKind.Local).AddTicks(2950),
                            ExpiryMonth = 6,
                            ExpiryYear = 2025,
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            Balance = 100000m,
                            CVV = "789",
                            CardLimit = 100000m,
                            CardNumber = "3333 3333 3333 3333",
                            CardUserName = "Zeynep Demir",
                            CreatedDate = new DateTime(2025, 4, 10, 17, 48, 29, 238, DateTimeKind.Local).AddTicks(2952),
                            ExpiryMonth = 9,
                            ExpiryYear = 2027,
                            Status = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
