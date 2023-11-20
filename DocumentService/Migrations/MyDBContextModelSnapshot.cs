﻿// <auto-generated />
using System;
using DocumentService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocumentService.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DocumentService.Model.Assignment", b =>
                {
                    b.Property<string>("idGroup")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("idDoc")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("idGroup", "idDoc");

                    b.HasIndex("idDoc");

                    b.ToTable("assignments");
                });

            modelBuilder.Entity("DocumentService.Model.Documents", b =>
                {
                    b.Property<string>("IdDocument")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdFlight")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdType")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameDoc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocument");

                    b.HasIndex("IdFlight");

                    b.HasIndex("IdType");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DocumentService.Model.Flight", b =>
                {
                    b.Property<string>("IdFlight")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirplaneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PointOfLoading")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PointOfUnloading")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("StatusFlight")
                        .HasColumnType("bit");

                    b.HasKey("IdFlight");

                    b.ToTable("flights");
                });

            modelBuilder.Entity("DocumentService.Model.Permisstions", b =>
                {
                    b.Property<string>("idGroup")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("idType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("permisstion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idGroup", "idType");

                    b.HasIndex("idType");

                    b.ToTable("permisstions");
                });

            modelBuilder.Entity("DocumentService.Model.TypeDocument", b =>
                {
                    b.Property<string>("IdType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdType");

                    b.ToTable("typeDocuments");
                });

            modelBuilder.Entity("UserService.Model.Groups", b =>
                {
                    b.Property<string>("idGroup")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameGroup")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idGroup");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("DocumentService.Model.Assignment", b =>
                {
                    b.HasOne("DocumentService.Model.Documents", "documents")
                        .WithMany("Assignments")
                        .HasForeignKey("idDoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_assignment_document");

                    b.HasOne("UserService.Model.Groups", "groups")
                        .WithMany("Assignments")
                        .HasForeignKey("idGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_phancong_group");

                    b.Navigation("documents");

                    b.Navigation("groups");
                });

            modelBuilder.Entity("DocumentService.Model.Documents", b =>
                {
                    b.HasOne("DocumentService.Model.Flight", "flight")
                        .WithMany("documents")
                        .HasForeignKey("IdFlight")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentService.Model.TypeDocument", "typeDocument")
                        .WithMany("documents")
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flight");

                    b.Navigation("typeDocument");
                });

            modelBuilder.Entity("DocumentService.Model.Permisstions", b =>
                {
                    b.HasOne("UserService.Model.Groups", "groups")
                        .WithMany("Permisstions")
                        .HasForeignKey("idGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_quyen_group");

                    b.HasOne("DocumentService.Model.TypeDocument", "type")
                        .WithMany("Permisstions")
                        .HasForeignKey("idType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_quyen_type");

                    b.Navigation("groups");

                    b.Navigation("type");
                });

            modelBuilder.Entity("DocumentService.Model.Documents", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("DocumentService.Model.Flight", b =>
                {
                    b.Navigation("documents");
                });

            modelBuilder.Entity("DocumentService.Model.TypeDocument", b =>
                {
                    b.Navigation("Permisstions");

                    b.Navigation("documents");
                });

            modelBuilder.Entity("UserService.Model.Groups", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Permisstions");
                });
#pragma warning restore 612, 618
        }
    }
}
