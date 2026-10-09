using EngineeringHub360.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringHub360.Controllers
{
    public class AcademyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .Where(c => c.IsActive)
                .OrderBy(c => c.Id)
                .ToListAsync();

            return View(courses);
        }
    }
}