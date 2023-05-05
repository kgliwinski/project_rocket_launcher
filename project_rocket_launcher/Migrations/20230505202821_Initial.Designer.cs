﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_rocket_launcher.Models;

#nullable disable

namespace project_rocket_launcher.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230505202821_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("project_rocket_launcher.Models.FavouriteLaunch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LaunchDetailsJson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LaunchId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("detailsid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isFavourite")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("detailsid");

                    b.ToTable("FavouritesLaunches");
                });

            modelBuilder.Entity("project_rocket_launcher.Models.LaunchDetails", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("fail_rason")
                        .HasColumnType("TEXT");

                    b.Property<string>("flight_club_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("hold_reason")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastUpdate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("probability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("r_spacex_api_id")
                        .HasColumnType("TEXT");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("statusid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("window_end")
                        .HasColumnType("TEXT");

                    b.Property<string>("window_start")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("statusid");

                    b.ToTable("LaunchDetails");
                });

            modelBuilder.Entity("project_rocket_launcher.Models.LaunchStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("abbrev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("LaunchStatus");
                });

            modelBuilder.Entity("project_rocket_launcher.Models.FavouriteLaunch", b =>
                {
                    b.HasOne("project_rocket_launcher.Models.LaunchDetails", "details")
                        .WithMany()
                        .HasForeignKey("detailsid");

                    b.Navigation("details");
                });

            modelBuilder.Entity("project_rocket_launcher.Models.LaunchDetails", b =>
                {
                    b.HasOne("project_rocket_launcher.Models.LaunchStatus", "status")
                        .WithMany()
                        .HasForeignKey("statusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("status");
                });
#pragma warning restore 612, 618
        }
    }
}