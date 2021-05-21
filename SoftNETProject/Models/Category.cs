using SoftNETProject.Controllers;
using System.ComponentModel.DataAnnotations;


namespace SoftNETProject.Data
{
    public class Category : IModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
