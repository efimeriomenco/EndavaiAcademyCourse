using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Linq;

namespace Endava.iAcademy.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index(int id)
        {
            var courseRepository = new CourseRepository();
            var course = courseRepository.GetAllCourses().First(c => c.Id == id);
            return View(course);
        }
    }
}
