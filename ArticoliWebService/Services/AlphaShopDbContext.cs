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
        public AlphaShopDbContext(DbContextOptions<AlphaShopDbContext> options) : base(options)
        {}

        public virtual DbSet<Articoli> Articoli { get; set; }
        public virtual DbSet<Ean> BarCode { get; set; }
        public virtual DbSet<FamAssort> FamAssort { get; set; }
        public virtual DbSet<Ingredienti> Ingredienti { get; set; }
        public virtual DbSet<Iva> Iva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ean>().HasKey(a => new {a.CodArt});

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