using System.ComponentModel.DataAnnotations;


namespace SoftNETProject.Controllers
{
    public interface IModel
    {
        [Key]
        public int Id { get; set; }
    }
}
