using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;

namespace RepositoryBusiness
{

    public class CategoryRepo : ICategory
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public void AddCategory(CategoryVM e)
        {
            try
            {
                _db.Categories.Add(new Category
                {

                    Category_Name = e.Category_Name,
                    Category_Type = e.Category_Type,

                });
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void deleteCategory(int id)
        {
            try
            {
                 _db.Categories.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Category> EditCategory(Category e)
        {
            Category category = new Category();
            try
            {
               _db.Categories.Update(e);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return category;
        }

        public  Category GetIdByCategory(int id)
        {
            try
            {
                 return _db.Categories.FirstOrDefault(x => x.Category_id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Category> ListCategory()
        {

            try
            {
                return _db.Categories.OrderByDescending(x => x.Category_id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
