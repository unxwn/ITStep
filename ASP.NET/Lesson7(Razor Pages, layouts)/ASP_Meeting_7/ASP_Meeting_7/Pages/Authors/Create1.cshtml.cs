using ASP_Meeting_7.Models;
using ASP_Meeting_7.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_7.Pages.Authors
{
    [IgnoreAntiforgeryToken]
    public class Create1Model : PageModel
    {
        private readonly IAuthorRepository repository;

        public Create1Model(IAuthorRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Author? Author { get; set; }
        public void OnGet()
        {
        }


        public void OnPost()
        {
            if(ModelState.IsValid && Author is not null)
            {
                repository.Create(Author);
            }
        }
        
    }
}
