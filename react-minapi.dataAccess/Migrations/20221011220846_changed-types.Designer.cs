﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using react_minapi.dataAccess.Models;

#nullable disable

namespace react_minapi.dataAccess.Migrations
{
    [DbContext(typeof(RunningContext))]
    [Migration("20221011220846_changed-types")]
    partial class changedtypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("react_minapi.dataAccess.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float>("Distance")
                        .HasColumnType("REAL");

                    b.Property<int>("Feel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Time")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("react_minapi.dataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("react_minapi.dataAccess.Models.Training", b =>
                {
                    b.HasOne("react_minapi.dataAccess.Models.User", "User")
                        .WithMany("Trainings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("react_minapi.dataAccess.Models.User", b =>
                {
                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
