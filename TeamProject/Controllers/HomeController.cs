using Microsoft.AspNetCore.Mvc;
using Entities;


namespace TeamProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
