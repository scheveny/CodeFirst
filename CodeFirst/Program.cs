// See https://aka.ms/new-console-template for more information
using CodeFirst.Helpers;
using CodeFirst.Models;
using CodeFirst.Repositories;


while (true)
{
    Console.WriteLine("1 - Ajouter un Client");
    Console.WriteLine("2 - lister les clients");
    Console.WriteLine("3 - Ajouter un Produit");
    Console.WriteLine("4 - lister les clients avec leur produits");
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
                ConsoleHelper.AddProductHelper();
                Console.WriteLine("-------------------------------------------");
            break;

        case "4":
                ConsoleHelper.GetAllClientsWithProductsHelper();
                Console.WriteLine("-------------------------------------------");
            break;
        default:
            break;
    }

}
