﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SMS_R_FoodApi.Data;

#nullable disable

namespace SMS_R_FoodApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250324163616_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SMS_R_FoodApi.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ItemDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemRate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SMS_R_FoodApi.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FoodCenterAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FoodCenterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SaleDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SMS_R_FoodApi.Models.SaleParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemQuantity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemRate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SaleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleParameter");
                });

            modelBuilder.Entity("SMS_R_FoodApi.Models.SaleParameter", b =>
                {
                    b.HasOne("SMS_R_FoodApi.Models.Sale", null)
                        .WithMany("Items")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("SMS_R_FoodApi.Models.Sale", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
