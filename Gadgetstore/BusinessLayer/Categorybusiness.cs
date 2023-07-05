using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;
using RepositoryBusiness;

namespace Gadgetstore.BusinessLayer
{
    public class Categorybusiness : IcategoryBusiness
    {
        private readonly ICategory _category;

        public Categorybusiness(ICategory _category)
        {
            this._category = _category;
        }
        public async Task AddCategory(CategoryVM categoryvm)
        {
            try
            {
              await _category.AddCategory(categoryvm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category CategoryById(int id)
        {
            try
            {
               return _category.GetIdByCategory(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
               await _category.deleteCategory(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Category> GetAllCategory()
        {
            try
            {
                 return _category.ListCategory();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCategory(Category category)
        {
            
            try
            {
              await _category.EditCategory(category);

               
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
