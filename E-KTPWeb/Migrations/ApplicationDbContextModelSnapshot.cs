﻿// <auto-generated />
using E_KTPWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_KTPWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_KTPWeb.Models.DataKTP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("NIK")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataKTP");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NIK = 1234567891111113L,
                            Name = "Ahmad Subardjo"
                        },
                        new
                        {
                            Id = 2,
                            NIK = 1232123456787654L,
                            Name = "Ahmad Hadsii"
                        },
                        new
                        {
                            Id = 3,
                            NIK = 1234543212345678L,
                            Name = "Surdi Nurdo"
                        }
                        );
                });
#pragma warning restore 612, 618
        }
    }
}
