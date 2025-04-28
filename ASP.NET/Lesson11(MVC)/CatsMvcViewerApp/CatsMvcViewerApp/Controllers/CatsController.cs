using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatsMvcViewerApp.Data;
using CatsMvcViewerApp.Models;
using CatsMvcViewerApp.Models.DTOs;
using CatsMvcViewerApp.Models.ViewModels;

namespace CatsMvcViewerApp.Controllers
{
    public class CatsController : Controller
    {
        private readonly CatsContext _context;

        public CatsController(CatsContext context)
        {
            _context = context;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
            var cats = _context.Cats.Include(c => c.Breed)
                .Where(c=>c.IsDeleted == false);
            return View(await cats.ToListAsync());
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(c => c.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "BreedName");
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CatDTO cat, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                Cat createdCat = new Cat
                {
                    Name = cat.Name,
                    BreedId = cat.BreedId,
                    Gender = cat.Gender,
                    IsVacinated = cat.IsVacinated,
                };
                using(MemoryStream ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    byte[] buff = ms.ToArray();
                    createdCat.ImagePath = buff;
                }
                _context.Cats.Add(createdCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id", cat.BreedId);
            return View(cat);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            CatDTO catDTO = new CatDTO
            {
                Id = cat.Id,
                Name = cat.Name,
                Gender = cat.Gender,
                BreedId = cat.BreedId,
                IsVacinated = cat.IsVacinated,
            };
            EditCatVM catVM = new EditCatVM
            {
                CatDTO = catDTO,
                Image = cat.ImagePath,
                Breeds = new SelectList(_context.Breeds, "Id", nameof(Breed.BreedName), cat.BreedId),
                Genders = new SelectList(Enum.GetNames<CatsGender>())
            };
            return View(catVM);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CatDTO catDTO, IFormFile? photo)
        {
            if (id !=catDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Cat? editedCat = await _context.Cats.FindAsync(id);
                if (editedCat == null)
                    return NotFound();
                editedCat.Name = catDTO.Name;
                editedCat.Gender = catDTO.Gender;
                editedCat.BreedId = catDTO.BreedId;
                editedCat.IsVacinated = catDTO.IsVacinated;

                if (photo != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        byte[] buff = ms.ToArray();
                        editedCat.ImagePath = buff;
                    }
                }
                try
                {
                    _context.Update(editedCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(editedCat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            EditCatVM editCatVM = new EditCatVM()
            {
                CatDTO = catDTO,
                Breeds = new SelectList(_context.Breeds, "Id", nameof(Breed.BreedName), catDTO.BreedId),
                Genders = new SelectList(Enum.GetNames<CatsGender>())
            };
            //ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id", cat.BreedId);
            return View(editCatVM);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(c => c.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            if (cat != null)
            {
                _context.Cats.Remove(cat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}
