using LatviaMap.Services;
using LatviaMap.Models;
using Microsoft.AspNetCore.Mvc;

namespace LatviaMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlaceService _placeService;

        public HomeController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public IActionResult Index()
        {
            // Get the four most extreme points in Latvia 
            var extremePlaces = _placeService.GetExtremePlaces();
            return View(extremePlaces);
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var results = _placeService.SearchPlaces(query);
            return Json(results);
        }
    }
}