using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository.Base;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(IRepository<Categorys> repository) {
             _repository = repository;
        }

        private IRepository<Categorys> _repository;
        //public IActionResult Index()
        //{
        //    return View(_repository.GetAll());
        //}

        public async Task< IActionResult> Index() {
        return  View(await _repository.GetAllAsync());
        }
    }
}
