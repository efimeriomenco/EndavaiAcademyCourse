using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endava.iAcademy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Endava.iAcademy.Repository.Repositories
{
   public class UsersRepository : IUsersRepository
    {
        private readonly List<Course> courses;
        private readonly EndavaiAcademyDbContext db;
        public UsersRepository(EndavaiAcademyDbContext db)
        {
            this.db = db;
        }
        public User CheckUserPassword(string password , string email)
        {
            User user = db
                .Users
                .Include(x => x.Role)
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
        public User GetUserByEmail(string email)
        {
            User user = db
                .Users
                .Include(x => x.Role)
                .FirstOrDefault(u => u.Email == email);
            return user;
        }
        public User RegisterUser(User registeredUser)
        {
            var domainUser = new User
            {
                RoleId = RolesConstants.Customer.Id, // Admin by default
                Email = registeredUser.Email,
                Password = registeredUser.Password,
            };
            db.Users.Add(domainUser);
            db.SaveChanges();

            return db.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == domainUser.Id);
        }

        public void PurchaseCourse(int userId, int courseId)
        {
            // 1. Check if user hasn't already purchased course
            bool userAlreadyPurchasedCourse = DoesUserOwnTheCourse(userId, courseId);

            // 2. If it already purchased return false
            if (userAlreadyPurchasedCourse)
            {
                throw new Exception("You already own this course");
            }
            // 3. Else not purchased, then create userToCourse and save
            else
            {
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                var course = db.Courses.FirstOrDefault(x => x.Id == courseId);
                if (user != null && course != null)
                {
                    // 4. Check if user has enough points
                    if (user.UserPoints >= course.Price)
                    {
                        // 5. If it has then Deduct user points from user
                        user.UserPoints = user.UserPoints - course.Price;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("You do not have sufficient funds");
                    }

                }
                else
                {
                    throw new Exception("Could not find user or course");
                }
                
                // 6. Assign user to course
                var userToCourse = new UserToCourse()
                {
                    CourseId = courseId,
                    UserId = userId
                };

                db.UserToCourses.Add(userToCourse);
                db.SaveChanges();
            }
        }

        public bool DoesUserOwnTheCourse(int userId, int courseId)
        {
            return db
                .UserToCourses
                .Any(x => x.UserId == userId && x.CourseId == courseId);
        }
    }

}
