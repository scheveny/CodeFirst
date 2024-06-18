using CodeFirst.Models;
using CodeFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Helpers
{
    internal class ConsoleHelper
    {
        public static void AddClientHelper()
        {
            Console.WriteLine("Nom ?");
            string? name = Console.ReadLine();
            Console.WriteLine("Age ?");
            string? ageS = Console.ReadLine();
            int age = 0;
            int.TryParse(ageS, out age);
            Console.WriteLine("Adresse ?");
            string? address = Console.ReadLine();
            Console.WriteLine("Ville ?");
            string? city = Console.ReadLine();
            Console.WriteLine("Email ?");
            string? mail = Console.ReadLine();

            ClientRepository.AddClient(name, age, address, city, mail);
        }
        public static void AddProductHelper() 
        {
            Console.WriteLine("Nom du produit ?");
            string? name = Console.ReadLine();

            Console.WriteLine("Type ? 0(Poissons) 1(Viandes) 2(Fruits) 3(Legumes) 4(Fromages) 5(Patisseries) 6(Pains) 7(Conserves) 8(Sugelés)");
            string? typeS = Console.ReadLine();

            Console.WriteLine("Description ?");
            string? description = Console.ReadLine();

            Console.WriteLine("Prix ?");
            string? priceS = Console.ReadLine();
            double price = 0;
            double.TryParse(priceS, out price);

            ProductType productType = ProductType.Poissons;
            switch (typeS)
            {
                case "0":
                    productType = ProductType.Poissons;
                    break;
                case "1":
                    productType = ProductType.Viandes;
                    break;
                case "2":
                    productType = ProductType.Fruits;
                    break;
                case "3":
                    productType = ProductType.Legumes;
                    break;
                case "4":
                    productType = ProductType.Fromages;
                    break;
                case "5":
                    productType = ProductType.Patisseries;
                    break;
                case "6":
                    productType = ProductType.Pains;
                    break;
                case "7":
                    productType = ProductType.Conserves;
                    break;
                case "8":
                    productType = ProductType.Suregelés;
                    break;
                default:
                    productType = ProductType.Poissons;
                    break;
            }

            Console.WriteLine("Sélectionnez un client pour ce produit :");
            List<Client> clients = ClientRepository.GetAll();
            foreach (Client client in clients)
            {
                Console.WriteLine($"{client.Id} - {client.Name}");
            }
            string? clientIdS = Console.ReadLine();
            int clientId = 0;
            int.TryParse(clientIdS, out clientId);

            ProductRepository.AddProduct(name, productType, description, price, clientId);
        }

        public static void GetAllClientsWithProductsHelper() 
        {
            List<Client> people = ClientRepository.GetAllClientsWithProducts();

            foreach (Client c in people)
            {
                Console.WriteLine($"{c.Id} {c.Name} {c.Age}");

                foreach (Product p in c.Products)
                {
                    Console.WriteLine($"{p.Name} {p.Type}");
                }
            }
        }

        public static void GetAllClientsHelper() 
        {
            List<Client> people = ClientRepository.GetAll();

            foreach (Client client in people)
            {
                Console.WriteLine($"{client.Id} {client.Name} {client.Age}");
            }
        }
    }
}
