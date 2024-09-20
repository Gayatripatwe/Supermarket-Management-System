﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supermarket_multiplemodels.Data;

#nullable disable

namespace Supermarket_Managementsystem.Migrations
{
    [DbContext(typeof(marketDbContext))]
    partial class marketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("discription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phoneno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Customerid")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("totalprice")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("Customerid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Orderitem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("orderid")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("orderid");

                    b.HasIndex("productid");

                    b.ToTable("orderitems");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("categoryid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Order", b =>
                {
                    b.HasOne("Supermarket_Managementsystem.Models.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("Customerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Orderitem", b =>
                {
                    b.HasOne("Supermarket_Managementsystem.Models.Order", "order")
                        .WithMany("orderitems")
                        .HasForeignKey("orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supermarket_Managementsystem.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Product", b =>
                {
                    b.HasOne("Supermarket_Managementsystem.Models.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Customer", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Supermarket_Managementsystem.Models.Order", b =>
                {
                    b.Navigation("orderitems");
                });
#pragma warning restore 612, 618
        }
    }
}
