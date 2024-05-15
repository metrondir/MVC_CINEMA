using Microsoft.AspNetCore.Mvc;

namespace SoftServeCinema.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
