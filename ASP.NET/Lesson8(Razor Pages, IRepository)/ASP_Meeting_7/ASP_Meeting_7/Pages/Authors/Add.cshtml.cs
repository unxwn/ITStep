using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP_Meeting_7.Pages.Authors
{
    [IgnoreAntiforgeryToken]
    public class AddModel : PageModel
    {
        [BindProperty]
        public int Age { get; set; }
        [BindProperty]
        [Required]
        [MinLength(6)]
        public string Firstname { get; set; } = string.Empty;

        public IList<string>? ErrorMessages { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessages = new List<string>();
                foreach (var state in ModelState)
                {
                    //if (state.Key == "Firstname")
                        foreach (var error in state.Value.Errors)
                            ErrorMessages.Add(error.ErrorMessage);
                }
            }
            else
            ErrorMessages = null;
        }
    }
}
