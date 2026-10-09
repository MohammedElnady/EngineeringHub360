using Microsoft.AspNetCore.Mvc;

namespace EngineeringHub360.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}