using Microsoft.AspNetCore.Mvc;

namespace EShopper.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
