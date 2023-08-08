﻿// <auto-generated />
using System;
using MaintSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    [DbContext(typeof(MaintSoftDbContext))]
    [Migration("20230808162815_AddDataForRelationTable")]
    partial class AddDataForRelationTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MachineSparePart", b =>
                {
                    b.Property<int>("MachinesId")
                        .HasColumnType("int");

                    b.Property<int>("SparePartsId")
                        .HasColumnType("int");

                    b.HasKey("MachinesId", "SparePartsId");

                    b.HasIndex("SparePartsId");

                    b.ToTable("MachineSparePart");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c1b3980a-2324-4d9a-a2e2-226d1a38ce15",
                            Email = "lubo@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Lyubo",
                            IsDelete = false,
                            JobPosition = "Manager",
                            LastName = "Sokolov",
                            LockoutEnabled = false,
                            NormalizedEmail = "lubo@abv.bg",
                            NormalizedUserName = "lubo",
                            PasswordHash = "AQAAAAEAACcQAAAAEOSVkGOLpuqBOnFzhFl0BVOByjCNfaWeiiUTTewg9o8x7f88ln0LtPLRamoP0BhMig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "80fcf018-235f-4cb9-a353-02b292b10a2c",
                            TwoFactorEnabled = false,
                            UserName = "lyubo"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b8d72a76-5bc4-4500-a46f-44f07f26b167",
                            Email = "ivan@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Ivan",
                            IsDelete = false,
                            JobPosition = "Engineer",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "ivan@abv.bg",
                            NormalizedUserName = "ivan",
                            PasswordHash = "AQAAAAEAACcQAAAAED29OVt8rKTfnOq6YFMUwns1xe6kO/3PbjJdjlgpHWDjA6PR39taQCS2dv9Gom1PjA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9b714191-d408-47a0-a3f7-9861b8a9b97e",
                            TwoFactorEnabled = false,
                            UserName = "Ivan"
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.ApplicationUserAppTask", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AppTaskId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "AppTaskId");

                    b.HasIndex("AppTaskId");

                    b.ToTable("ApplicationUsersAppTasks");

                    b.HasData(
                        new
                        {
                            ApplicationUserId = "1",
                            AppTaskId = 1
                        },
                        new
                        {
                            ApplicationUserId = "1",
                            AppTaskId = 2
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.AppTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserContractorId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserCreatedId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserDeleteId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("AppTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(960),
                            Description = "Repair clutch",
                            IsDelete = false,
                            Name = "broken clutch",
                            StatusId = 1,
                            UpdatedDate = new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(997),
                            UserContractorId = "1",
                            UserCreatedId = "1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(1003),
                            Description = "Repair contactor",
                            IsDelete = false,
                            Name = "broken contactor",
                            StatusId = 2,
                            UpdatedDate = new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(1005),
                            UserContractorId = "2",
                            UserCreatedId = "1"
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserCreatedId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserDeletedId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "2",
                            Description = "Workstation",
                            IsAvailable = true,
                            IsDelete = false,
                            Name = "Laptop_p50",
                            UserCreatedId = "2"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "2",
                            Description = "smartphone",
                            IsAvailable = true,
                            IsDelete = false,
                            Name = "Samsung_s20",
                            UserCreatedId = "2"
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserCreatedId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserDeletedId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "GHW1_221_314",
                            Description = "for mcb",
                            ImageUrl = "https://teeptrak.com/wp-content/uploads/2020/10/TRS-mesurervotreperformancemachine-scaled.jpeg",
                            IsDelete = false,
                            Location = "Desto",
                            Name = "Final Assembly",
                            UserCreatedId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "GHW1_386_441",
                            Description = "Magnetic tester for MCB",
                            ImageUrl = "https://img.directindustry.com/images_di/photo-g/19857-14864675.webp",
                            IsDelete = false,
                            Location = "Desto",
                            Name = "Magnetic Test",
                            UserCreatedId = "2"
                        },
                        new
                        {
                            Id = 3,
                            Code = "GHW2_386_441",
                            Description = "Thermal tester for MCB",
                            ImageUrl = "https://img.directindustry.com/images_di/photo-mg/19857-17472673.jpg",
                            IsDelete = false,
                            Location = "Desto",
                            Name = "Thermal Test",
                            UserCreatedId = "1"
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.MachineAppTask", b =>
                {
                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("AppTaskId")
                        .HasColumnType("int");

                    b.HasKey("MachineId", "AppTaskId");

                    b.HasIndex("AppTaskId");

                    b.ToTable("MachinesAppTasks");

                    b.HasData(
                        new
                        {
                            MachineId = 1,
                            AppTaskId = 1
                        },
                        new
                        {
                            MachineId = 1,
                            AppTaskId = 2
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserCreatedId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserDeletedId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Germany str.20",
                            Contacts = "+359 000 23 93",
                            Description = "Production of cylinder",
                            IsDelete = false,
                            Name = "Festo",
                            UserCreatedId = "1",
                            VAT = "GB999 99 9991"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Sofia str.Vasil Levski",
                            Contacts = "+402 000 22 93",
                            Description = "Production of sensor",
                            IsDelete = false,
                            Name = "Omron",
                            UserCreatedId = "2",
                            VAT = "BG1 232 771"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Plovdiv str.Vasil Levski",
                            Contacts = "+23 11 3345 93",
                            Description = "Production of sensor and scaner",
                            IsDelete = false,
                            Name = "IFM",
                            UserCreatedId = "1",
                            VAT = "BG1 123 334"
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UserCreatedId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserDeletedId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("SpareParts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "DSNU-16-20 ADNGF",
                            Description = "Standart cilinder",
                            ImageUrl = "https://ch.farnell.com/productimages/large/en_GB/3431515-40.jpg",
                            IsDelete = false,
                            Location = "Desto",
                            ManufacturerId = 1,
                            Name = "Cylinder",
                            Quantity = 2,
                            UserCreatedId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "ABB 07-10-30",
                            Description = "Standart contactor",
                            ImageUrl = "https://bg.farnell.com/productimages/large/en_GB/1846130-40.jpg",
                            IsDelete = false,
                            Location = "Desto",
                            ManufacturerId = 1,
                            Name = "Contactor",
                            Quantity = 1,
                            UserCreatedId = "1"
                        });
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Process"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Stopped"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MachineSparePart", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.Machine", null)
                        .WithMany()
                        .HasForeignKey("MachinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintSoft.Infrastructure.Data.SparePart", null)
                        .WithMany()
                        .HasForeignKey("SparePartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.ApplicationUserAppTask", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.AppTask", "AppTask")
                        .WithMany("ApplicationUsersAppTasks")
                        .HasForeignKey("AppTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintSoft.Infrastructure.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserAppTasks")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppTask");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.AppTask", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Asset", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Assets")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.MachineAppTask", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.AppTask", "AppTask")
                        .WithMany("MachinesAppTasks")
                        .HasForeignKey("AppTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintSoft.Infrastructure.Data.Machine", "Machine")
                        .WithMany("MachineAppTasks")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppTask");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.SparePart", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.Manufacturer", "Manufacturer")
                        .WithMany("SpareParts")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintSoft.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MaintSoft.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserAppTasks");

                    b.Navigation("Assets");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.AppTask", b =>
                {
                    b.Navigation("ApplicationUsersAppTasks");

                    b.Navigation("MachinesAppTasks");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Machine", b =>
                {
                    b.Navigation("MachineAppTasks");
                });

            modelBuilder.Entity("MaintSoft.Infrastructure.Data.Manufacturer", b =>
                {
                    b.Navigation("SpareParts");
                });
#pragma warning restore 612, 618
        }
    }
}
