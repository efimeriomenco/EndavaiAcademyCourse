﻿using System;
using System.Collections.Generic;
using System.Linq;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Repository.Repositories
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private readonly List<Course> courses;
        private readonly List<Category> categories;
        

        public IEnumerable<Course> GetAll()
        {
            return new List<Course>
            {
                new Course
                {
                    Id = 0,
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
                            Description = "Courses introduction",
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
                    Id = 0,
                    Title = "Microsoft Azure Fundamentals",
                    Description = "A full preparation for a free AZ-900 exam.",
                    Author = "Adam Marczak",
                    Date = new DateTime(2020,07,07),
                    Rating = (float)9.05,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "0. Free Practice Tests, Website and Study Guides",
                            Description = "Azure Fundamentals certification is an opportunity to prove knowledge of cloud concepts, core Azure services," +
                            "\nAzure pricing, SLA, and lifecycle, and the fundamentals of cloud security, privacy, compliance, and trust.",
                            Link = "https://www.youtube.com/embed/NPEsD6n9A_I"
                        },
                        new Lesson
                        {
                            Title = "1.  Cloud Computing and Vocabulary",
                            Description = "Episode 1 covers following skills\n- Describe what is Cloud Computing\n- Describe terms such as High Availability, Scalability, Elasticity, Agility, Fault Tolerance, and Disaster Recovery",
                            Link = "https://www.youtube.com/embed/Pt9LelJ0fL0"
                        },
                        new Lesson
                        {
                            Title = "2. Principle of economies of scale",
                            Description = "Episode 2 covers following skills\n- Describe the principles of economies of scale",
                            Link = "https://www.youtube.com/embed/TMynEWIE3SM"
                        },
                        new Lesson
                        {
                            Title = "3. CapEx vs OpEx and their differences",
                            Description = "Episode 3 covers following skills\n- Describe the differences between Capital Expenditure (CapEx) and Operational Expenditure (OpEx)",
                            Link = "https://www.youtube.com/embed/7KEygnLtRyE"
                        },
                        new Lesson
                        {
                            Title = "4.  Consumption-based Model",
                            Description = "Episode 4 covers following skills\n- Describe the consumption-based model",
                            Link = "https://www.youtube.com/embed/NdqncsMtryY"
                        }
                    }
                },
                new Course
                {
                    Id = 0,
                    Title = "Cryptocurrency Fundamentals",
                    Description = "Bitcoin is the first decentralized digital currency. All Bitcoin transactions are documented on a virtual ledger called the blockchain, which is accessible for everyone to see." +
                    "\nBitcoin gives you complete control over your money, unlike other assets you own which are regulated by banks and governments. As bitcoin gains more popularity, more and more places accept it as a payment method." +
                    "\nThat's Bitcoin in a nutshell. For the complete simple explanation watch this course.",
                    Author = "Clint Eastwood",
                    Date = new DateTime(2018,04,01),
                    Rating = (float)9.18,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "1. What is Bitcoin?",
                            Description = "Introduction into Bitcoin.",
                            Link = "https://www.youtube.com/embed/41JCpzvnn_0"
                        },
                        new Lesson
                        {
                            Title = "2. What is a Bitcoin Wallet? ",
                            Description = "A Bitcoin wallet is a device or program that stores your private keys and allows you to interact with the Bitcoin blockchain (i.e. send and receive Bitcoins). ",
                            Link = "https://www.youtube.com/embed/A1Pl5hYHXiI"
                        },
                        new Lesson
                        {
                            Title = "3. What is Bitcoin Mining?",
                            Description = "Bitcoin mining is the process of updating the ledger of Bitcoin transactions known as the blockchain." +
                            "\nMining is done by running extremely powerful computers (known as ASICs) that race against other miners in an attempt to guess a specific number.",
                            Link = "https://www.youtube.com/embed/BODyqM-V71E"
                        },
                        new Lesson
                        {
                            Title = "4. Bitcoin Transactions - from \"Send\" to \"Receive\"",
                            Description = "Learn all about what happens to a single Bitcoin from the moment you hit send in your wallet until it's received on the other side.",
                            Link = "https://www.youtube.com/embed/ZPFL6R-voW0"
                        },
                        new Lesson
                        {
                            Title = "5. Bitcoin Fees and Unconfirmed Transactions - Complete Beginner's Guide",
                            Description = "Bitcoin transaction fees (sometimes referred to as mining fees) allow users to prioritize their transaction over others and get included faster into Bitcoin’s ledger of transactions known as the blockchain.",
                            Link = "https://www.youtube.com/embed/waP7n8crMhg"
                        }
                    }
                },
                new Course
                {
                    Id = 0,
                    Title = "Adobe Illustrator for Beginners",
                    Description = "Hello Everyone. Finally I'm starting a new series, Adobe Illustrator for Beginners." +
                    "\nIn this cource will be covered all necessary topics for the successfull start in graphic design.",
                    Author = "Gareth David",
                    Date = new DateTime(2014,02,10),
                    Rating = (float)8.45,
                    Lessons = new List<Lesson>
                    {
                        new Lesson
                        {
                            Title = "1. Introduction",
                            Description = "Introduction into Adobe Illustrator.",
                            Link = "https://www.youtube.com/embed/IBouhf4seWQ"
                        },
                        new Lesson
                        {
                            Title = "2. Interface Introduction",
                            Description = "In this video tutorial I will be using Adobe Illustrator CC for mac." +
                            "\nAlmost all of the principles demonstrated and covered will apply to future and previous versions." +
                            "\nSome differences may apply if you are using a previous or future version.",
                            Link = "https://www.youtube.com/embed/QKWnkIPur2Q"
                        },
                        new Lesson
                        {
                            Title = "3. Panels & Workspaces",
                            Description = "In this video I am going to show you how to customise the panel layout to create a more comfortable workspace." +
                            "\nAlso I will also be recommending my the workspace that I use that I find really effective. ",
                            Link = "https://www.youtube.com/embed/2E9oGKd0Ayg"
                        },
                        new Lesson
                        {
                            Title = "4. Artboards",
                            Description = "In this video we are going to take a closer look, at art boards in Adobe illustrator.",
                            Link = "https://www.youtube.com/embed/9GbLm_WXWwk"
                        },
                        new Lesson
                        {
                            Title = "5. Vector basics | Selection & Direct selection tool & more",
                            Description = "In this tutorial I am going to talk about how creative elements work and how we can begin to operate in illustrator." +
                            "\nIn this video you will get a good understand of the basics so we can move on later and start building our own creative elements. ",
                            Link = "https://www.youtube.com/embed/GFY0_EMVYDw"
                        }
                    }
                }
            };
        }

        public Course GetById(int id)
        {
            return courses.SingleOrDefault(c => c.Id == id);
        }
        public IEnumerable<Course> FindCourses(string searchValue = null)
        {
            return from c in courses
                where string.IsNullOrEmpty(searchValue) || c.Title.StartsWith(searchValue)
                orderby c.Title
                select c;
        }


        public Course Update(Course updatedCourse)
        {
            var course = courses.SingleOrDefault(c => c.Id == updatedCourse.Id);
            if (course != null)
            {
                course.Title = updatedCourse.Title;
                course.Author = updatedCourse.Author;
                course.Date = updatedCourse.Date;
                course.Description = updatedCourse.Description;
                course.Rating = updatedCourse.Rating;
                course.Price = updatedCourse.Price;
                course.CategoryId = updatedCourse.CategoryId;
            }

            return course;

        }

        public Course Add(Course newCourse)
        {
            courses.Add(newCourse);
            newCourse.Id = courses.Max(c => c.Id) + 1;
            return newCourse;
        }

        public bool Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return false;
            courses.Remove(course);

            return true;
            
        }

    }
}
