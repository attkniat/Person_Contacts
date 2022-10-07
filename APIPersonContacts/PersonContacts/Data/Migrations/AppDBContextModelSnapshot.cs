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
                            PersonEmail = "Email: 1",
                            PersonName = "Esse nome: 1",
                            PersonPhone = "0000000000"
                        },
                        new
                        {
                            ContactId = 2,
                            PersonEmail = "Email: 2",
                            PersonName = "Esse nome: 2",
                            PersonPhone = "0000000000"
                        },
                        new
                        {
                            ContactId = 3,
                            PersonEmail = "Email: 3",
                            PersonName = "Esse nome: 3",
                            PersonPhone = "0000000000"
                        },
                        new
                        {
                            ContactId = 4,
                            PersonEmail = "Email: 4",
                            PersonName = "Esse nome: 4",
                            PersonPhone = "0000000000"
                        },
                        new
                        {
                            ContactId = 5,
                            PersonEmail = "Email: 5",
                            PersonName = "Esse nome: 5",
                            PersonPhone = "0000000000"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
