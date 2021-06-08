using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endava.iAcademy.Web.ViewModels.Courses
{
    public class CreateCourseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
        public int Price { get; set; }

        public float Rating { get; set; }

        public DateTime Date { get; set; }

        public int SelectedCategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
