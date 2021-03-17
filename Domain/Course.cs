using System;
using System.Collections.Generic;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public float Rating { get; set; }

        public DateTime Date { get; set; }

        public List<Lesson> Lessons { get; set; }

    }
}
