using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Employess.Controllers
{
    [Area("Employess")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
