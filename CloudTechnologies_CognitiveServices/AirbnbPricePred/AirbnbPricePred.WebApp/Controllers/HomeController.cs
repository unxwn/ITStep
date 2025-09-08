using AirbnbPricePred.WebApp.Models;
using AirbnbPricePred.WebApp.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirbnbPricePred.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAzureMlService _ml;

        public HomeController(IAzureMlService ml) => _ml = ml;

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RentalRequest
            {
                NeighbourhoodGroup = "Manhattan",
                RoomType = "Entire home/apt",
                Neighbourhood = "Harlem",
                MinimumNights = 1,
                NumberOfReviews = 0,
                ReviewsPerMonth = 0.0,
                LastReviewDate = null
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(RentalRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _ml.PredictAsync(request);
            if (!result.Success)
            {
                ViewBag.Error = "Prediction failed: " + result.RawResponse;
                return View(request);
            }

            return View("Result", result);
        }
    }
}
