using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class AlphaShopDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AlphaShopDbContext(DbContextOptions<AlphaShopDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Articoli> Articoli => Set<Articoli>();
        public virtual DbSet<Ean> BarCode => Set<Ean>();
        public virtual DbSet<FamAssort> FamAssort => Set<FamAssort>();
        public virtual DbSet<Ingredienti> Ingredienti => Set<Ingredienti>();
        public virtual DbSet<Iva> Iva => Set<Iva>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("alphaShopDbConString");
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>().HasKey(a => new {a.CodArt});

            //Relazione one to many (uno a molti) fra Articoli e Barcode
            modelBuilder.Entity<Ean>()
            .HasOne<Articoli>(s => s.articolo) //ad un articolo...
            .WithMany(g => g.BarCode) //corrispondono molti barcode
            .HasForeignKey(s => s.CodArt); //la chiave esterna dell'Entity BarCode

            //Relazione one to one (uno a uno fra articoli e ingredienti
            modelBuilder.Entity<Articoli>()
            .HasOne<Ingredienti>(s => s.ingredienti) //ad un articolo...
            .WithOne(g => g.articolo) //corrisponde un ingrediente
            .HasForeignKey<Ingredienti>(s => s.CodArt);

            //Relazione one to many tra iva e articoli
            modelBuilder.Entity<Articoli>()
            .HasOne<Iva>(s => s.iva)
            .WithMany(g => g.articoli)
            .HasForeignKey(s => s.IdIva);

            //relazione one to many tra famassort e articoli
            modelBuilder.Entity<Articoli>()
            .HasOne<FamAssort>(s => s.famAssort)
            .WithMany(g => g.articoli)
            .HasForeignKey(s => s.IdFamAss);
        }
    }
}