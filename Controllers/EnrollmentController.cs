using Dziekanat.Data;
using Dziekanat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dziekanat.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _context;
        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var enrollment = _context.Enrollements.ToList();
            return View(enrollment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudentToCourse(int studentId, int courseId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var course = await _context.Courses.FindAsync(courseId);

            if (student == null || course == null)
            {
                return NotFound();
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                Student = student,
                CourseId = courseId,
                Course = course
            };

            _context.Enrollements.Add(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
