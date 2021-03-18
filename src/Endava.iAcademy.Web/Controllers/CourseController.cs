using System.Linq;
using Endava.iAcademy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Endava.iAcademy.Web.Controllers
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
