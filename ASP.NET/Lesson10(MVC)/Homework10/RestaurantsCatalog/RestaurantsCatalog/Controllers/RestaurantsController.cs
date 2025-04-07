using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsCatalog.Data;
using RestaurantsCatalog.Models;

namespace RestaurantsCatalog.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantsCatalogContext _context;

        public RestaurantsController(RestaurantsCatalogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var restaurants = await _context.Restaurants.Include(r => r.Category).ToListAsync();
            return View(restaurants);
        }

        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _context.Restaurants
                .Include(r => r.Category)                        
                .FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(restaurant);
        }
    }
}
