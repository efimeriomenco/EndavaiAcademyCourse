using System.Collections.Generic;
using System.Linq;
using Endava.iAcademy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Endava.iAcademy.Repository.Repositories
{
    public class SqlCourseRepository : ICourseRepository
    {
        private readonly EndavaiAcademyDbContext db;

        public SqlCourseRepository(EndavaiAcademyDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Course> FindCourses(string searchValue)
        {
            searchValue ??= "";

            var courses= db
                .Courses
                .Where(x => x.Title.Contains(searchValue))
                .ToList();

            return courses;
        }

        public IEnumerable<Course> GetAll()
        {
            return db.Courses.Include(x => x.Lessons);
        }


        public Course GetById(int id)
        {
            return db
                .Courses
                .Include(x => x.Lessons)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public Course Update(Course updatedCourse)
        {
            //Trimitem un obiect deja in baza de date care dorim DOAR sa-l modificam si ca DBContext sa il modifice particular
            //In entity se afla toate restaurantele(Obiectele)
            //var entity = db.Courses.Attach(updatedCourse);
            //entity.State = EntityState.Modified;
            db.Courses.Update(updatedCourse);
            db.SaveChanges();
            return updatedCourse;
        }

        public Course Add(Course newCourse)
        {
            db.Courses.Add(newCourse);
            db.SaveChanges();

            return newCourse;
        }

       

        //private void HandleException(Exception exception)
        //{
        //    if (exception is DbUpdateException dbUpdateEx)
        //    {
        //        if (dbUpdateEx.InnerException != null)
        //        {
        //            if (dbUpdateEx.InnerException is SqlException sqlException)
        //            {
        //                switch (sqlException.Number)
        //                {
        //                    // Unique constraint
        //                    case 2601:
        //                        return;
        //                    default:
        //                        // A custom exception of yours for other DB issues
        //                        throw new Exception(
        //                            dbUpdateEx.Message, dbUpdateEx.InnerException);
        //                }
        //            }
        //        }
        //    }

        //    throw new Exception(exception.Message, exception.InnerException);
        //}

        public bool Delete(int id)
        {
            var course = GetById(id);
            if (course == null)
                return false;
            
            db.Courses.Remove(course);
            db.SaveChanges();

            return true;
        }

    }
}