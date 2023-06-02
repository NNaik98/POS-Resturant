﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSAPI;

#nullable disable

namespace POSAPI.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("POSAPI.EffectiveDating.Snapshot", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("EffectiveDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Snapshots");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Snapshot");
                });

            modelBuilder.Entity("POSAPI.src.MenuCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("MenuCategories");
                });

            modelBuilder.Entity("POSAPI.src.SalesItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("SalesItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SalesItem");
                });

            modelBuilder.Entity("POSAPI.src.SystemUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("POSAPI.src.MenuItem", b =>
                {
                    b.HasBaseType("POSAPI.src.SalesItem");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.HasIndex("CategoryId");

                    b.HasDiscriminator().HasValue("MenuItem");
                });

            modelBuilder.Entity("POSAPI.src.MenuItemSnapshot", b =>
                {
                    b.HasBaseType("POSAPI.EffectiveDating.Snapshot");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasIndex("ItemId");

                    b.HasDiscriminator().HasValue("MenuItemSnapshot");
                });

            modelBuilder.Entity("POSAPI.src.OpenItem", b =>
                {
                    b.HasBaseType("POSAPI.src.SalesItem");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasDiscriminator().HasValue("OpenItem");
                });

            modelBuilder.Entity("POSAPI.src.MenuItem", b =>
                {
                    b.HasOne("POSAPI.src.MenuCategory", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("POSAPI.src.MenuItemSnapshot", b =>
                {
                    b.HasOne("POSAPI.src.MenuItem", "Item")
                        .WithMany("Versions")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("POSAPI.src.MenuCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("POSAPI.src.MenuItem", b =>
                {
                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
