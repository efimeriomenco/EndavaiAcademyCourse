using System;
using System.Collections.Generic;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Web.ViewModels.Courses
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public float Rating { get; set; }
        public IEnumerable<LessonViewModel> Lessons { get; set; }
        public bool CurrentUserOwnsThisCourse { get; set; }
        public string CategoryName { get; set; }
        public DateTime Date { get; set; }
    }
}