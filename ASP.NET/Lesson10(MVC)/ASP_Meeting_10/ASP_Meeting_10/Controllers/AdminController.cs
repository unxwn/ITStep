using ASP_Meeting_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Meeting_10.Controllers
{
    public class AdminController : Controller
    {
        public IEnumerable<ShopUser> Users { get; set; }
        public AdminController() {
            Users = new List<ShopUser>() {
                new ShopUser {Id = 1, Login = "SerhiiR", Surname = "Ruban"},
                new ShopUser {Id = 2, Login = "Andrii", Surname = "Drozdov"},
                new ShopUser {Id = 3, Login = "Vadymka", Surname = "Kharlamenko"},
                new ShopUser {Id = 4, Login = "Anie", Surname = "Shevchenko"}

            };
        }
        public IActionResult Index()
        {
            string controller = Request.RouteValues["controller"]!.ToString() ?? "Значення контролера не передано";
            string action = Request.RouteValues["action"]!.ToString() ?? "Значення методу дії не передано";
            ViewBag.Action = action;
            ViewBag.Controller = controller;
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult Login(int? id) {
            if (id == null)
                return NotFound();
            ShopUser? user = Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
                return NotFound($"Користувач з Id: {id} не знайдено!");
            return View(user);
        }
    }
}
