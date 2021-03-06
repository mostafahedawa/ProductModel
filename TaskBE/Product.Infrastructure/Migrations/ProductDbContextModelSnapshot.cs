﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Infrastructure.Context;

namespace Product.Infrastructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Product.Domain.Entities.DietaryFlags", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("DietaryFlags");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "vegan"
                        },
                        new
                        {
                            ID = 2,
                            Name = "lactose-free"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DietaryID");

                    b.Property<int>("NumberOfViews");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("PhotoName");

                    b.Property<double>("Price");

                    b.Property<string>("Title");

                    b.Property<int>("VendorID");

                    b.HasKey("ID");

                    b.HasIndex("DietaryID");

                    b.HasIndex("VendorID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "This is a description for product1",
                            DietaryID = 1,
                            NumberOfViews = 2,
                            Price = 20.0,
                            Title = "Product1",
                            VendorID = 1
                        },
                        new
                        {
                            ID = 2,
                            Description = "This is a description for product2",
                            DietaryID = 2,
                            NumberOfViews = 0,
                            Price = 40.0,
                            Title = "Product2",
                            VendorID = 2
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.Vendor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Vendor");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Vendor1"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Vendor2"
                        });
                });

            modelBuilder.Entity("Product.Domain.Entities.Products", b =>
                {
                    b.HasOne("Product.Domain.Entities.DietaryFlags", "DietaryFlag")
                        .WithMany("ProductList")
                        .HasForeignKey("DietaryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Product.Domain.Entities.Vendor", "Vendor")
                        .WithMany("ProductList")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
