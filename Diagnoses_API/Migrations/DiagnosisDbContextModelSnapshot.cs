﻿// <auto-generated />
using Diagnoses_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diagnoses_API.Migrations
{
    [DbContext(typeof(DiagnosisDbContext))]
    partial class DiagnosisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Diagnoses_API.Models.DiagnosisMaster", b =>
                {
                    b.Property<string>("diag_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("diag_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("diag_code");

                    b.ToTable("DiagnosisMaster");
                });

            modelBuilder.Entity("Diagnoses_API.Models.DiagnosisModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("ddate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diag_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diag_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosis");
                });
#pragma warning restore 612, 618
        }
    }
}
