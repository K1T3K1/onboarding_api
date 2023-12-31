﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnboardingApi.Entities;

#nullable disable

namespace OnboardingApi.Migrations
{
    [DbContext(typeof(DriversContext))]
    partial class DriversContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnboardingApi.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LicenseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId")
                        .IsUnique();

                    b.HasIndex("VehicleId")
                        .IsUnique()
                        .HasFilter("[VehicleId] IS NOT NULL");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("OnboardingApi.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("OnboardingApi.Entities.Driver", b =>
                {
                    b.HasOne("OnboardingApi.Entities.Vehicle", "Vehicle")
                        .WithOne("Driver")
                        .HasForeignKey("OnboardingApi.Entities.Driver", "VehicleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("OnboardingApi.Entities.Vehicle", b =>
                {
                    b.Navigation("Driver");
                });
#pragma warning restore 612, 618
        }
    }
}
