global using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repositories
{
    internal class ClientRepository
    {
        public static void AddClient(string name, int age, string address, string city, string mail)
        {
            ShopContext context = new ShopContext();
            Client person = new Client()
            {
                Name = name,
                Age = age,
                Address = address,
                City = city,
                Mail = mail
            };

            context.Clients!.Add(person);

            context.SaveChanges();
            Console.WriteLine("Client ajouté avec succès");
        }

        public static List<Client> GetAll()
        {
            ShopContext context = new ShopContext();

            List<Client> people = context.Clients!.ToList();

            return people;
        }

        public static List<Client> GetAllClientsWithProducts()
        {
            ShopContext context = new ShopContext();

            List<Client> people = context.Clients!.Include(p => p.Products).ToList();

            return people;
        }

        public static Client GetClientById(int id) 
        { 
            ShopContext context = new ShopContext();

            Client? client = context.Clients!
           .Include(p => p.Products)
           .FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                Console.WriteLine("Client introuvable.");
                return null;
            }

            return client;
        }

        public static void TransferProductToAnotherClient(int productId, int newClientId)
        {
            ShopContext context = new ShopContext();
            
            Product? product = context.Products!
                .Include(p => p.Client)  // Inclure le client actuel du produit
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                Console.WriteLine("Produit introuvable.");
                return;
            }

            // Trouver le nouveau client
            Client? newClient = context.Clients!
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == newClientId);

            if (newClient == null)
            {
                Console.WriteLine("Nouveau client introuvable.");
                return;
            }

            // Retirer le produit de l'ancien client s'il en a un
            if (product.Client != null)
            {
                product.Client.Products.Remove(product);
            }

            // Assigner le produit au nouveau client
            product.Client = newClient;
            newClient.Products.Add(product);

            // Sauvegarder les modifications
            context.SaveChanges();
            Console.WriteLine("Produit transféré avec succès.");
        
        }


        public static void EditClientbyId(Client paramClient)
        {
            ShopContext context = new ShopContext();
            
            Client? c = context.Clients.Find(paramClient.Id);
            if (c == null)
            {
                Console.WriteLine("Client introuvable.");
                return;
            }

            c.Name = paramClient.Name;
            c.Address = paramClient.Address;
            c.City = paramClient.City;
            c.Mail = paramClient.Mail;
            context.SaveChanges();
            Console.WriteLine("Client mis à jour avec succès.");
        }

        public static void RemoveClientById(int id) 
        {
            ShopContext context = new ShopContext();
            Client? client = context.Clients.Find(id);

            if (client == null)
            {
                Console.WriteLine("Ce client n'existe pas");
                return;
            }

            try
            {
                context.Clients.Remove(client);
                context.SaveChanges();
                Console.WriteLine("Client supprimé avec succès");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression du client : " + ex.Message);
                throw;
            }
        }

    }
}
