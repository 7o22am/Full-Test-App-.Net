using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        [DisplayName("Category")]
        [Required(ErrorMessage = "categoryId is required.")]
        [ForeignKey("Category")]
        public int categoryId {  get; set; }  
        public Categorys? Category { get; set; }
    }
}
