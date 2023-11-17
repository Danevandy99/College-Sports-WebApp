﻿// <auto-generated />
using System;
using College_Sports_WebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace College_Sports_WebApp.Migrations.Postgres
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ScoreboardCallouts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GamecastLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardCallouts");
                });

            modelBuilder.Entity("ScoreboardEventInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationDetail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LocationHeadline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardEventInfo");
                });

            modelBuilder.Entity("ScoreboardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalloutsId")
                        .HasColumnType("integer");

                    b.Property<int>("EventInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("ScoreCellId")
                        .HasColumnType("integer");

                    b.Property<int?>("ScoreboardResultId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CalloutsId");

                    b.HasIndex("EventInfoId");

                    b.HasIndex("ScoreCellId");

                    b.HasIndex("ScoreboardResultId");

                    b.ToTable("ScoreboardItem");
                });

            modelBuilder.Entity("ScoreboardResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FetchDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("FilterDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardResults");
                });

            modelBuilder.Entity("ScoreboardScoreCell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardScoreCell");
                });

            modelBuilder.Entity("ScoreboardScoreCellItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAway")
                        .HasColumnType("boolean");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RecordId")
                        .HasColumnType("integer");

                    b.Property<int?>("ScoreboardScoreCellId")
                        .HasColumnType("integer");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("ScoreboardScoreCellId");

                    b.ToTable("ScoreboardScoreCellItem");
                });

            modelBuilder.Entity("ScoreboardScoreCellItemRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardScoreCellItemRecord");
                });

            modelBuilder.Entity("ScoreboardItem", b =>
                {
                    b.HasOne("ScoreboardCallouts", "Callouts")
                        .WithMany()
                        .HasForeignKey("CalloutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScoreboardEventInfo", "EventInfo")
                        .WithMany()
                        .HasForeignKey("EventInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScoreboardScoreCell", "ScoreCell")
                        .WithMany()
                        .HasForeignKey("ScoreCellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScoreboardResult", null)
                        .WithMany("ScoreboardItems")
                        .HasForeignKey("ScoreboardResultId");

                    b.Navigation("Callouts");

                    b.Navigation("EventInfo");

                    b.Navigation("ScoreCell");
                });

            modelBuilder.Entity("ScoreboardScoreCellItem", b =>
                {
                    b.HasOne("ScoreboardScoreCellItemRecord", "Record")
                        .WithMany()
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScoreboardScoreCell", null)
                        .WithMany("Competitors")
                        .HasForeignKey("ScoreboardScoreCellId");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("ScoreboardResult", b =>
                {
                    b.Navigation("ScoreboardItems");
                });

            modelBuilder.Entity("ScoreboardScoreCell", b =>
                {
                    b.Navigation("Competitors");
                });
#pragma warning restore 612, 618
        }
    }
}