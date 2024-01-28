using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApplication1.Areas.admin.Models;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Base;

namespace WebApplication1.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class CategoriesController : Controller
    {

        
        private IRepository<ProCategorys> _repository;

        public CategoriesController(  IRepository<ProCategorys> repository)
        {
          
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _repository.GetAllAsync());
        }


        public IActionResult New()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProCategorys pCategorys)
        {
            if (ModelState.IsValid)
            {

                _repository.AddOne(pCategorys);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pCategorys);
            }

        }




        public async Task<IActionResult> Delete(int id)
        {

            return View(await _repository.FinedbyIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProCategorys pCategorys)
        {


            _repository.DeleteOne(pCategorys);
            return RedirectToAction("Index");


        }



        // get Edit
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _repository.FinedbyIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProCategorys pCategorys)
        {

            if (ModelState.IsValid)
            {
                _repository.UpdateOne(pCategorys);
                return RedirectToAction("Index");
            }
            else
            {
                return View(pCategorys);
            }
        }
    }
}
