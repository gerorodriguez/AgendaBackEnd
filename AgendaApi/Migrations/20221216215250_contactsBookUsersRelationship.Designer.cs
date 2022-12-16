﻿// <auto-generated />
using System;
using AgendaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaApi.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20221216215250_contactsBookUsersRelationship")]
    partial class contactsBookUsersRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AgendaApi.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CellPhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("TelephoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CellPhoneNumber = 11425789L,
                            Description = "Jefa",
                            Name = "Maria",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CellPhoneNumber = 34156978L,
                            Description = "Papa",
                            Name = "Pepe",
                            TelephoneNumber = 422568L,
                            UserId = 2
                        },
                        new
                        {
                            Id = 1,
                            CellPhoneNumber = 341457896L,
                            Description = "Plomero",
                            Name = "Jaimito",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("AgendaApi.Entities.ContactsBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ContactsBooks");
                });

            modelBuilder.Entity("AgendaApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "elluismidetotoras@gmail.com",
                            FirstName = "Luis Gonzalez",
                            LastName = "Gonzales",
                            Password = "lamismadesiempre",
                            UserName = "luismitoto"
                        },
                        new
                        {
                            Id = 1,
                            Email = "karenbailapiola@gmail.com",
                            FirstName = "Karen",
                            LastName = "Lasot",
                            Password = "Pa$$w0rd",
                            UserName = "karenpiola"
                        });
                });

            modelBuilder.Entity("ContactsBookUser", b =>
                {
                    b.Property<int>("ContactsBooksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContactsBooksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ContactsBookUser");
                });

            modelBuilder.Entity("AgendaApi.Entities.Contact", b =>
                {
                    b.HasOne("AgendaApi.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContactsBookUser", b =>
                {
                    b.HasOne("AgendaApi.Entities.ContactsBook", null)
                        .WithMany()
                        .HasForeignKey("ContactsBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaApi.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaApi.Entities.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
