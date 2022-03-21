﻿// <auto-generated />
using System;
using Medications_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Medications_API.Migrations
{
    [DbContext(typeof(MedicationsDbContext))]
    partial class MedicationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Medications_API.Models.Medications", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Medications_API.Models.MedicationsMaster", b =>
                {
                    b.Property<string>("DrugID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DrugBrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugGenericName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugStrength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrugID");

                    b.ToTable("MedicationsMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
