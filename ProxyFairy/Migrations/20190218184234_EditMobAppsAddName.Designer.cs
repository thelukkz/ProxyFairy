﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProxyFairy.Core.Enums;
using ProxyFairy.Core.Model;
using System;

namespace ProxyFairy.Migrations
{
    [DbContext(typeof(AppIdentityDbContext))]
    [Migration("20190218184234_EditMobAppsAddName")]
    partial class EditMobAppsAddName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.AppParameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("AppParameters");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.Contract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted");

                    b.Property<long?>("MobAppId")
                        .IsRequired();

                    b.Property<int>("Month")
                        .HasMaxLength(2);

                    b.Property<bool>("ServiceDesk");

                    b.Property<long?>("SlotId")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.Property<int>("Year")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("MobAppId");

                    b.HasIndex("Month");

                    b.HasIndex("SlotId");

                    b.HasIndex("Year");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ProductOwnerId");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductOwnerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.LogGateway", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppVersion")
                        .HasMaxLength(16);

                    b.Property<string>("BundleId")
                        .HasMaxLength(50);

                    b.Property<long?>("ContractId");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DeviceId")
                        .HasMaxLength(50);

                    b.Property<string>("Exception");

                    b.Property<string>("Level")
                        .HasMaxLength(16);

                    b.Property<string>("Message")
                        .HasMaxLength(255);

                    b.Property<long?>("MobAppId");

                    b.Property<int?>("Response");

                    b.Property<string>("System")
                        .HasMaxLength(16);

                    b.Property<string>("SystemVersion")
                        .HasMaxLength(32);

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("Level");

                    b.HasIndex("MobAppId");

                    b.HasIndex("Response");

                    b.ToTable("LogsGateway");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.MobApp", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppBundle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<int>("Platform");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppBundle");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Platform");

                    b.ToTable("MobApps");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.Slot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted");

                    b.Property<int>("SlotNumber");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProxyFairy.Core.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.Contract", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.MobApp", "MobApp")
                        .WithMany("Contracts")
                        .HasForeignKey("MobAppId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProxyFairy.Core.Model.Slot", "Slot")
                        .WithMany("Contracts")
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.Customer", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.AppUser", "ProductOwner")
                        .WithMany("Customers")
                        .HasForeignKey("ProductOwnerId");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.LogGateway", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.MobApp", "MobApp")
                        .WithMany("LogGateways")
                        .HasForeignKey("MobAppId");
                });

            modelBuilder.Entity("ProxyFairy.Core.Model.MobApp", b =>
                {
                    b.HasOne("ProxyFairy.Core.Model.Customer", "Customer")
                        .WithMany("MobApps")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
