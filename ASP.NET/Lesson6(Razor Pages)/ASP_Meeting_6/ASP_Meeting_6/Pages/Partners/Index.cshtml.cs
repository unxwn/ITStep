using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Meeting_6.Pages.Partners
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
            Partners = new List<string>();
        }
        public IEnumerable<string> Partners { get; set; }
        public void OnGet()
        {
            Partners = new List<string>()
            {
                "JetBrains",
                "Microsoft",
                "Autodesk",
                //"Cisco"
            };
        }
    }
}
