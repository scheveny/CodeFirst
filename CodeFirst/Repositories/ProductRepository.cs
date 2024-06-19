using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repositories
{
    internal class ProductRepository
    {
        public static void AddProduct(string name, ProductType type, string description, double price, int clientId)
        {
            ShopContext context = new ShopContext();

            Product product = new Product()
            {
                Name = name,
                Type = type,
                Description = description,
                Price = price,
                ClientId = clientId
            };

            context.Products!.Add(product);

            context.SaveChanges();
            Console.WriteLine($"Produit {product.Name} ajouté avec succès");
        }
        public static void AddProductToClient(int clientId, string name, ProductType type, string description, double price)
        {
            ShopContext context = new ShopContext();
            
            Client? client = context.Clients!
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                Console.WriteLine("Client introuvable.");
                return;
            }

            Product product = new Product()
            {
                Name = name,
                Type = type,
                Description = description,
                Price = price,
                ClientId = clientId
            };

            client.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine($"Produit {product.Name} ajouté  au client avec succès.");
        }

        public static List<Product> GetAllProducts()
        {
            ShopContext context = new ShopContext();

            List<Product> p = context.Products!.ToList();

            return p;
        }

        public static Product GetProductByName(string name)
        {
            ShopContext context = new ShopContext();

            Product? product = context.Products!
            .FirstOrDefault(p => p.Name.ToLower() == name.ToLower());

            if (product == null)
            {
                Console.WriteLine("Produit introuvable.");
                return null;
            }

            return product;
        }

        public static void EditProductbyId(Product paramProduct)
        {
            ShopContext context = new ShopContext();

            Product? p = context.Products.Find(paramProduct.Id);
            if (p == null)
            {
                Console.WriteLine("Produit introuvable.");
                return;
            }

            p.Name = paramProduct.Name;
            p.Description = paramProduct.Description;
            p.Price = paramProduct.Price;
            p.Client = paramProduct.Client;
            
            context.SaveChanges();
            Console.WriteLine($"Produit {paramProduct.Name} mis à jour avec succès.");
        }

        public static void RemoveProductById(int id)
        {
            ShopContext context = new ShopContext();
            Product? p = context.Products.Find(id);

            if (p == null)
            {
                Console.WriteLine("Ce client n'existe pas");
                return;
            }

            try
            {
                context.Products.Remove(p);
                context.SaveChanges();
                Console.WriteLine($"Produit {p.Name} supprimé avec succès");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression du client : " + ex.Message);
                throw;
            }
        }
    }
}
