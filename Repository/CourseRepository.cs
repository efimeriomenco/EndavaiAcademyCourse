using Domain;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class CourseRepository
    {
        public CourseRepository()
        {

        }

        public List<Course> GetAllCourses()
        {
            return new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Title = "C# Essentials",
                    Description = "A course about OOP and SOLID principles.",
                    Author = "Clint Eastwood",
                    Date = new DateTime(2020,08,01),
                    Rating = (float)8.75,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "1. How to program in C# - BASICS",
                            Description = "Course introduction",
                            Link = "https://www.youtube.com/embed/pSiIHe2uZ2w"
                        },
                        new Lesson
                        {
                            Title = "2. How to program in C# - FIRST PROGRAM",
                            Description = "In this video we write our first program as we learn about input and output, methods and parameters.",
                            Link = "https://www.youtube.com/embed/nA2pSmBmvKg"
                        },
                        new Lesson
                        {
                            Title = "3. How to program in C# - VARIABLES",
                            Description = "In this video we create a simple calculator as we discover the power of variables.",
                            Link = "https://www.youtube.com/embed/udoMi4mGYYw"
                        },
                        new Lesson
                        {
                            Title = "4. How to program in C# - IF STATEMENTS",
                            Description = "In this video we expand on what our programs can do as we teach them how to make decisions.",
                            Link = "https://www.youtube.com/embed/OXTK7cnphYY"
                        },
                        new Lesson
                        {
                            Title = "5. How to program in C# - SWITCH STATEMENTS",
                            Description = "In this video we learn about switch statements, classes and how to generate random numbers.",
                            Link = "https://www.youtube.com/embed/Qs-LAYkp9YU"
                        }
                    }
                },
                new Course
                {
                    Id = 2,
                    Title = "Microsoft Azure Fundamentals",
                    Description = "A full preparation for a free AZ-900 exam.",
                    Author = "Adam Marczak",
                    Date = new DateTime(2020,07,07),
                    Rating = (float)9.05,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "AZ-900 | Free Practice Tests, Website and Study Guides",
                            Description = "Azure Fundamentals certification is an opportunity to prove knowledge of cloud concepts, core Azure services, Azure pricing, SLA, and lifecycle, and the fundamentals of cloud security, privacy, compliance, and trust.",
                            Link = "https://www.youtube.com/embed/NPEsD6n9A_I"
                        },
                        new Lesson
                        {
                            Title = "AZ-900 Episode 1 | Cloud Computing and Vocabulary",
                            Description = "Episode 1 covers following skills\n- Describe what is Cloud Computing\n- Describe terms such as High Availability, Scalability, Elasticity, Agility, Fault Tolerance, and Disaster Recovery",
                            Link = "https://www.youtube.com/embed/Pt9LelJ0fL0"
                        },
                        new Lesson
                        {
                            Title = "AZ-900 Episode 2 | Principle of economies of scale",
                            Description = "Episode 2 covers following skills\n- Describe the principles of economies of scale",
                            Link = "https://www.youtube.com/embed/TMynEWIE3SM"
                        },
                        new Lesson
                        {
                            Title = "AZ-900 Episode 3 | CapEx vs OpEx and their differences",
                            Description = "Episode 3 covers following skills\n- Describe the differences between Capital Expenditure (CapEx) and Operational Expenditure (OpEx)",
                            Link = "https://www.youtube.com/embed/7KEygnLtRyE"
                        },
                        new Lesson
                        {
                            Title = "AZ-900 Episode 4 | Consumption-based Model",
                            Description = "Episode 4 covers following skills\n- Describe the consumption-based model",
                            Link = "https://www.youtube.com/embed/NdqncsMtryY"
                        }
                    }
                }
            };
        }

        public void GetCourseByName()
        {

        }
    }
}
