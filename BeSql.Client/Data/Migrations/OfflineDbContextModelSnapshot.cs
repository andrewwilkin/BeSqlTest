﻿// <auto-generated />
using System;
using BeSql.Client.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeSql.Client.Data.Migrations
{
    [DbContext(typeof(OfflineDbContext))]
    partial class OfflineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("BeSql.Client.Models.CalculationResult", b =>
                {
                    b.Property<Guid>("OrganisationNodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MeasureId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MeasureMetricId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReportMonth")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("OrganisationNodeId");

                    b.ToTable("CalculationResults");
                });
#pragma warning restore 612, 618
        }
    }
}