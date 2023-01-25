using Microsoft.AspNetCore.Mvc;
using Dziekanat.Models;
using Dziekanat.Data;

namespace Dziekanat.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _context;
        public InstructorController(AppDbContext context) {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
