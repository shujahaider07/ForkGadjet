using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface ICategory
    {

        public IEnumerable<Category> ListCategory();
        public void AddCategory(CategoryVM e);
        public Task<Category> EditCategory(Category e);
        public Category GetIdByCategory(int id);

        public void deleteCategory(int id);
    }
}
