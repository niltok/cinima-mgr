﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cinima_mgr.Data;

#nullable disable

namespace cinima_mgr.Migrations
{
    [DbContext(typeof(MgrContext))]
    partial class MgrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("cinima_mgr.Data.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Rate")
                        .HasColumnType("REAL");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.HasIndex("EditTime", "UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("cinima_mgr.Data.DiscountTicket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Rate")
                        .HasColumnType("REAL");

                    b.Property<double>("Satisfy")
                        .HasColumnType("REAL");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UsedInId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UsedInId");

                    b.HasIndex("UserName");

                    b.ToTable("DiscountTickets");
                });

            modelBuilder.Entity("cinima_mgr.Data.Movie", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<long>("BoxOffice")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("CoverImg")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Preview")
                        .HasColumnType("TEXT");

                    b.Property<int>("RateCount")
                        .HasColumnType("INTEGER");

                    b.Property<double>("RateSum")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("cinima_mgr.Data.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double>("OriginalPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ShowId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.HasIndex("UserName");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("cinima_mgr.Data.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("cinima_mgr.Data.RoomTemplate", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PosState")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("RoomTemplates");
                });

            modelBuilder.Entity("cinima_mgr.Data.SessionState", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("cinima_mgr.Data.Show", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double>("BasePrice")
                        .HasColumnType("REAL");

                    b.Property<string>("MovieId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PosState")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomName");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("cinima_mgr.Data.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Column")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Row")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserName");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("cinima_mgr.Data.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("HeadPic")
                        .HasColumnType("BLOB");

                    b.Property<bool>("IsMgr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VIPExpireTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoviePerson", b =>
                {
                    b.Property<string>("MoviesId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonsId")
                        .HasColumnType("TEXT");

                    b.HasKey("MoviesId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("MoviePerson");
                });

            modelBuilder.Entity("cinima_mgr.Data.Comment", b =>
                {
                    b.HasOne("cinima_mgr.Data.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinima_mgr.Data.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cinima_mgr.Data.DiscountTicket", b =>
                {
                    b.HasOne("cinima_mgr.Data.Order", "UsedIn")
                        .WithMany("Discounts")
                        .HasForeignKey("UsedInId");

                    b.HasOne("cinima_mgr.Data.User", "User")
                        .WithMany("Discounts")
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsedIn");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cinima_mgr.Data.Order", b =>
                {
                    b.HasOne("cinima_mgr.Data.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinima_mgr.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cinima_mgr.Data.SessionState", b =>
                {
                    b.HasOne("cinima_mgr.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("cinima_mgr.Data.Show", b =>
                {
                    b.HasOne("cinima_mgr.Data.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinima_mgr.Data.RoomTemplate", "Room")
                        .WithMany()
                        .HasForeignKey("RoomName");

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("cinima_mgr.Data.Ticket", b =>
                {
                    b.HasOne("cinima_mgr.Data.Order", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinima_mgr.Data.User", null)
                        .WithMany("Tickets")
                        .HasForeignKey("UserName");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MoviePerson", b =>
                {
                    b.HasOne("cinima_mgr.Data.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinima_mgr.Data.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cinima_mgr.Data.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Shows");
                });

            modelBuilder.Entity("cinima_mgr.Data.Order", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("cinima_mgr.Data.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Discounts");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
