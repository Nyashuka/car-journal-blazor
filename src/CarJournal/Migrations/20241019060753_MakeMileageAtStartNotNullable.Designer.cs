﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarJournal.Migrations
{
    [DbContext(typeof(CarJournalDbContext))]
    [Migration("20241019060753_MakeMileageAtStartNotNullable")]
    partial class MakeMileageAtStartNotNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarJournal.Domain.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("BodyTypes", (string)null);
                });

            modelBuilder.Entity("CarJournal.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("EngineId")
                        .HasColumnType("integer");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("GearboxId")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("EngineId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("GearboxId");

                    b.HasIndex("Model")
                        .IsUnique();

                    b.HasIndex("VendorId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarJournal.Domain.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("EngineSize")
                        .HasColumnType("real");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("Engines", (string)null);
                });

            modelBuilder.Entity("CarJournal.Domain.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes", (string)null);
                });

            modelBuilder.Entity("CarJournal.Domain.Gearbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("Gearboxes", (string)null);
                });

            modelBuilder.Entity("CarJournal.Domain.MileageRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAutomatic")
                        .HasColumnType("boolean");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserCarId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserCarId");

                    b.ToTable("MileageRecords");
                });

            modelBuilder.Entity("CarJournal.Domain.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("CarJournal.Domain.ServiceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfService")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserCarId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.HasIndex("UserCarId");

                    b.ToTable("ServiceRecords");
                });

            modelBuilder.Entity("CarJournal.Domain.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LimitMileage")
                        .HasColumnType("integer");

                    b.Property<string>("MessageForReminder")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("MileageAtStart")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("TotalMileage")
                        .HasColumnType("integer");

                    b.Property<int>("TrackingType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserCarId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserCarId");

                    b.ToTable("Trackings", (string)null);
                });

            modelBuilder.Entity("CarJournal.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "admin",
                            PasswordHash = new byte[] { 207, 30, 148, 127, 214, 231, 181, 106, 213, 231, 6, 142, 232, 174, 190, 178, 98, 190, 154, 246, 48, 225, 43, 204, 6, 221, 42, 148, 93, 141, 209, 138, 158, 249, 189, 180, 100, 190, 233, 199, 226, 168, 231, 61, 236, 122, 90, 131, 114, 32, 143, 112, 99, 81, 49, 189, 78, 99, 54, 214, 204, 103, 16, 223 },
                            PasswordSalt = new byte[] { 225, 6, 95, 11, 205, 153, 33, 105, 89, 90, 167, 233, 213, 192, 182, 200, 8, 183, 34, 106, 248, 33, 13, 168, 26, 17, 47, 3, 250, 121, 156, 164, 102, 148, 7, 118, 16, 52, 244, 177, 226, 78, 15, 68, 52, 47, 184, 218, 229, 96, 164, 63, 28, 162, 116, 108, 57, 62, 81, 67, 219, 56, 93, 133, 85, 83, 239, 84, 153, 152, 138, 31, 198, 103, 172, 13, 189, 89, 215, 204, 150, 203, 100, 134, 210, 1, 252, 251, 2, 235, 170, 27, 61, 227, 135, 76, 130, 139, 100, 110, 50, 218, 167, 245, 241, 248, 245, 46, 246, 123, 166, 244, 180, 255, 88, 44, 2, 51, 228, 169, 52, 191, 15, 82, 47, 250, 164, 17 },
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("CarJournal.Domain.UserCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AverageMileage")
                        .HasColumnType("integer");

                    b.Property<int?>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentMileage")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfAdd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("StartMileage")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCars");
                });

            modelBuilder.Entity("CarJournal.Domain.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Vendors", (string)null);
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "user"
                        },
                        new
                        {
                            Id = 2,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("CarJournal.Domain.Car", b =>
                {
                    b.HasOne("CarJournal.Domain.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarJournal.Domain.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarJournal.Domain.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarJournal.Domain.Gearbox", "Gearbox")
                        .WithMany()
                        .HasForeignKey("GearboxId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarJournal.Domain.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("Engine");

                    b.Navigation("FuelType");

                    b.Navigation("Gearbox");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("CarJournal.Domain.MileageRecord", b =>
                {
                    b.HasOne("CarJournal.Domain.UserCar", "UserCar")
                        .WithMany()
                        .HasForeignKey("UserCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("CarJournal.Domain.ServiceRecord", b =>
                {
                    b.HasOne("CarJournal.Domain.ServiceCategory", "ServiceCategory")
                        .WithMany()
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarJournal.Domain.UserCar", "UserCar")
                        .WithMany()
                        .HasForeignKey("UserCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceCategory");

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("CarJournal.Domain.Tracking", b =>
                {
                    b.HasOne("CarJournal.Domain.UserCar", "UserCar")
                        .WithMany()
                        .HasForeignKey("UserCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCar");
                });

            modelBuilder.Entity("CarJournal.Domain.User", b =>
                {
                    b.HasOne("Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarJournal.Domain.UserCar", b =>
                {
                    b.HasOne("CarJournal.Domain.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("CarJournal.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
