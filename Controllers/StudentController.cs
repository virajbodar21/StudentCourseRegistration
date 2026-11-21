using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        // In-memory data store using static List<Student>
        private static readonly List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Akshar Parekh",
                Email = "aksharparekh180@gmail.com",
                Course = "B.Tech Computer Engineering",
                Semester = 5
            },
            new Student
            {
                Id = 2,
                Name = "Prince Patel",
                Email = "prince.patel@marwadiuniversity.ac.in",
                Course = "B.Tech Information Technology",
                Semester = 5
            },
            new Student
            {
                Id = 3,
                Name = "Drashti Vora",
                Email = "drashti.vora@marwadi.edu.in",
                Course = "B.Tech Computer Science & Engineering",
                Semester = 6
            }
        };

        // GET: /Student or /Student/Index
        public IActionResult Index()
        {
            return View(_students);
        }

        // GET: /Student/Create
        [HttpGet]
        public IActionResult Create(bool demoErrors = false)
        {
            var model = new Student();
            if (demoErrors)
            {
                ModelState.AddModelError("Name", "Name must be between 2 and 50 characters.");
                ModelState.AddModelError("Email", "Please enter a valid email address.");
                ModelState.AddModelError("Course", "Course is required.");
                ModelState.AddModelError("Semester", "Semester must be an integer between 1 and 8.");
                model.Name = "A"; // Too short (< 2)
                model.Email = "invalid-email-address";
                model.Course = "";
                model.Semester = 12; // Out of range 1-8
            }
            return View(model);
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Auto-generate Id
                student.Id = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1;
                _students.Add(student);
                TempData["SuccessMessage"] = $"Student '{student.Name}' was registered successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If validation failed, re-render form with error messages
            return View(student);
        }

        // GET: /Student/Details/5
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
