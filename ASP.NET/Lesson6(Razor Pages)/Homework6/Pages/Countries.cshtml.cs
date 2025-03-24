using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Homework6.Pages
{
    public class CountriesModel : PageModel
    {
        public List<Country> Countries { get; }

        public CountriesModel(IOptions<List<Country>> options)
        {
            Countries = options.Value;
        }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Area { get; set; }
        public int Population { get; set; }
    }
}
