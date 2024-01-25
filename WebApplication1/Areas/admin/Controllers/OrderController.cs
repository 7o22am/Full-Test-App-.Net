using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
