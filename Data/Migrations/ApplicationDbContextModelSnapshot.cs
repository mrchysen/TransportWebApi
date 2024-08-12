﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Domains.Cars.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("AddInformation")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid?>("CarDayInfoId")
                        .HasColumnType("uuid");

                    b.Property<int>("FuelBegin")
                        .HasColumnType("integer");

                    b.Property<int>("FuelEnd")
                        .HasColumnType("integer");

                    b.Property<bool>("IsWorked")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("Parking")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<bool>("Was24kmET")
                        .HasColumnType("boolean");

                    b.Property<bool>("WasScreen")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CarDayInfoId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Core.Domains.Cars.Models.CarDayInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CarDayInfos");
                });

            modelBuilder.Entity("Core.Domains.Cars.Models.Car", b =>
                {
                    b.HasOne("Core.Domains.Cars.Models.CarDayInfo", null)
                        .WithMany("Cars")
                        .HasForeignKey("CarDayInfoId");
                });

            modelBuilder.Entity("Core.Domains.Cars.Models.CarDayInfo", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
