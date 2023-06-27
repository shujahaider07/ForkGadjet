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
        public void AddCategory(CategoryVM categoryvm)
        {
            try
            {
                _category.AddCategory(categoryvm);
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

        public void DeleteCategory(int id)
        {
            try
            {
                _category.deleteCategory(id);
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

        public async Task<Category> UpdateCategory(Category category)
        {
            Category category1 = new Category();
            try
            {
               var updated = await _category.EditCategory(category);

                if (updated != null)
                {
                    category1 = updated;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return category1;
        }
    }
}
