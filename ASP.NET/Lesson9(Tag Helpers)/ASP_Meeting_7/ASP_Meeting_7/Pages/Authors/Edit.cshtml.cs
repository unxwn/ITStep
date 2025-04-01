using ASP_Meeting_7.Models;
using ASP_Meeting_7.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_7.Pages.Authors
{
    //[IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        private readonly IAuthorRepository repository;

        [BindProperty]
        public Author Author { get; set; } = new();

        public EditModel(IAuthorRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int id)
        {
            Author? author = repository.Get(id);
            if(author is not null)
            {
                Author = author;
            }
            return Page();
        }

        public IActionResult OnPost() {
            //if(M)
            repository.Edit(Author);
            return RedirectToPage("Index");
        }
    }
}
