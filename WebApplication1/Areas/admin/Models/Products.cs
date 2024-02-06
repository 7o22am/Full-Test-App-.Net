using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Areas.admin.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public string Quantity  { get; set; }
        [Required(ErrorMessage = "Color is required.")]
        public string color { get; set; }
        [Required(ErrorMessage = "Size is required.")]
        public string size { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
         
        //[DisplayName("Category")]
        //[ForeignKey("ProCategorys")]
        //[Required(ErrorMessage = "categoryId is required.")]
        public string CategoryID { get; set; }
        //public ProCategorys? Category { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ImgPath { get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }
    }
}
