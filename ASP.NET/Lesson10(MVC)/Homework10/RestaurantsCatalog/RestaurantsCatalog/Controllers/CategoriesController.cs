using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsCatalog.Data;
using RestaurantsCatalog.Models;

namespace RestaurantsCatalog.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly RestaurantsCatalogContext _context;

        public CategoriesController(RestaurantsCatalogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Include(c => c.Restaurants)
                .ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Restaurants)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
