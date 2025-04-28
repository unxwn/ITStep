using CatsMvcViewerApp.Data;
using CatsMvcViewerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using CatsMvcViewerApp.Models;
using CatsMvcViewerApp.Models.DTOs;

namespace CatsMvcViewerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CatsContext context;
        private readonly IMapper mapper;

        public HomeController(CatsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task< IActionResult> Index( string? search, int breedId = 0)
        {
            var breeds = await context.Breeds.ToListAsync();
            IQueryable<Cat> cats = context.Cats.Where(t => t.IsDeleted == false);
            if(breedId!=0)
                cats = cats.Where(t=>t.BreedId ==breedId);
            if (search != null)
            {
                cats = cats.Where(t=>t.Name.Contains(search));
            }
            var catsList = cats.ToList();

            IndexVM vM = new IndexVM()
            {
                Cats = mapper.Map<IEnumerable<CatDTO>>(catsList),
                BreedId = breedId,
                Search = search,
                Breeds = new SelectList(breeds, "Id", "BreedName", breedId),
            };
            return View(vM);
        }

        public ActionResult Privacy() {
            return View();
        }
    }
}
