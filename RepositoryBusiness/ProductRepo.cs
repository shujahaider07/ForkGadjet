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
            try
            {
                product.IsDelete = 0;
                await _dbContext.product.AddAsync(product);
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
            Products p = new Products();

            var product = await _dbContext.product.FindAsync(id);

            if (product != null)
            {
                p.Category_Id = product.Category_Id;
                p.ProductId = product.ProductId;
                p.Product_Name = product.Product_Name;
                p.IsDelete = product.IsDelete == 0 ? 1 : 1;

                _dbContext.product.Update(p);


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

        public async Task Update(Products product)
        {
            Products p = new Products();

            try
            {
                var Model = await _dbContext.product.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);

                p.Product_Name = product.Product_Name;
                p.ProductId = product.ProductId;
                p.Category_Id = product.Category_Id;

                if (p != null)
                {
                    var id = await _dbContext.product.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);

                    _dbContext.product.Remove(id);
                    _dbContext.SaveChangesAsync();

                }



                _dbContext.product.Update(p);
                await _dbContext.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
