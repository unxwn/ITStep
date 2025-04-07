using Microsoft.AspNetCore.Mvc;

namespace ASP_Meeting_10.Controllers
{
    //public class HomeController : Controller
    public class Home : Controller
    {
        //Метод дії - Action
        public IActionResult Index()
        {
            string controller = Request.RouteValues["controller"]!.ToString() ?? "Значення контролера не передано";
            string action = Request.RouteValues["action"]!.ToString() ?? "Значення методу дії не передано";
            ViewBag.Action = action;
            ViewBag.Controller = controller;
            ViewBag.Title = "Home";
            return View();
        }

        
        public IActionResult Calc(int x)
        {
            int y = int.Parse(Request.Query["y"].ToString());
            ViewBag.X = x;
            ViewBag.Y = y;
            int sum = x + y;
            ViewBag.Sum = sum;
            return View();
        }

        public async Task OurTeam()
        {
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync("<h1>Наша команда</h1>");
        }
        [NonAction]
        public string CurrentDate()
        {
            return DateTime.Now.ToString();
        }

       
    }
}
