﻿// <auto-generated />
using System;
using CoronaData.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoronaData.Migrations
{
    [DbContext(typeof(CoronaDataContext))]
    [Migration("20200922062836_Storing Enum as String")]
    partial class StoringEnumasString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoronaData.Models.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bus")
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<int>("GemeenteId")
                        .HasColumnType("int");

                    b.Property<string>("Huisnr")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<string>("Straatnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GemeenteId");

                    b.ToTable("Adressen");
                });

            modelBuilder.Entity("CoronaData.Models.Bestellijn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int?>("BestellingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BestellingId");

                    b.HasIndex("ProductId");

                    b.ToTable("Bestellijnen");
                });

            modelBuilder.Entity("CoronaData.Models.Bestelling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Bestellingen");
                });

            modelBuilder.Entity("CoronaData.Models.Gemeente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Gemeenten");
                });

            modelBuilder.Entity("CoronaData.Models.Klant", b =>
                {
                    b.Property<int>("Klantnr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Familienaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Gsmnr")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Telefoonnr")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Klantnr");

                    b.HasIndex("AdresId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("CoronaData.Models.Locatie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.ToTable("Locaties");
                });

            modelBuilder.Entity("CoronaData.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naam = "Mondmasker Herbruikbaar Zwart",
                            Prijs = 4.99m,
                            Type = "mondmasker"
                        },
                        new
                        {
                            Id = 2,
                            Naam = "Mondmasker Herbruikbaar Wit",
                            Prijs = 4.99m,
                            Type = "mondmasker"
                        },
                        new
                        {
                            Id = 3,
                            Naam = "Wegwerp Mondmasker 5 stuks",
                            Prijs = 4.75m,
                            Type = "mondmasker"
                        },
                        new
                        {
                            Id = 4,
                            Naam = "Wegwerp Mondmasker 10 stuks",
                            Prijs = 7.5m,
                            Type = "mondmasker"
                        },
                        new
                        {
                            Id = 5,
                            Naam = "HandSanitizer 150ml",
                            Prijs = 4.0m,
                            Type = "handgel"
                        },
                        new
                        {
                            Id = 6,
                            Naam = "HandSanitizer 500ml",
                            Prijs = 9.95m,
                            Type = "handgel"
                        },
                        new
                        {
                            Id = 7,
                            Naam = "Ontsmettingsalcohol 70% 250ml",
                            Prijs = 6.0m,
                            Type = "ontsmettingsalcohol"
                        },
                        new
                        {
                            Id = 8,
                            Naam = "Ontsmettingsalcohol 90% 250ml",
                            Prijs = 12.5m,
                            Type = "ontsmettingsalcohol"
                        });
                });

            modelBuilder.Entity("CoronaData.Models.Adres", b =>
                {
                    b.HasOne("CoronaData.Models.Gemeente", "Gemeente")
                        .WithMany("Adressen")
                        .HasForeignKey("GemeenteId")
                        .HasConstraintName("FK_Gemeente_Adres")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoronaData.Models.Bestellijn", b =>
                {
                    b.HasOne("CoronaData.Models.Bestelling", "Bestelling")
                        .WithMany("Bestellijnen")
                        .HasForeignKey("BestellingId");

                    b.HasOne("CoronaData.Models.Product", "Product")
                        .WithMany("Bestellijnen")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Bestellijn_Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoronaData.Models.Bestelling", b =>
                {
                    b.HasOne("CoronaData.Models.Klant", "Klant")
                        .WithMany("Bestellingen")
                        .HasForeignKey("KlantId")
                        .HasConstraintName("FK_Klant_Bestelling")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoronaData.Models.Klant", b =>
                {
                    b.HasOne("CoronaData.Models.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");
                });

            modelBuilder.Entity("CoronaData.Models.Locatie", b =>
                {
                    b.HasOne("CoronaData.Models.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");
                });
#pragma warning restore 612, 618
        }
    }
}
