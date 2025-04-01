using ASP_Meeting_7.Models;
using ASP_Meeting_7.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_7.Pages.Authors
{
    [IgnoreAntiforgeryToken]
    public class DeleteModel : PageModel
    {
        private readonly IAuthorRepository repository;

        public DeleteModel(IAuthorRepository repository)
        {
            this.repository = repository;
        }
        public Author Author { get; set; } = new();
        public void OnGet(int id)
        {
            Author? author = repository.Get(id);
            if(author is not null)
                Author = author;
        }

        public IActionResult OnPost(int id)
        {
            Author? author = repository.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
