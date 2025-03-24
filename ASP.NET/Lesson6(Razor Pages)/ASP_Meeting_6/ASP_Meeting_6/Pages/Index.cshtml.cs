using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_6.Pages
{
    public class IndexModel : PageModel
    {
        public string CompanyName { get; set; }

        public IndexModel()
        {
            CompanyName = "PV312 IT Company";
        }
        public void OnGet()
        {
        }
    }
}
