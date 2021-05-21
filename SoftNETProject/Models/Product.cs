using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftNETProject.Controllers;
using System.Linq;
using System.Threading.Tasks;


namespace SoftNETProject.Data
{
    public class Product : IModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
