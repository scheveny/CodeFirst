using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public ProductType Type { get; set; }
        public int ClientId { get; set; }
        // Prop navigation (pour include...)
        public Client? Client { get; set; }
    }
}
