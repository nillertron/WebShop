﻿// <auto-generated />
using System;
using DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAcces.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200713094241_InitDb2")]
    partial class InitDb2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.WS_Distributør", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .HasColumnType("text");

                    b.Property<string>("CVR")
                        .HasColumnType("text");

                    b.Property<string>("Navn")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WS_Distributør");
                });

            modelBuilder.Entity("Model.WS_Ordre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Bestilt")
                        .HasColumnType("datetime");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WS_Ordre");
                });

            modelBuilder.Entity("Model.WS_OrdreLinje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<double>("EnhedsPris")
                        .HasColumnType("double");

                    b.Property<int?>("OrdreId")
                        .HasColumnType("int");

                    b.Property<int?>("VareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdreId");

                    b.HasIndex("VareId");

                    b.ToTable("WS_OrdreLinje");
                });

            modelBuilder.Entity("Model.WS_Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Distrikt")
                        .HasColumnType("text");

                    b.Property<int>("PostNr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WS_Post");
                });

            modelBuilder.Entity("Model.WS_Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WS_Rank");
                });

            modelBuilder.Entity("Model.WS_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PostNrId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostNrId");

                    b.ToTable("WS_User");
                });

            modelBuilder.Entity("Model.WS_UserRank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("RankId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("UserId");

                    b.ToTable("WS_UserRank");
                });

            modelBuilder.Entity("Model.WS_Vare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AntalLager")
                        .HasColumnType("int");

                    b.Property<int?>("DistributørId")
                        .HasColumnType("int");

                    b.Property<double>("IndkøbsPris")
                        .HasColumnType("double");

                    b.Property<string>("Navn")
                        .HasColumnType("text");

                    b.Property<double>("Pris")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DistributørId");

                    b.ToTable("WS_Vare");
                });

            modelBuilder.Entity("Model.WS_Ordre", b =>
                {
                    b.HasOne("Model.WS_User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Model.WS_OrdreLinje", b =>
                {
                    b.HasOne("Model.WS_Ordre", "Ordre")
                        .WithMany()
                        .HasForeignKey("OrdreId");

                    b.HasOne("Model.WS_Vare", "Vare")
                        .WithMany()
                        .HasForeignKey("VareId");
                });

            modelBuilder.Entity("Model.WS_User", b =>
                {
                    b.HasOne("Model.WS_Post", "PostNr")
                        .WithMany()
                        .HasForeignKey("PostNrId");
                });

            modelBuilder.Entity("Model.WS_UserRank", b =>
                {
                    b.HasOne("Model.WS_Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId");

                    b.HasOne("Model.WS_User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Model.WS_Vare", b =>
                {
                    b.HasOne("Model.WS_Distributør", "Distributør")
                        .WithMany()
                        .HasForeignKey("DistributørId");
                });
#pragma warning restore 612, 618
        }
    }
}