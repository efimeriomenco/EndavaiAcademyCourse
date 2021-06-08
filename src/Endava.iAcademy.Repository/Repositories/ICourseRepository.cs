using System.Collections.Generic;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Repository.Repositories
{
   public interface ICourseRepository
   {
       IEnumerable<Course> FindCourses(string searchValue);
       
       IEnumerable<Course> GetAll();
       Course GetById(int id);
       Course Update(Course updatedCourse);
       Course Add(Course newCourse);
       bool Delete(int id);

   }
}
