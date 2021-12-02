using CollegeManagement.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    public class InstructorController : Controller
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
            var instructors = _context.Instructors
                .Select(n=>new
                {
                    n.Id,
                    n.Name,
                    Birthday= n.Birthday.ToString("yyyy-MM-dd")
                })
                
                .ToList();
            return Json(instructors);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);
            _context.Remove(instructor);
            _context.SaveChanges();
            return Json($"تم حذف  {instructor.Name} بنجاح");
        }
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            _context.Add(instructor);
            _context.SaveChanges();
            return Json($"{instructor.Id}");
        }
        [HttpPost]
        public IActionResult Update(Instructor newInstructor)
        {
            var instructor = _context.Instructors.Find(newInstructor.Id);
            if (instructor != null)
            {
                instructor.Name = newInstructor.Name;
                instructor.Birthday = newInstructor.Birthday;

                _context.Update(instructor);
                _context.SaveChanges();
                return Json($"{instructor.Id}");
            }

            return Json("error");
        }
    }
}
