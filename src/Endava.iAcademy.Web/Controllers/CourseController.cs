using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Endava.iAcademy.Domain;
using Endava.iAcademy.Repository;
using Endava.iAcademy.Repository.Repositories;
using Endava.iAcademy.Web.ViewModels;
using Endava.iAcademy.Web.ViewModels.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Endava.iAcademy.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUsersRepository _usersRepository;

        public CourseController(ICourseRepository courseRepository, ICategoryRepository categoryRepository, IUsersRepository usersRepository )
        {
            _courseRepository = courseRepository;
            _categoryRepository = categoryRepository;
            _usersRepository = usersRepository;
        }
   
        [HttpGet]
        public IActionResult List(string searchValue, string sortBy,string searchCategory)
        {
            var filteredCourses = _courseRepository.FindCourses(searchValue).ToList();
            var sortedCourses = new List<Course>();
            switch (sortBy)
            {
                case nameof(Course.Title):
                    sortedCourses = filteredCourses.OrderBy(x => x.Title).ToList();
                    break;
                case nameof(Course.Rating):
                    sortedCourses = filteredCourses.OrderBy(x => x.Rating).ToList();
                    break;
                default:
                    sortedCourses = filteredCourses;
                    break;
            }

          
            return View(sortedCourses);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return View(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int id)
        {
            var hasSucceded = _courseRepository.Delete(id);
            if (!hasSucceded)
            {
                ModelState.AddModelError("message", $"Could not find courseViewModel with id {id}");
                return View("Delete");
            }
            return RedirectToAction("List", "Course");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Course existingCourse = _courseRepository.GetById(id);

            CourseEditViewModel model = new CourseEditViewModel()
            {
                Title = existingCourse.Title,
                Author = existingCourse.Author,
                Price = existingCourse.Price,
                Date = existingCourse.Date,
                Description = existingCourse.Description,
            };

            var categories = _categoryRepository.GetAll();
            
            model.Categories = categories
                .Select(category =>new SelectListItem(category.Title, category.Id.ToString()))
                .ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(CourseEditViewModel model)
        {
            Course updatedCourse = new Course()
            {
                Id = model.Id,
                Title = model.Title,
                Price = model.Price,
                Rating = model.Rating,
                Date = model.Date,
                CategoryId = model.SelectedCategoryId,
                Description = model.Description,
                Author = model.Author
            };

            _courseRepository.Update(updatedCourse);
            var categories = _categoryRepository.GetAll();

            model.Categories = categories
                .Select(category => new SelectListItem(category.Title, category.Id.ToString()))
                .ToList();
            ViewBag.HasSucceeded = true;
            //return RedirectToAction("Edit", "Course");
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new CreateCourseViewModel();
            foreach (var category in _categoryRepository.GetAll())
            {
                model.Categories.Add(new SelectListItem(category.Title, category.Id.ToString()));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseViewModel courseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var course = new Course()
                    {
                        Title = courseViewModel.Title,
                        Author = courseViewModel.Author,
                        Rating = courseViewModel.Rating,
                        Date = courseViewModel.Date,
                        Price = courseViewModel.Price,
                        Description = courseViewModel.Description,
                        CategoryId = courseViewModel.SelectedCategoryId
                    };

                    _courseRepository.Add(course);

                    return RedirectToAction(nameof(List));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "The Courses already exists");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(courseViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult BuyCourse(int id)
        {
            var currentUserIdClaim = this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value;
            if (string.IsNullOrEmpty(currentUserIdClaim))
                return BadRequest("Could not find user id");

            var currentUserId = int.Parse(currentUserIdClaim);

            try
            {
                _usersRepository.PurchaseCourse(currentUserId, id);

                return RedirectToAction("Details", "Course", new {id = id});
            }
            catch (Exception e)
            {
                //ModelState.AddModelError("All", e.Message);
                ViewBag.ErrorMessage = e.Message;

                var course = _courseRepository.GetById(id);
                var currentUserOwnsCourse = _usersRepository.DoesUserOwnTheCourse(currentUserId, course.Id);
                var courseViewModel = new CourseDetailsViewModel()
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    Date = course.Date,
                    Author = course.Author,
                    Rating = course.Rating,
                    Price = course.Price,
                    CurrentUserOwnsThisCourse = currentUserOwnsCourse,
                    CategoryName = course.Category?.Title ?? "No category",
                    Lessons = course.Lessons.Select(lesson => new LessonViewModel()
                    {
                        Title = lesson.Title,
                        Description = lesson.Description,
                        Link = lesson.Link
                    })
                };

                return View("~/Views/Course/Details.cshtml", courseViewModel);
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var course = _courseRepository.GetById(id.Value);
            if (course == null)
                return NotFound();

            var currentUserIdClaim = this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value;
            if (string.IsNullOrEmpty(currentUserIdClaim))
                return BadRequest("Could not find user id");

            var currentUserId = int.Parse(currentUserIdClaim);
            var currentUserOwnsCourse = _usersRepository.DoesUserOwnTheCourse(currentUserId, course.Id);

            var courseViewModel = new CourseDetailsViewModel()
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Date = course.Date,
                Author = course.Author,
                Rating = course.Rating,
                Price = course.Price,
                CurrentUserOwnsThisCourse = currentUserOwnsCourse, 
                CategoryName = course.Category?.Title ?? "No category",
                Lessons = course.Lessons.Select(lesson => new LessonViewModel()
                {
                    Title = lesson.Title,
                    Description = lesson.Description,
                    Link = lesson.Link
                })
            };
            
            return View(courseViewModel);
        }

    }
}
