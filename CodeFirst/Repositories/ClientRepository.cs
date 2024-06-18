global using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
