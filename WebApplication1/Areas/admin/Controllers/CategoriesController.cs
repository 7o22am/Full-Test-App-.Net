using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Base;

namespace WebApplication1.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class CategoriesController : Controller
    {

        private readonly AppDbContext _context;
        private IRepository<Categorys> _repository;

        public CategoriesController(AppDbContext context  , IRepository<Categorys> repository)
        {
            _context = context;
            _repository = repository;
        }
        public IActionResult Index()
        {
            _repository.GetAll().ToList();

            return View();
        }
    }
}
