using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace ShopAPI.Entities
{
    public class ShopDbContext : DbContext //klasa reprezentuje polaczenie do bazy danych poprzez EF
    {
        private string _connectionString = "Server=NOTME;Database=ShopDb;Trusted_Connection=True;";

        public DbSet<Shop> Shops { get; set; } //tworzenie tabel
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //konfiguracja lub dodatkowe właściwości do kolumn w bazie danych
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shop>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

        //funkcja OnConfiguring() pozwala na konfiguracje polaczenia do bazy danych i sprecyzowanie jakiego typu bazy chce uzyc
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString); //połączenie do bazy
        }
    }
}
