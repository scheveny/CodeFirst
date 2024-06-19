// See https://aka.ms/new-console-template for more information
using CodeFirst.Helpers;
using CodeFirst.Models;
using CodeFirst.Repositories;


while (true)
{
    Console.WriteLine("1 - Ajouter un nouveau client");
    Console.WriteLine("2 - Lister tous les clients");
    Console.WriteLine("3 - Trouver un client avec ses produits");
    Console.WriteLine("4 - lister les clients avec leur produits");
    Console.WriteLine("5 - Modifier un client");
    Console.WriteLine("6 - Supprimer un client");
    Console.WriteLine("7 - Ajouter un nouveau produit");
    Console.WriteLine("8 - Ajouter un nouveau produit à un client existant");
    Console.WriteLine("9 - Modifier un produit");
    Console.WriteLine("10 - Chercher un produit par son som");
    Console.WriteLine("11 - Transférer un produit à un autre client");
    Console.WriteLine("12 - Supprimer un produit");
    Console.WriteLine("-------------------------------------------");

    string? method = Console.ReadLine();
    switch (method)
    {
        case "1":
                ConsoleHelper.AddClientHelper();
                Console.WriteLine("-------------------------------------------");
            break;

        case "2":
                ConsoleHelper.GetAllClientsHelper();
                Console.WriteLine("-------------------------------------------");
            break;

        case "3":
                ConsoleHelper.GetAllClientsWithProductsHelper();
                Console.WriteLine("-------------------------------------------");
            break;

        case "4":
                ConsoleHelper.GetAllClientsWithProductsHelper();
                Console.WriteLine("-------------------------------------------");
            break;

        case "5":
            ConsoleHelper.EditClientHelper();
            Console.WriteLine("-------------------------------------------");
            break;

        case "6":
            ConsoleHelper.RemoveClientHelper();
            Console.WriteLine("-------------------------------------------");
            break;

        case "7":
            ConsoleHelper.AddProductHelper();
            Console.WriteLine("-------------------------------------------");
            break;

        case "8":
            ConsoleHelper.AddProductToClientHelper();
            Console.WriteLine("-------------------------------------------");
            break;

        case "9":
            ConsoleHelper.EditProductHelper);
            Console.WriteLine("-------------------------------------------");
            break;

        case "10":
            ConsoleHelper.GetProductByNameHelper();
            Console.WriteLine("-------------------------------------------");
            break;

        case "11":
            ConsoleHelper.TransferProductHelper();
            Console.WriteLine("-------------------------------------------");
            break;

        case "12":
            ConsoleHelper.RemoveProductHelper();
            Console.WriteLine("-------------------------------------------");
            break;
        default:
            break;
    }

}
