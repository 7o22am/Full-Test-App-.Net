using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger , IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index(int id)
        {


            id = (id == 0) ? 1 : id;
 
            string apiUrl = $"https://api.themoviedb.org/3/trending/movie/day?api_key=108a9f5af213b0f18c1369bf7a3d6186&page={id}"; // Replace with your API URL

            HttpClient client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Replace with the actual JSON data
                 MovieModel movieData = JsonConvert.DeserializeObject<MovieModel>(jsonResponse);
               
                ViewData["ApiResponse"] = movieData; // Store the API response in ViewData
                ViewData["CurrentId"] = id.ToString();
            }
            else
            {
                // Handle the error case
            }

            return View();
        }
 
                   public IActionResult MoviesStory() {
            return View();
        
                   }

    }
}
