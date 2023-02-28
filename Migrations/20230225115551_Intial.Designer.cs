﻿// <auto-generated />
using EF6SQLite_Roulette.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF6SQLite_Roulette.Migrations
{
    [DbContext(typeof(RouletteDbContext))]
    [Migration("20230225115551_Intial")]
    partial class Intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("EF6SQLite_Roulette.Models.WheelBoard", b =>
                {
                    b.Property<int>("wbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("wbColour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("wbNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("wbId");

                    b.ToTable("wheelBoards");
                });

            modelBuilder.Entity("EF6SQLite_Roulette.Models.WheelResult", b =>
                {
                    b.Property<int>("wrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("wrColour")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("wrNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("wrId");

                    b.ToTable("wheelResults");
                });
#pragma warning restore 612, 618
        }
    }
}
