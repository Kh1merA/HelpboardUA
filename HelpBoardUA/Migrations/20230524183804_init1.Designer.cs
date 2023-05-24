﻿// <auto-generated />
using System;
using HelpBoardUA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelpBoardUA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230524183804_init1")]
    partial class init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HelpBoardUA.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("_VPO_Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("_registrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HelpBoardUA.Models.DayForRecieve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("DayForRecieve");
                });

            modelBuilder.Entity("HelpBoardUA.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_organizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("_publicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_subTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("_organizationId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("HelpBoardUA.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("_finishDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("_organizationId")
                        .HasColumnType("int");

                    b.Property<string>("_subtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("_organizationId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("HelpBoardUA.Models.OfferClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OfferId");

                    b.ToTable("OfferClient");
                });

            modelBuilder.Entity("HelpBoardUA.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("HelpBoardUA.Models.DayForRecieve", b =>
                {
                    b.HasOne("HelpBoardUA.Models.Offer", "Offer")
                        .WithMany("DaysForRecieve")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("HelpBoardUA.Models.News", b =>
                {
                    b.HasOne("HelpBoardUA.Models.Organization", "_organization")
                        .WithMany()
                        .HasForeignKey("_organizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_organization");
                });

            modelBuilder.Entity("HelpBoardUA.Models.Offer", b =>
                {
                    b.HasOne("HelpBoardUA.Models.Organization", "_organization")
                        .WithMany()
                        .HasForeignKey("_organizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_organization");
                });

            modelBuilder.Entity("HelpBoardUA.Models.OfferClient", b =>
                {
                    b.HasOne("HelpBoardUA.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpBoardUA.Models.Offer", "Offer")
                        .WithMany("OfferClients")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("HelpBoardUA.Models.Offer", b =>
                {
                    b.Navigation("DaysForRecieve");

                    b.Navigation("OfferClients");
                });
#pragma warning restore 612, 618
        }
    }
}
