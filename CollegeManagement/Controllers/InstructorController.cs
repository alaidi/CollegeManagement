using CollegeManagement.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    public class InstructorController:Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var instructors = _context.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult GetInstructor()
        {
            var instructors = _context.Instructors.ToList();
            return Json(instructors);
        }
    }
}
