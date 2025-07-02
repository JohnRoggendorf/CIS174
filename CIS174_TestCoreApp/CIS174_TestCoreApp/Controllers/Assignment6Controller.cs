using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    public class Assignment6Controller : Controller
    {
        [Route("Assignment6/{accessLevel:int}")]
        public IActionResult Index(int accessLevel)
        {
            if (accessLevel < 1 || accessLevel > 10)
            {
                return BadRequest("Access level must be between 1 and 10.");
            }

            // Create sample students
            var students = new List<Student>
        {
            new Student { FirstName = "Aye", LastName = "Person", Grade = "A" },
            new Student { FirstName = "Psalm", LastName = "Body", Grade = "B+" },
            new Student { FirstName = "Tess", LastName = "Name", Grade = "A-" },
            new Student { FirstName = "John", LastName = "Doe", Grade = "B" }
            };

            var vm = new AssignmentViewModel
            {
                Students = students,
                AccessLevel = accessLevel
            };

            return View(vm);
        }
    }
}
