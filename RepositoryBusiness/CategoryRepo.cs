using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{

    public class CategoryRepo : ICategory
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task AddCategory(CategoryVM e)
        {
            try
            {
                await _db.Categories.AddAsync(new Category
                {

                    Category_Name = e.Category_Name,
                    Category_Type = e.Category_Type,
                    IsDelete = 0

                }) ;
               await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task deleteCategory(int id)
        {
            try
            {

                var data = await _db.Categories.Where(x => x.Category_id == id).FirstOrDefaultAsync();

                if (data != null)
                {

                      data.IsDelete = 1;
                     _db.Categories.Update(data);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditCategory(Category e)
        {

            try
            {
                var data = await _db.Categories.Where(x => x.Category_id == e.Category_id).FirstOrDefaultAsync();

                if (data != null)
                {
                    data.Category_id = e.Category_id;
                    data.Category_Name = e.Category_Name;
                    data.Category_Type = e.Category_Type;
                    data.IsDelete = 0;
                }

                _db.Categories.Update(e);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Category GetIdByCategory(int id)
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
                return _db.Categories.OrderByDescending(x => x.Category_id).Where(x=>x.IsDelete == 0).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
