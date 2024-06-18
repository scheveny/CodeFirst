using CodeFirst.Models;
using System;
using System.Collections.Generic;
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
        }
    }
}
