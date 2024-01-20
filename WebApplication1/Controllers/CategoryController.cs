using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Repository.Base;

namespace WebApplication1.Controllers
{
    [Authorize]
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
        //GET
        public IActionResult New()
        {
            return View();

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Categorys category)
        {
            if (ModelState.IsValid)
            {

                _repository.AddOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            var cat = _repository.FinedbyId(Id.Value);
          
            return View(cat);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorys category)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            var cat = _repository.FinedbyId(Id.Value);
            return View(cat);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Categorys category)
        {
            _repository.DeleteOne(category);
            TempData["successData"] = "Item has been deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
