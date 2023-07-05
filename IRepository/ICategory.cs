using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface ICategory
    {

        public IEnumerable<Category> ListCategory();
        public Task AddCategory(CategoryVM e);
        public Task EditCategory(Category e);
        public Category GetIdByCategory(int id);

        public Task deleteCategory(int id);
    }
}
