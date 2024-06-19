using CodeFirst.Models;
using CodeFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Helpers
{
    internal class ConsoleHelper
    {
        public static void AddClientHelper()
        {
            string? name = PromptDisplayHelpers.PromptString("Nom ?");
            int age = PromptDisplayHelpers.PromptInt("Age ?");
            string? address = PromptDisplayHelpers.PromptString("Adresse ?");
            string? city = PromptDisplayHelpers.PromptString("Ville ?");
            string? mail = PromptDisplayHelpers.PromptString("Email ?");

            ClientRepository.AddClient(name, age, address, city, mail);
        }
        public static void GetAllClientsWithProductsHelper()
        {
            List<Client> clients = ClientRepository.GetAllClientsWithProducts();
            foreach (Client client in clients)
            {
                Console.WriteLine($"{client.Id} {client.Name} {client.Age}");
                foreach (Product product in client.Products)
                {
                    Console.WriteLine($"{product.Name} {product.Type}");
                }
            }
        }
        public static void GetAllClientsHelper()
        {
            List<Client> clients = ClientRepository.GetAll();
            PromptDisplayHelpers.DisplayClients(clients);
        }

        public static void GetClientByIdWithProductsHelper()
        {
            int clientId = PromptDisplayHelpers.PromptInt("Entrez l'ID du client :");

            Client client = ClientRepository.GetClientById(clientId);

            if (client != null)
            {
                PromptDisplayHelpers.DisplayOneClient(client);
            }
            else
            {
                Console.WriteLine("Client introuvable.");
            }
        }

        public static void EditClientHelper()
        {
            try
            {
                Console.WriteLine("Modifier quel client ?");
                List<Client> clients = ClientRepository.GetAll();
                if (clients.Count == 0)
                {
                    Console.WriteLine("Aucun client disponible.");
                    return;
                }

                PromptDisplayHelpers.DisplayClients(clients);
                int clientId = PromptDisplayHelpers.PromptInt("ID du client ?");
                Client? existingClient = clients.FirstOrDefault(c => c.Id == clientId);
                if (existingClient == null)
                {
                    Console.WriteLine("Client introuvable.");
                    return;
                }

                string? name = PromptDisplayHelpers.PromptString("Nom ?");
                string? address = PromptDisplayHelpers.PromptString("Adresse ?");
                string? city = PromptDisplayHelpers.PromptString("Ville ?");
                string? mail = PromptDisplayHelpers.PromptString("Email ?");

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) ||
                    string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(mail) || !mail.Contains("@"))
                {
                    Console.WriteLine("Entrée invalide.");
                    return;
                }

                Client updatedClient = new Client
                {
                    Id = existingClient.Id,
                    Name = name,
                    Address = address,
                    City = city,
                    Mail = mail
                };

                ClientRepository.EditClientbyId(updatedClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
        }
        public static void RemoveClientHelper()
        {
            List<Client> clients = ClientRepository.GetAll();
            PromptDisplayHelpers.DisplayClients(clients);
            int clientId = PromptDisplayHelpers.PromptInt("ID du client ?");
            ClientRepository.RemoveClientById(clientId);
        }

        //**************************************************************************************************************************************************


        public static void AddProductHelper()
        {
            string? name = PromptDisplayHelpers.PromptString("Nom du produit ?");
            string? typeS = PromptDisplayHelpers.PromptString("Type ? 0(Poissons) 1(Viandes) 2(Fruits) 3(Legumes) 4(Fromages) 5(Patisseries) 6(Pains) 7(Conserves) 8(Surégelés)");
            string? description = PromptDisplayHelpers.PromptString("Description ?");
            double price = PromptDisplayHelpers.PromptDouble("Prix ?");

            ProductType productType = typeS switch
            {
                "1" => ProductType.Viandes,
                "2" => ProductType.Fruits,
                "3" => ProductType.Legumes,
                "4" => ProductType.Fromages,
                "5" => ProductType.Patisseries,
                "6" => ProductType.Pains,
                "7" => ProductType.Conserves,
                "8" => ProductType.Suregelés,
                _ => ProductType.Poissons
            };

            Console.WriteLine("Sélectionnez un client pour ce produit :");
            List<Client> clients = ClientRepository.GetAll();
            PromptDisplayHelpers.DisplayClients(clients);
            int clientId = PromptDisplayHelpers.PromptInt("ID du client ?");

            ProductRepository.AddProduct(name, productType, description, price, clientId);
        }
        public static void AddProductToClientHelper()
        {
            Console.WriteLine("ID du client auquel ajouter un produit:");
            int clientId = PromptDisplayHelpers.PromptInt("Entrez l'ID du client : ");
            string? name = PromptDisplayHelpers.PromptString("Nom du produit ?");
            string? typeS = PromptDisplayHelpers.PromptString("Type ? 0(Poissons) 1(Viandes) 2(Fruits) 3(Legumes) 4(Fromages) 5(Patisseries) 6(Pains) 7(Conserves) 8(Surégelés)");
            string? description = PromptDisplayHelpers.PromptString("Description ?");
            double price = PromptDisplayHelpers.PromptDouble("Prix ?");

            ProductType productType = typeS switch
            {
                "1" => ProductType.Viandes,
                "2" => ProductType.Fruits,
                "3" => ProductType.Legumes,
                "4" => ProductType.Fromages,
                "5" => ProductType.Patisseries,
                "6" => ProductType.Pains,
                "7" => ProductType.Conserves,
                "8" => ProductType.Suregelés,
                _ => ProductType.Poissons
            };

            ProductRepository.AddProductToClient(clientId, name, productType, description, price);
        }

        public static void GetProductByNameHelper()
        {
            string productName = PromptDisplayHelpers.PromptString("Nom du produit ?");

            Product product = ProductRepository.GetProductByName(productName);

            if (product == null)
            {
                Console.WriteLine("Aucun produit à afficher.");
                return;
            }

            Console.WriteLine($"ID: {product.Id} \n Name: {product.Name} \n Description : {product.Description} \n Prix : {product.Price}");
        }

        public static void TransferProductHelper()
        {
            List<Client> clients = ClientRepository.GetAllClientsWithProducts();
            int productId = PromptDisplayHelpers.PromptInt("Entrez l'ID du produit : ");
            int newClientId = PromptDisplayHelpers.PromptInt("Entrez l'ID du nouveau client : ");

            ClientRepository.TransferProductToAnotherClient(productId, newClientId);
        }

        

        public static void RemoveProductHelper()
        {
            Console.WriteLine("Supprimer quel produit ?");
            List<Product> products = ProductRepository.GetAllProducts();
            PromptDisplayHelpers.DisplayProducts(products);
            int productId = PromptDisplayHelpers.PromptInt("ID du produit ?");
            ProductRepository.RemoveProductById(productId);
        }

        public static void EditProductHelper()
        {
            try
            {
                Console.WriteLine("Modifier quel produit ?");
                List<Product> products = ProductRepository.GetAllProducts();
                if (products.Count == 0)
                {
                    Console.WriteLine("Aucun produit disponible.");
                    return;
                }

                PromptDisplayHelpers.DisplayProducts(products);
                int productId = PromptDisplayHelpers.PromptInt("ID du produit ?");
                Product? existingProduct = products.FirstOrDefault(p => p.Id == productId);
                if (existingProduct == null)
                {
                    Console.WriteLine("Produit introuvable.");
                    return;
                }

                string? name = PromptDisplayHelpers.PromptString("Nom ?");
                string? description = PromptDisplayHelpers.PromptString("Description ?");
                double price = PromptDisplayHelpers.PromptDouble("Prix ?");

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Entrée invalide.");
                    return;
                }

                Product updatedProduct = new Product
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Id = existingProduct.Id
                };

                ProductRepository.EditProductbyId(updatedProduct);
                Console.WriteLine("Produit mis à jour avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
        }
    }
}
