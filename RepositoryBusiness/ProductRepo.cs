using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepo(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task Add(Products product)
        {
            var products = new Products();

            try
            {
                products.Category_Id = product.Category_Id;
                products.IsDelete = 0;
                products.Product_Name = product.Product_Name;

                 await _dbContext.product.AddAsync(products);

                 await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");

                throw;
            }

        }

        public async Task Delete(int id)
        {
            var pro = await _dbContext.product.Where(x => x.ProductId == id).FirstOrDefaultAsync();
         
            if (pro != null)
            {
                pro.IsDelete = 1;

                _dbContext.product.Update(pro);


                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<productListVm>> GetAll()
        {
            try
            {
                var productList = await (from p in _dbContext.product
                                         join c in _dbContext.Categories on p.Category_Id equals c.Category_id
                                         select new productListVm
                                         {
                                             ProductId = p.ProductId,
                                             Product_Name = p.Product_Name,
                                             Category_Name = c.Category_Name,
                                             IsDelete = p.IsDelete,
                                         }).OrderByDescending(x => x.ProductId).Where(x => x.IsDelete == 0 || x.IsDelete == null).ToListAsync();


                return (productList);

            }

            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while retrieving all products: {ex.Message}");
                throw;
            }
        }

        public async Task<Products> GetById(int id)
        {
            try
            {
                return await _dbContext.product.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task Update(Products productss)
        {
            try
            {
                productss.IsDelete = 0;
                _dbContext.product.Update(productss);
                await _dbContext.SaveChangesAsync();

                
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
