using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_7.Pages.Authors
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        public string Message { get; set; } = "";

        public int Age { get; set; }
        public void OnGet()
        {
           ViewData["Title"] = "Додавання автора";
        }

        public void OnPost(string firstname, int age) {
            Message = $"Вітаємо, {firstname}";
            Age = age;
        }
    }
}
