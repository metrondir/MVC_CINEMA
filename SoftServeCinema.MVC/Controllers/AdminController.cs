using Microsoft.AspNetCore.Mvc;

namespace SoftServeCinema.MVC.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
