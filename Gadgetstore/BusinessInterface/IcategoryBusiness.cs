using Entities;
using EntitiesViewModels;
using RepositoryBusiness;

namespace Gadgetstore.BusinessInterface
{
    public interface IcategoryBusiness
    {

        public Task AddCategory(CategoryVM categoryvm);
        public Task UpdateCategory(Category category);
        public Task DeleteCategory(int id);
        public Category CategoryById (int id);
        public IEnumerable<Category>GetAllCategory();

    }
}
