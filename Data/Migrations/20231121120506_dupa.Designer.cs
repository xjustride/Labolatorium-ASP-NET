﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231121120506_dupa")]
    partial class dupa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Data.Entities.BookEntity", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<int>("LiteraryGenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Page_No")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("LiteraryGenreId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTime(2023, 11, 21, 13, 5, 6, 841, DateTimeKind.Local).AddTicks(3143),
                            Email = "adam@wsei.edu.pl",
                            Name = "Adam",
                            OrganizationId = 1,
                            Phone = "127813268163",
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            Birth = new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTime(2023, 11, 21, 13, 5, 6, 841, DateTimeKind.Local).AddTicks(3181),
                            Email = "ewa@wsei.edu.pl",
                            Name = "Ewa",
                            OrganizationId = 3,
                            Phone = "293443823478",
                            Priority = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.LiteraturyGenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("generes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "Powieść",
                            Type = "Audiobook"
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Kryminał",
                            Type = "Ebook"
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Przygodowa",
                            Type = "Poradnik"
                        },
                        new
                        {
                            Id = 4,
                            Genre = "Horror",
                            Type = "Książka"
                        });
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Uczelnia",
                            Name = "WSEI"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Uczelnia",
                            Name = "PJTAK"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Korporacja",
                            Name = "ABB"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Szkoła średnia",
                            Name = "Technikum Informatyczne w Poznaniu"
                        });
                });

            modelBuilder.Entity("Data.Entities.BookEntity", b =>
                {
                    b.HasOne("Data.Entities.LiteraturyGenreEntity", "LiteraryGenre")
                        .WithMany("Books")
                        .HasForeignKey("LiteraryGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteraryGenre");
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.HasOne("Data.Entities.OrganizationEntity", "Ogranization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogranization");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Adress", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Street = "Św. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    City = "Warszawa",
                                    PostalCode = "00-001",
                                    Street = "Aleje Jerozolimskie 120"
                                },
                                new
                                {
                                    OrganizationEntityId = 3,
                                    City = "Gdańsk",
                                    PostalCode = "80-001",
                                    Street = "ul. Długa 10"
                                },
                                new
                                {
                                    OrganizationEntityId = 4,
                                    City = "Poznań",
                                    PostalCode = "61-001",
                                    Street = "Stary Rynek 1"
                                });
                        });

                    b.Navigation("Adress")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.LiteraturyGenreEntity", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}