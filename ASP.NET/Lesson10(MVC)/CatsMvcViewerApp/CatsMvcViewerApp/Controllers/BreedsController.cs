using CatsMvcViewerApp.Data;
using CatsMvcViewerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatsMvcViewerApp.Controllers
{
    public class BreedsController : Controller
    {
        private readonly CatsContext context;

        public BreedsController(CatsContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<Breed> breeds = context.Breeds;
            List<Breed> breedsList = await breeds.ToListAsync();
            return View(breedsList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Breed breed) {
            if (!ModelState.IsValid)
                return View(breed);
            context.Breeds.Add(breed);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
