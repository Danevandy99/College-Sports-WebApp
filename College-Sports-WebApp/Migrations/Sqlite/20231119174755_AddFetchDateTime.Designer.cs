﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20231119174755_AddFetchDateTime")]
    partial class AddFetchDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("College_Sports_Domain.Models.ScoreboardFetch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FetchedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FilterDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("JsonResponse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardFetches");
                });
#pragma warning restore 612, 618
        }
    }
}