using ASP_Meeting_7.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_Meeting_7.Models;

namespace ASP_Meeting_7.Pages.Authors
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public IndexModel(IAuthorRepository repository)
        {
            Authors = repository.GetAll();
        }
        public void OnGet()
        {
        }
    }
}
