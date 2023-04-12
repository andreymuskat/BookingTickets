﻿// <auto-generated />
using System;
using BookingTickets.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingTickets.DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingTickets.DAL.Models.CinemaDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.HallDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CinemaDtoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaDtoId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.OrderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionDtoId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserDtoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionDtoId");

                    b.HasIndex("UserDtoId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CinemaDtoId")
                        .HasColumnType("int");

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CinemaDtoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FilmDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("SeatDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HallDtoId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDtoId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HallDtoId");

                    b.HasIndex("OrderDtoId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("SessionDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmDtoId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("HallDtoId")
                        .HasColumnType("int");

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FilmDtoId");

                    b.HasIndex("HallDtoId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.HallDto", b =>
                {
                    b.HasOne("BookingTickets.DAL.Models.CinemaDto", null)
                        .WithMany("Halls")
                        .HasForeignKey("CinemaDtoId");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.OrderDto", b =>
                {
                    b.HasOne("SessionDto", "SessionDto")
                        .WithMany()
                        .HasForeignKey("SessionDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingTickets.DAL.Models.UserDto", "UserDto")
                        .WithMany()
                        .HasForeignKey("UserDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SessionDto");

                    b.Navigation("UserDto");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.UserDto", b =>
                {
                    b.HasOne("BookingTickets.DAL.Models.CinemaDto", null)
                        .WithMany("Employes")
                        .HasForeignKey("CinemaDtoId");
                });

            modelBuilder.Entity("SeatDto", b =>
                {
                    b.HasOne("BookingTickets.DAL.Models.HallDto", null)
                        .WithMany("Seats")
                        .HasForeignKey("HallDtoId");

                    b.HasOne("BookingTickets.DAL.Models.OrderDto", null)
                        .WithMany("Seats")
                        .HasForeignKey("OrderDtoId");
                });

            modelBuilder.Entity("SessionDto", b =>
                {
                    b.HasOne("FilmDto", "FilmDto")
                        .WithMany()
                        .HasForeignKey("FilmDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingTickets.DAL.Models.HallDto", "HallDto")
                        .WithMany()
                        .HasForeignKey("HallDtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmDto");

                    b.Navigation("HallDto");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.CinemaDto", b =>
                {
                    b.Navigation("Employes");

                    b.Navigation("Halls");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.HallDto", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("BookingTickets.DAL.Models.OrderDto", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
