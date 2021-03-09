using Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
                    Title = "C# Essentials",
                    Description = "A course about OOP and SOLID principles.",
                    Author = "Clint Eastwood",
                    Date = new DateTime(2020,08,01),
                    Rating = (float)8.75,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "1. How to program in C# - BASICS - Beginner Tutorial",
                            Description = "Course introduction",
                            Link = "https://www.youtube.com/watch?v=pSiIHe2uZ2w&list=PLPV2KyIb3jR6ZkG8gZwJYSjnXxmfPAl51&ab_channel=Brackeys"
                        },
                        new Lesson
                        {
                            Title = "2. How to program in C# - Beginner Tutorial",
                            Description = "In this video we write our first program as we learn about input and output, methods and parameters.",
                            Link = "https://www.youtube.com/watch?v=nA2pSmBmvKg&list=PLPV2KyIb3jR6ZkG8gZwJYSjnXxmfPAl51&index=3&ab_channel=Brackeys"
                        },
                        new Lesson
                        {
                            Title = "3. How to program in C# - VARIABLES - Beginner Tutorial",
                            Description = "In this video we create a simple calculator as we discover the power of variables.",
                            Link = "https://www.youtube.com/watch?v=udoMi4mGYYw&list=PLPV2KyIb3jR6ZkG8gZwJYSjnXxmfPAl51&index=4&ab_channel=Brackeys"
                        },
                    }
                },
                new Course
                {
                    Title = "Microsoft Azure Fundamentals",
                    Description = "A full preparation for a free AZ-900 exam.",
                    Author = "Adam Marczak",
                    Date = new DateTime(2020,07,07),
                    Rating = (float)9.05,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "AZ-900 | Microsoft Azure Fundamentals Full Course, Free Practice Tests, Website and Study Guides",
                            Description = "Azure Fundamentals certification is an opportunity to prove knowledge of cloud concepts, core Azure services, Azure pricing, SLA, and lifecycle, and the fundamentals of cloud security, privacy, compliance, and trust.",
                            Link = "https://www.youtube.com/watch?v=NPEsD6n9A_I&list=PLGjZwEtPN7j-Q59JYso3L4_yoCjj2syrM&index=2&ab_channel=AdamMarczak-AzureforEveryone"
                        },
                        new Lesson
                        {
                            Title = "AZ-900 Episode 1 | Cloud Computing and Vocabulary | Microsoft Azure Fundamentals Full Course",
                            Description = "Episode 1 covers following skills\n- Describe what is Cloud Computing\n- Describe terms such as High Availability, Scalability, Elasticity, Agility, Fault Tolerance, and Disaster Recovery",
                            Link = "https://www.youtube.com/watch?v=Pt9LelJ0fL0&list=PLGjZwEtPN7j-Q59JYso3L4_yoCjj2syrM&index=3&ab_channel=AdamMarczak-AzureforEveryone"
                        },
                        new Lesson
                        {
                            Title = "AZ-900 Episode 2 | Principle of economies of scale | Microsoft Azure Fundamentals Full Course",
                            Description = "Episode 2 covers following skills\n- Describe the principles of economies of scale",
                            Link = "https://www.youtube.com/watch?v=TMynEWIE3SM&list=PLGjZwEtPN7j-Q59JYso3L4_yoCjj2syrM&index=4&ab_channel=AdamMarczak-AzureforEveryone"
                        },
                    }
                }
            };
        }

        public void GetCourseByName()
        {

        }
    }
}
