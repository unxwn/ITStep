using ASP_Meeting_7.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Meeting_7.Models;

namespace ASP_Meeting_7.Pages.Authors
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly IAuthorRepository repository;

        public IEnumerable<Author> Authors { get; set; }
        public IndexModel(IAuthorRepository repository)
        {

            Authors = repository.GetAll();
            this.repository = repository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? id) {
            if (id is null)
                return NotFound();
            Author? author = repository.Get(id.Value);
            if (author == null)
                return NotFound();
            repository.Delete(id.Value);
            return RedirectToPage("Index");
        }
    }
}
