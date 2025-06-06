﻿using AutoMapper;
using CatsMvcViewerApp.Data;
using CatsMvcViewerApp.Models;
using CatsMvcViewerApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatsMvcViewerApp.Controllers
{
    public class BreedsController : Controller
    {
        private readonly CatsContext context;
        private readonly IMapper mapper;

        public BreedsController(CatsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
        public async Task<IActionResult> Create(BreedDTO breedDto) {
            if (!ModelState.IsValid)
                return View(breedDto);

            Breed breed = mapper.Map<Breed>(breedDto);
            context.Breeds.Add(breed);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
                Breed? breed = await context.Breeds.FindAsync(id.Value);
            if (breed == null)
                return NotFound();
            return View(breed);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Breed breed)
        {
            if(!ModelState.IsValid)
                return View(breed);
            Breed? editedBreed = await context.Breeds.FindAsync(breed.Id);
            if(editedBreed == null)
                return NotFound();
            editedBreed.BreedName = breed.BreedName;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Breed? breed = await context.Breeds.FindAsync(id.Value);
            if (breed == null)
                return NotFound();
            return View(breed);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id == null)
                return NotFound();
            Breed? breed = await context.Breeds.FindAsync(id.Value);
            if (breed == null)
                return NotFound();
            context.Breeds.Remove(breed);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            Breed? breed = await context.Breeds.FindAsync(id.Value);
            if (breed == null)
                return NotFound();
            return View(breed);
        }
    }
}
