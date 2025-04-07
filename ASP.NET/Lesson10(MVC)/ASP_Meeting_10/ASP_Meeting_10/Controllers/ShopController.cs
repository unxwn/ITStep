using Microsoft.AspNetCore.Mvc;

namespace ASP_Meeting_10.Controllers
{
    //[Controller]
    public class ShopController // : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string About()
        {
            return "About our company";
        }
    }
}
