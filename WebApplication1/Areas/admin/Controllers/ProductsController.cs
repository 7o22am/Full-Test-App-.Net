using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.admin.Models;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Base;

namespace WebApplication1.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class ProductsController : Controller
    {
        private IRepository<Products> _repository;

        public ProductsController(IRepository<Products> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {        
 
            return View(await _repository.GetAllAsync());
        }


        // get Edit
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _repository.FinedbyIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(Products products)
        {

            if (ModelState.IsValid)
            {
                _repository.UpdateOne(products);
                return RedirectToAction("Index");
            }
            else
            {
                return View(products);
            }
        }

        public IActionResult New()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Products products)
        {
            if (ModelState.IsValid)
            {

                _repository.AddOne(products);
                return RedirectToAction("Index");
            }
            else
            {
                return View(products);
            }

        }

        public async Task<IActionResult> Delete(int id)
        {

            return View(await _repository.FinedbyIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Products products)
        {

           
                _repository.DeleteOne(products);
                return RedirectToAction("Index");
           
            
        }
    }
}
