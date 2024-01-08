using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Categorys
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Item> Items { get; set; }

       
    }
}
