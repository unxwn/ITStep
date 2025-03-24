using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework6.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> Restaurants { get; private set; }
        public int DayOfYear { get; private set; }

        public void OnGet()
        {
            DayOfYear = DateTime.Now.DayOfYear;
            Restaurants = new List<string> { "Shysh", "Ukrainian", "Galicia" };
        }
    }
}
