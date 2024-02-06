using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Areas.admin.Models;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebApplication1.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class ProductsController : Controller
    {
        private IRepository<Products> _repository;
        private IRepository<ProCategorys> _repository2;
        private readonly IHostingEnvironment _host;
        public ProductsController(IRepository<Products> repository , IRepository<ProCategorys> repository2, IHostingEnvironment host)
        {
            _repository = repository;
            _repository2 = repository2;
            _host = host;

        }
        public async Task<IActionResult> Index()
        {        
 
            return View(await _repository.GetAllAsync());
        }
        public void  createSelectList(int selectId = 0)
        {
            List<ProCategorys> categories = (List<ProCategorys>)_repository2.GetAll();
            SelectList listItems = new SelectList((List<ProCategorys>)categories, "Id", "Name", selectId);
            ViewBag.CategoryList = listItems;
        }

        // get Edit
        public async Task<IActionResult> Edit(int id)
        {
            createSelectList(id);
            return View(await _repository.FinedbyIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(Products products)
        {

            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (products.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = products.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    products.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    products.ImgPath = fileName;
                }

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
            createSelectList();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Products products)
        {
            
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (products.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = products.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    products.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    products.ImgPath = fileName;
                }
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
