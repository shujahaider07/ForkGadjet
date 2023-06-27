using Entities;
using EntitiesViewModels;
using RepositoryBusiness;

namespace Gadgetstore.BusinessInterface
{
    public interface IcategoryBusiness
    {

        public void AddCategory(CategoryVM categoryvm);
        public Task<Category> UpdateCategory(Category category);
        public void DeleteCategory(int id);
        public Category CategoryById (int id);
        public IEnumerable<Category>GetAllCategory();

    }
}
