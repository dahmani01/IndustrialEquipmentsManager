﻿// <auto-generated />
using System;
using CPG_Platform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CPG_Platform.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220910144836_UpdatedDocumentsModel")]
    partial class UpdatedDocumentsModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CPG_Platform.Models.Entretient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("UserId");

                    b.ToTable("Entretients");
                });

            modelBuilder.Entity("CPG_Platform.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnService")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurshaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("CPG_Platform.Models.PieceRechange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Pieces");
                });

            modelBuilder.Entity("CPG_Platform.Models.Secteur", b =>
                {
                    b.Property<int>("SecteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SecteurId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecteurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SecteurId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("CPG_Platform.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecteurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SecteurId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CPG_Platform.Models.UploadResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("StoredFileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CPG_Platform.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("SecteurId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<bool>("isVerified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SecteurId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CPG_Platform.Models.Entretient", b =>
                {
                    b.HasOne("CPG_Platform.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPG_Platform.Models.User", "User")
                        .WithMany("Entretients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CPG_Platform.Models.Machine", b =>
                {
                    b.HasOne("CPG_Platform.Models.Service", "Service")
                        .WithMany("Machines")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CPG_Platform.Models.PieceRechange", b =>
                {
                    b.HasOne("CPG_Platform.Models.Machine", "Machine")
                        .WithMany("PieceRechanges")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("CPG_Platform.Models.Service", b =>
                {
                    b.HasOne("CPG_Platform.Models.Secteur", "Secteur")
                        .WithMany("Services")
                        .HasForeignKey("SecteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Secteur");
                });

            modelBuilder.Entity("CPG_Platform.Models.UploadResult", b =>
                {
                    b.HasOne("CPG_Platform.Models.Machine", "Machine")
                        .WithMany("Documents")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("CPG_Platform.Models.User", b =>
                {
                    b.HasOne("CPG_Platform.Models.Secteur", "Secteur")
                        .WithMany()
                        .HasForeignKey("SecteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CPG_Platform.Models.Service", null)
                        .WithMany("Users")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Secteur");
                });

            modelBuilder.Entity("CPG_Platform.Models.Machine", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("PieceRechanges");
                });

            modelBuilder.Entity("CPG_Platform.Models.Secteur", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("CPG_Platform.Models.Service", b =>
                {
                    b.Navigation("Machines");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CPG_Platform.Models.User", b =>
                {
                    b.Navigation("Entretients");
                });
#pragma warning restore 612, 618
        }
    }
}
