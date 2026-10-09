using Microsoft.AspNetCore.Mvc;

namespace EngineeringHub360.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}