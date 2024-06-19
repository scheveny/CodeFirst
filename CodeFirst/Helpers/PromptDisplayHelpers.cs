using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Helpers
{
    internal class PromptDisplayHelpers
    {
        public static string? PromptString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int PromptInt(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            int.TryParse(input, out int result);
            return result;
        }

        public static double PromptDouble(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            double.TryParse(input, out double result);
            return result;
        }

        public static void DisplayClients(List<Client> clients)
        {
            foreach (Client client in clients)
            {
                Console.WriteLine($"{client.Id} - {client.Name}");
            }
        }

        public static void DisplayOneClient(Client client)
        {
            Console.WriteLine($"{client.Id} - {client.Name}");

            if (client.Products != null && client.Products.Any())
            {
                Console.WriteLine("Produits:");
                foreach (var product in client.Products)
                {
                    Console.WriteLine($" - {product.Name} (ID: {product.Id})");
                }
            }
            else
            {
                Console.WriteLine("Aucun produit associé.");
            }
        }

        public static void DisplayProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Id} - {product.Name}");
            }
        }
    }
}
