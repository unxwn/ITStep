using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework6.Pages
{
    public class RestaurantModel : PageModel
    {
        public string Name { get; } = "Shysh";
        public string Cuisine { get; } = "Ukrainian";
        public string Address { get; } = "1 Abelmakh street, Ubar";
        public void OnGet()
        {
        }
    }
}
