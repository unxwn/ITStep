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
        [BindProperty(SupportsGet = true)]
        public string? NameSearch { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? YearSearch { get; set; }

        public IEnumerable<Author> Authors { get; set; }
        public IndexModel(IAuthorRepository repository)
        {
            Authors = repository.GetAll();
            this.repository = repository;
        }
        public void OnGet()
        {
            Authors = repository.GetAll();
            if (!string.IsNullOrEmpty(NameSearch)) 
                Authors  = Authors.Where(t=>t.Firstname.Contains(NameSearch));
            if(YearSearch != null)
            {
                Authors = Authors.Where(t=>t.YearOfBirth == YearSearch);
            }
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
