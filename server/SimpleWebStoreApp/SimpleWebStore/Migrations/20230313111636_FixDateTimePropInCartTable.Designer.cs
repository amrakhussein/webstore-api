﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleWebStore.Data;

#nullable disable

namespace SimpleWebStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230313111636_FixDateTimePropInCartTable")]
    partial class FixDateTimePropInCartTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleWebStore.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 3, 13, 11, 16, 36, 736, DateTimeKind.Utc).AddTicks(2166),
                            CustomerId = 1,
                            Total = 20m
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 3, 13, 11, 16, 36, 736, DateTimeKind.Utc).AddTicks(2170),
                            CustomerId = 1,
                            Total = 80m
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 3, 13, 11, 16, 36, 736, DateTimeKind.Utc).AddTicks(2171),
                            CustomerId = 1,
                            Total = 120m
                        });
                });

            modelBuilder.Entity("SimpleWebStore.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CartId = 3,
                            Price = 61.12m,
                            ProductId = 3,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            CartId = 3,
                            Price = 76.1m,
                            ProductId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 3,
                            CartId = 3,
                            Price = 71.25m,
                            ProductId = 1,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 4,
                            CartId = 3,
                            Price = 98.1m,
                            ProductId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 5,
                            CartId = 1,
                            Price = 51.55m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            CartId = 3,
                            Price = 48.81m,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 7,
                            CartId = 3,
                            Price = 73.5m,
                            ProductId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 8,
                            CartId = 2,
                            Price = 58.95m,
                            ProductId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 9,
                            CartId = 3,
                            Price = 45.35m,
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 10,
                            CartId = 1,
                            Price = 59.57m,
                            ProductId = 2,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 11,
                            CartId = 2,
                            Price = 63.28m,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 12,
                            CartId = 3,
                            Price = 81.87m,
                            ProductId = 3,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("SimpleWebStore.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Amr",
                            LastName = "Abdelkamel"
                        });
                });

            modelBuilder.Entity("SimpleWebStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Some random description",
                            Name = "Product One",
                            Price = 20m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 2,
                            Description = "Some random description",
                            Name = "Product Two",
                            Price = 40m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 3,
                            Description = "Some random description",
                            Name = "Product Three",
                            Price = 60m,
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("SimpleWebStore.Models.Cart", b =>
                {
                    b.HasOne("SimpleWebStore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SimpleWebStore.Models.CartItem", b =>
                {
                    b.HasOne("SimpleWebStore.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleWebStore.Models.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SimpleWebStore.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("SimpleWebStore.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SimpleWebStore.Models.Product", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
