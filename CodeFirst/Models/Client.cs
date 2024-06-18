using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    [Index(nameof(Mail), IsUnique = true)]
    internal class Client
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        
        public string? Mail { get; set; }
        public List<Product>? Products { get; set; }
    }
}
