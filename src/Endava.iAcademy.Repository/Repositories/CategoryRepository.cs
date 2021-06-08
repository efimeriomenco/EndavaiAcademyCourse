using System.Collections.Generic;
using System.Linq;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EndavaiAcademyDbContext _dbContext;

        public CategoryRepository(EndavaiAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }
        public IEnumerable<Category> FindCategories(string searchCategory)
        {
            searchCategory ??= "";

            var categories = _dbContext
                .Categories
                .Where(x => x.Title.Contains(searchCategory))
                .ToList();

            return categories;
        }
        public void AddCategory(Category newCategory)
        {
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
        }
    }
}