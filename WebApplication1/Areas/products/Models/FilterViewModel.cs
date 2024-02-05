namespace WebApplication1.Areas.products.Models
{
    public class FilterViewModel
    {
        public List<string> colors { get;   }
        public List<string> sizes { get;   }
        public int minPrice { get;   }
        public int maxPrice { get;  }
    }
}