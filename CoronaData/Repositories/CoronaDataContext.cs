using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Soort = CoronaData.Models.Soort;

namespace CoronaData.Repositories
{
    public class CoronaDataContext : DbContext
    {
        public static IConfigurationRoot configuration;
        private bool testMode = false;

		//DbSets

		public virtual DbSet<Klant> Klanten { get; set; }
		public virtual DbSet<Product> Producten { get; set; }
		public virtual DbSet<Bestellijn> Bestellijnen { get; set; }
		public virtual DbSet<Bestelling> Bestellingen { get; set; }
		public virtual DbSet<Locatie> Locaties { get; set; }
		public virtual DbSet<Adres> Adressen { get; set; }
		public virtual DbSet<Gemeente> Gemeenten { get; set; }
		public virtual DbSet<Soort> Soorten { get; set; }

        //Constructors

        public CoronaDataContext() { }
        public CoronaDataContext(DbContextOptions<CoronaDataContext> options): base(options) { }

		//Logging

		private ILoggerFactory GetLoggerFactory()
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddLogging
			(
			builder => builder.AddConsole()
			.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
			);
			return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
		}

		//configuring

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Zoek de naam in de connectionStrings section - appsettings.json
				configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
					//.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", false)
					 .Build();
				var connectionString = configuration.GetConnectionString("coronaData");
				if (connectionString != null) // Indien de naam is gevonden
				{
					optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(150));
					
				}
			}
			else
			{
				testMode = true;
			}
		}

		//ModelCreating

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Klant
			modelBuilder.Entity<Klant>().ToTable("Klanten");
			modelBuilder.Entity<Klant>().HasKey(klant => klant.Klantnr);
			modelBuilder.Entity<Klant>().Property(klant => klant.Familienaam).HasMaxLength(50);
			modelBuilder.Entity<Klant>().Property(klant => klant.Voornaam).HasMaxLength(50);
			modelBuilder.Entity<Klant>().Property(klant => klant.Telefoonnr).HasMaxLength(15);
			modelBuilder.Entity<Klant>().Property(klant => klant.Gsmnr).HasMaxLength(15);
			modelBuilder.Entity<Klant>().Property(klant => klant.Email);
			modelBuilder.Entity<Klant>().HasOne(klant => klant.Adres);
			

            //Product
            modelBuilder.Entity<Product>().ToTable("Producten");
			modelBuilder.Entity<Product>().HasKey(product => product.Id);
			modelBuilder.Entity<Product>().Property(product => product.Naam).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Product>().HasOne(product => product.Soort)
				.WithMany(product => product.Producten)
				.HasForeignKey(product => product.SoortId)
				.HasConstraintName("FK_Soort_Product");
			modelBuilder.Entity<Product>().Property(product => product.Prijs).IsRequired();

			//Type
			modelBuilder.Entity<Soort>().ToTable("ProductSoorten");
			modelBuilder.Entity<Soort>().HasKey(soort => soort.Id);
			modelBuilder.Entity<Soort>().Property(soort => soort.Naam).HasMaxLength(50).IsRequired();
			

			//Bestellijn
			modelBuilder.Entity<Bestellijn>().ToTable("Bestellijnen");
			modelBuilder.Entity<Bestellijn>().HasKey(bestellijn => bestellijn.Id);
			modelBuilder.Entity<Bestellijn>().HasOne(bestellijn => bestellijn.Product)
				.WithMany(bestellijn => bestellijn.Bestellijnen)
				.HasForeignKey(bestellijn => bestellijn.ProductId)
				.HasConstraintName("FK_Bestellijn_Product");
			modelBuilder.Entity<Bestellijn>().Property(bestellijn => bestellijn.Aantal);

			//Bestelling
			modelBuilder.Entity<Bestelling>().ToTable("Bestellingen");
			modelBuilder.Entity<Bestelling>().HasKey(bestelling => bestelling.Id);
			modelBuilder.Entity<Bestelling>().HasOne(bestelling => bestelling.Klant)
				.WithMany(bestelling => bestelling.Bestellingen)
				.HasForeignKey(bestelling => bestelling.KlantId)
				.HasConstraintName("FK_Klant_Bestelling");

			//Adres
			modelBuilder.Entity<Adres>().ToTable("Adressen");
			modelBuilder.Entity<Adres>().HasKey(adres => adres.Id);
			modelBuilder.Entity<Adres>().Property(adres => adres.Straatnaam).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Adres>().Property(adres => adres.Huisnr).HasMaxLength(7).IsRequired();
			modelBuilder.Entity<Adres>().Property(adres => adres.Bus).HasMaxLength(7);
			modelBuilder.Entity<Adres>().HasOne(adres => adres.Gemeente)
				.WithMany(adres => adres.Adressen)
				.HasForeignKey(adres => adres.GemeenteId)
				.HasConstraintName("FK_Gemeente_Adres");

			//Gemeente
			modelBuilder.Entity<Gemeente>().ToTable("Gemeenten");
			modelBuilder.Entity<Gemeente>().HasKey(gemeente => gemeente.Id);
			modelBuilder.Entity<Gemeente>().Property(gemeente => gemeente.Naam).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Gemeente>().Property(gemeente => gemeente.Postcode).IsRequired().HasMaxLength(4);

			//Locatie
			modelBuilder.Entity<Locatie>().ToTable("Locaties");
			modelBuilder.Entity<Locatie>().HasKey(locatie => locatie.Id);
			modelBuilder.Entity<Locatie>().Property(locatie => locatie.Naam);
			modelBuilder.Entity<Locatie>().HasOne(locatie => locatie.Adres);

			// SEEDING PRODUCTEN
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Naam = "Mondmasker Herbruikbaar Zwart", Prijs = 4.99m, SoortId=1 },
				new Product { Id = 2, Naam = "Mondmasker Herbruikbaar Wit", Prijs = 4.99m, SoortId = 1 },
				new Product { Id = 3, Naam = "Wegwerp Mondmasker 5 stuks", Prijs=4.75m, SoortId = 1 },
				new Product { Id=4, Naam="Wegwerp Mondmasker 10 stuks", Prijs=7.5m, SoortId = 1 },
				new Product { Id= 5, Naam="HandSanitizer 150ml", Prijs=4.0m, SoortId = 2 },
				new Product { Id=6, Naam = "HandSanitizer 500ml", Prijs=9.95m, SoortId = 2 },
				new Product { Id = 7, Naam = "Ontsmettingsalcohol 70% 250ml", Prijs = 6.0m, SoortId = 3 },
				new Product { Id = 8, Naam = "Ontsmettingsalcohol 90% 250ml", Prijs = 12.5m, SoortId = 3 }
				);


			// SEEDING TYPES
			modelBuilder.Entity<Soort>().HasData(
				new Soort { Id = 1, Naam = "Mondmasker" },
				new Soort { Id = 2, Naam = "Handsanitizer" },
				new Soort { Id = 3, Naam = "OntsmettingsAlcohol" }
				);
        }
	}
}
