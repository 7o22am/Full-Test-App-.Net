using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebApplication1.Areas.admin.Models;
using WebApplication1.Areas.products.Models;
using WebApplication1.Repository.Base;
using static NuGet.Packaging.PackagingConstants;

namespace WebApplication1.Areas.products.Controllers
{
    [Area("products")]
    [Authorize]
    public class ProductsViewController : Controller
    {
        private IRepository<Products> _repository;
        public ProductsViewController(IRepository<Products> repository )
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
          
            return View(await _repository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
 

            var product = await _repository.FinedbyIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Cart()
        {
            return View();
        }

   


        [HttpPost("Filter")]
        public IActionResult Filter(FilterViewModel filters)
        {
              ViewData["filterData"] =   filters;
            Console.WriteLine("sssssssssssssssssss" + filters.minPrice);
            Console.WriteLine("sssssssssssssssssss" + filters.maxPrice);
            return View("Filter");
        }

        public IActionResult Filter()
        {

              var filterData = TempData["filterData"] as FilterViewModel;
            Console.WriteLine(filterData);
            return View(filterData);

        }

    }

}
