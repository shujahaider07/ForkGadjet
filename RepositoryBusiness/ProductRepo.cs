using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var product = await _dbContext.product.FindAsync(id);
            if (product != null)
            {
                _dbContext.product.Remove(product);
               
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<productListVm>> GetAll()
        {
            try
            {
                var productList = await(from p in _dbContext.product
                                        join c in _dbContext.Categories on p.Category_Id equals c.Category_id
                                        select new productListVm
                                        {
                                            ProductId = p.ProductId,
                                            Product_Name = p.Product_Name,
                                            Category_Name = c.Category_Name
                                        }).OrderByDescending(x=>x.ProductId).ToListAsync();

                return productList;
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
            try
            {
                  _dbContext.product.Update(product);
                 await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
          
        }


    }
}
