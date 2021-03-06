﻿// <auto-generated />
using System;
using HBSkincare.Data.Source;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HBSkincare.Migrations
{
    [DbContext(typeof(HBSkincareDBContext))]
    [Migration("20200912053942_M8")]
    partial class M8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HBSkincare.Model.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("HBSkincare.Model.RawMaterialItem", b =>
                {
                    b.Property<int>("RawMaterialItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Inci")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfMeasure")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RawMaterialItemId");

                    b.ToTable("RawMaterialItem");
                });

            modelBuilder.Entity("HBSkincare.Model.RawMaterialPurchase", b =>
                {
                    b.Property<int>("RawMaterialPurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BrokerageFees")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CashOutDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("CostPerUnit")
                        .HasColumnType("float");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("CurrentInventory")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateRecieved")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ExtendedCost")
                        .HasColumnType("float");

                    b.Property<double>("ForexRate")
                        .HasColumnType("float");

                    b.Property<double>("Gst")
                        .HasColumnType("float");

                    b.Property<double>("LandedCost")
                        .HasColumnType("float");

                    b.Property<double>("LandedCostPerUnit")
                        .HasColumnType("float");

                    b.Property<string>("LotNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pst")
                        .HasColumnType("float");

                    b.Property<double>("PurchaseSize")
                        .HasColumnType("float");

                    b.Property<int?>("RawMaterialItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ScrapDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ScrapValue")
                        .HasColumnType("float");

                    b.Property<double>("Shipping")
                        .HasColumnType("float");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierSku")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RawMaterialPurchaseId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("RawMaterialItemId");

                    b.ToTable("RawMaterialPurchase");
                });

            modelBuilder.Entity("HBSkincare.Model.RawMaterialPurchase", b =>
                {
                    b.HasOne("HBSkincare.Model.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("HBSkincare.Model.RawMaterialItem", "RawMaterial")
                        .WithMany("Purchases")
                        .HasForeignKey("RawMaterialItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
