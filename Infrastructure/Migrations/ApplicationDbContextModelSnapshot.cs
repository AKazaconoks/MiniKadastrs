﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MvcApiApplication.Models.PropertyTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AvgPriceRegion1")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AvgPriceRegion2")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AvgPriceRegion3")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionCountRegion1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransactionCountRegion2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransactionCountRegion3")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PropertyTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
