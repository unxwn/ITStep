using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_6.Pages
{
    public class AboutModel : PageModel
    {
        public bool IsNight { get; set; } = false;
        public void OnGet()
        {
            int currentHour = DateTime.Now.Hour;
            if(currentHour<8 || currentHour > 18)
            {
                IsNight = true;
            }
        }
    }
}
