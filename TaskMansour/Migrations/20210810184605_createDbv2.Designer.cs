﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskMansour.Models;

namespace TaskMansour.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210810184605_createDbv2")]
    partial class createDbv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskMansour.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TaskMansour.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanySEQ")
                        .HasColumnType("int");

                    b.Property<int>("SalesRepID")
                        .HasColumnType("int");

                    b.HasKey("CompanyID");

                    b.HasIndex("SalesRepID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TaskMansour.Models.Pos", b =>
                {
                    b.Property<int>("PosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PosCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalesRepId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VisitStart")
                        .HasColumnType("datetime2");

                    b.HasKey("PosID");

                    b.HasIndex("SalesRepId");

                    b.ToTable("Pos");
                });

            modelBuilder.Entity("TaskMansour.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TaskMansour.Models.SalesRep", b =>
                {
                    b.Property<int>("SalesRepID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SalesRepName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalesRepID");

                    b.ToTable("SalesReps");
                });

            modelBuilder.Entity("TaskMansour.Models.Company", b =>
                {
                    b.HasOne("TaskMansour.Models.SalesRep", "SalesRep")
                        .WithMany("Companies")
                        .HasForeignKey("SalesRepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesRep");
                });

            modelBuilder.Entity("TaskMansour.Models.Pos", b =>
                {
                    b.HasOne("TaskMansour.Models.SalesRep", "SalesRep")
                        .WithMany("pos")
                        .HasForeignKey("SalesRepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesRep");
                });

            modelBuilder.Entity("TaskMansour.Models.Product", b =>
                {
                    b.HasOne("TaskMansour.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TaskMansour.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TaskMansour.Models.SalesRep", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("pos");
                });
#pragma warning restore 612, 618
        }
    }
}
