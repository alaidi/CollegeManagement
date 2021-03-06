using CollegeManagement.Data;
using CollegeManagement.Models;
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
                    n.Person.Name,
                    Birthday= n.Person.Birthday.ToString("yyyy-MM-dd")
                })
                
                .ToList();
            return Json(instructors);
        }

        public IActionResult Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);
            _context.Remove(instructor);
            _context.SaveChanges();
            return Json($"تم حذف  {instructor.Person.Name} بنجاح");
        }
        [HttpPost]
        public IActionResult Add(PersonDTO personDto)
        {
            Instructor instructor = personDto;
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
                instructor.Person.Name = newInstructor.Person.Name;
                instructor.Person.Birthday = newInstructor.Person.Birthday;

                _context.Update(instructor);
                _context.SaveChanges();
                return Json($"{instructor.Id}");
            }

            return Json("error");
        }

        public IActionResult Profile(int id)
        {
            var instructor = _context.Instructors.Find(id);
            return View(instructor);
        }
    }
}
