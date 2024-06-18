using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    internal class ShopContext : DbContext
    {
        // DbSets, lien entre les class et les tables
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Product>? Products { get; set; }

        // OnCongiguring, la CS
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ShopDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var clients = new List<Client>
            {
                new Client { Id = 1, Name = "Sylvain Cheveny", Address = "115 rue Fontgiève", City = "Clermont-Ferrand", Age = 36, Mail = "scheveny@gmail.com" },
                new Client { Id = 2, Name = "Marie Dubois", Address = "12 avenue des Champs-Élysées", City = "Paris", Age = 28, Mail = "marie.dubois@gmail.com" },
                new Client { Id = 3, Name = "Paul Martin", Address = "8 rue de la Paix", City = "Lyon", Age = 45, Mail = "paul.martin@gmail.com" },
                new Client { Id = 4, Name = "Sophie Bernard", Address = "20 rue Victor Hugo", City = "Marseille", Age = 32, Mail = "sophie.bernard@gmail.com" }
            };

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Dos de cabillaud", Description = "Pêché en Atlantique Nord-Est", Price = 44.90, Type = ProductType.Poissons, ClientId = 1 },
                new Product { Id = 2, Name = "Filet de bœuf", Description = "Origine France", Price = 34.50, Type = ProductType.Viandes, ClientId = 2 },
                new Product { Id = 3, Name = "Pomme Granny Smith", Description = "Origine France", Price = 2.30, Type = ProductType.Fruits, ClientId = 3 },
                new Product { Id = 4, Name = "Carottes bio", Description = "Cultivées sans pesticides", Price = 3.10, Type = ProductType.Legumes, ClientId = 4 },
                new Product { Id = 5, Name = "Camembert de Normandie", Description = "Fromage au lait cru", Price = 5.50, Type = ProductType.Fromages, ClientId = 1 },
                new Product { Id = 6, Name = "Pain de campagne", Description = "Cuit au four à bois", Price = 4.20, Type = ProductType.Pains, ClientId = 2 },
                new Product { Id = 7, Name = "Croissant", Description = "Pâtisserie artisanale", Price = 1.50, Type = ProductType.Patisseries, ClientId = 3 },
                new Product { Id = 8, Name = "Ratatouille en conserve", Description = "Préparée maison", Price = 6.80, Type = ProductType.Conserves, ClientId = 4 },
                new Product { Id = 9, Name = "Mélange de légumes surgelés", Description = "Surgelés rapidement après récolte", Price = 4.00, Type = ProductType.Suregelés, ClientId = 1 }
            };

            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<Product>().HasData(products);

            base.OnModelCreating(modelBuilder);
        }
    }
}
