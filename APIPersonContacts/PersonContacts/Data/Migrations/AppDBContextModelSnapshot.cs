﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonContacts.Data;

#nullable disable

namespace PersonContacts.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("PersonContacts.Data.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PersonEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            PersonEmail = "Email: DavidSmith1@gmail.com",
                            PersonName = "David Smith 01",
                            PersonPhone = "1234567890"
                        },
                        new
                        {
                            ContactId = 2,
                            PersonEmail = "Email: DavidSmith2@gmail.com",
                            PersonName = "David Smith 02",
                            PersonPhone = "2234567890"
                        },
                        new
                        {
                            ContactId = 3,
                            PersonEmail = "Email: DavidSmith3@gmail.com",
                            PersonName = "David Smith 03",
                            PersonPhone = "3234567890"
                        },
                        new
                        {
                            ContactId = 4,
                            PersonEmail = "Email: DavidSmith4@gmail.com",
                            PersonName = "David Smith 04",
                            PersonPhone = "4234567890"
                        },
                        new
                        {
                            ContactId = 5,
                            PersonEmail = "Email: DavidSmith5@gmail.com",
                            PersonName = "David Smith 05",
                            PersonPhone = "5234567890"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
