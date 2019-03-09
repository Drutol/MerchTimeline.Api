﻿// <auto-generated />
using System;
using MerchTimeline.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MerchTimeline.DataAccess.Migrations
{
    [DbContext(typeof(TimelineDbContext))]
    [Migration("20190303125204_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MerchTimeline.Domain.Entities.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthToken");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl");

                    b.Property<long>("ItemTypeId");

                    b.Property<string>("Name");

                    b.Property<long>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("MerchItem");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchItemSlot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("MerchItemId");

                    b.Property<long?>("MerchSlotId");

                    b.HasKey("Id");

                    b.HasIndex("MerchItemId");

                    b.HasIndex("MerchSlotId");

                    b.ToTable("MerchItemSlot");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchItemUsagePeriod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<long>("MerchItemId");

                    b.Property<long>("MerchSlotId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("MerchItemId");

                    b.HasIndex("MerchSlotId");

                    b.ToTable("MerchItemUsagePeriod");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchSlot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("MerchSlot");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kind");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MerchType");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchItem", b =>
                {
                    b.HasOne("MerchTimeline.Domain.Entities.MerchType", "ItemType")
                        .WithMany("MerchItems")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MerchTimeline.Domain.Entities.AppUser", "Owner")
                        .WithMany("MerchItems")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchItemSlot", b =>
                {
                    b.HasOne("MerchTimeline.Domain.Entities.MerchItem", "MerchItem")
                        .WithMany("MerchSlots")
                        .HasForeignKey("MerchItemId");

                    b.HasOne("MerchTimeline.Domain.Entities.MerchSlot", "MerchSlot")
                        .WithMany("MerchItems")
                        .HasForeignKey("MerchSlotId");
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchItemUsagePeriod", b =>
                {
                    b.HasOne("MerchTimeline.Domain.Entities.MerchItem", "MerchItem")
                        .WithMany("UsagePeriods")
                        .HasForeignKey("MerchItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MerchTimeline.Domain.Entities.MerchSlot", "MerchSlot")
                        .WithMany("UsagePeriods")
                        .HasForeignKey("MerchSlotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MerchTimeline.Domain.Entities.MerchSlot", b =>
                {
                    b.HasOne("MerchTimeline.Domain.Entities.AppUser", "Owner")
                        .WithMany("MerchSlots")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}