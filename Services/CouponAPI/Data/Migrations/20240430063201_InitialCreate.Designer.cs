﻿// <auto-generated />
using CouponAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CouponAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240430063201_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CouponAPI.Models.Coupon", b =>
                {
                    b.Property<int>("CouponID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("double");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CouponID");

                    b.ToTable("Coupons");
                });
#pragma warning restore 612, 618
        }
    }
}
