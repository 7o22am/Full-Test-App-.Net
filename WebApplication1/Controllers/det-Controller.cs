using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class det_Controller : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public det_Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }


        public async Task<IActionResult> Index(int? id)
        {
            string apiUrl = $"https://api.themoviedb.org/3/movie/{id}?api_key=108a9f5af213b0f18c1369bf7a3d6186"; // Replace with your API URL
            
            HttpClient client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Replace with the actual JSON data
                MovieResult movieData = JsonConvert.DeserializeObject<MovieResult>(jsonResponse);

                ViewData["ApiResponse"] = movieData; // Store the API response in ViewData
                                                    // Store the API response in ViewData

               
            }
            else
            {
                // Handle the error case
            }

            return View();
        }
    }
}
