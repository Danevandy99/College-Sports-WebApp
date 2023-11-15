﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace College_Sports_WebApp.Migrations
{
    [DbContext(typeof(CustomDbContext))]
    partial class CustomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("ScoreboardCallouts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GamecastLink")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardCallouts");
                });

            modelBuilder.Entity("ScoreboardEventInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationDetail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationHeadline")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardEventInfo");
                });

            modelBuilder.Entity("ScoreboardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CalloutsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScoreCellId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScoreboardResultId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FetchDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FilterDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardResults");
                });

            modelBuilder.Entity("ScoreboardScoreCell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardScoreCell");
                });

            modelBuilder.Entity("ScoreboardScoreCellItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAway")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RecordId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScoreboardScoreCellId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("ScoreboardScoreCellId");

                    b.ToTable("ScoreboardScoreCellItem");
                });

            modelBuilder.Entity("ScoreboardScoreCellItemRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Losses")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wins")
                        .HasColumnType("INTEGER");

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
