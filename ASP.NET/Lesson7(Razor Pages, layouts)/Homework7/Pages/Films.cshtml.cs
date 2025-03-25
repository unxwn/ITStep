using FilmLibrary.Models;
using FilmLibrary.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework7.Pages
{
    [IgnoreAntiforgeryToken]
    public class FilmsModel : PageModel
    {
        public List<string> Errors { get; set; } = new List<string>();

        private readonly IFilmRepository _filmRepository;
        public IEnumerable<Film> Films { get; set; }

        [BindProperty]
        public Film NewFilm { get; set; }

        public FilmsModel(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public void OnGet()
        {
            Films = _filmRepository.GetAll();
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Films = _filmRepository.GetAll();
                Errors = ModelState.Values
                               .SelectMany(v => v.Errors)
                               .Select(e => e.ErrorMessage)
                               .ToList();
            }
            else
            {
                _filmRepository.Add(NewFilm);
                Films = _filmRepository.GetAll();
            }
        }
    }
}
