using CoronaData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoronaData.Repositories
{
    public class CoronaDataContext : DbContext
    {
        public static IConfigurationRoot configuration;
        private bool testMode = false;

        //DbSets

        DbSet<Klant> Klanten { get; set; }
        DbSet<Product> Producten { get; set; }
        DbSet<Bestellijn> Bestellijnen { get; set; }
        DbSet<Bestelling> Bestellingen { get; set; }
        DbSet<Locatie> Locaties { get; set; }
        DbSet<Adres> Adressen { get; set; }

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
					optionsBuilder.UseSqlServer(
					connectionString
					, options => options.MaxBatchSize(150)); // Max aantal SQL commands die kunnen doorgestuurd worden naar de database
					// .UseLoggerFactory(GetLoggerFactory())
					// .EnableSensitiveDataLogging(true) // Toont de waarden van de parameters bij de logging
					// .UseLazyLoadingProxies();
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
			modelBuilder.Entity<Klant>().Property(klant => klant.Familienaam).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Klant>().Property(klant => klant.Voornaam).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Klant>().Property(klant => klant.Telefoonnr).HasMaxLength(15);
			modelBuilder.Entity<Klant>().Property(klant => klant.Gsmnr).HasMaxLength(15);
			modelBuilder.Entity<Klant>().HasOne(klant => klant.Adres);
			

            //Product
            modelBuilder.Entity<Product>().ToTable("Producten");
			modelBuilder.Entity<Product>().HasKey(product => product.Id);
			modelBuilder.Entity<Product>().Property(product => product.Naam).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Product>().Property(product => product.Type).IsRequired();
			modelBuilder.Entity<Product>().Property(product => product.Prijs).IsRequired();

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

		
        }
	}
}
