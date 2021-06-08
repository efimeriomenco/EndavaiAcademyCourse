using System.Collections.Generic;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Repository.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        IEnumerable<Category> FindCategories(string searchCategory);
        void AddCategory(Category category);
    }
}