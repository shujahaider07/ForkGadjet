using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;

namespace Gadgetstore.BusinessLayer
{
    public class ProductBusiness : IproductBusiness
    {


        private readonly IProductRepo _productRepo;

        public ProductBusiness(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<productListVm>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepo.GetAll();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while getting all products: {ex.Message}");
                throw; 
            }
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepo.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting product by ID: {ex.Message}");
                throw;
            }
        }

        public async Task AddProductAsync(Products product)
        {
            try
            {
                await _productRepo.Add(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a product: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProductAsync(Products product)
        {
            try
            {
                await _productRepo.Update(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating a product: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                await _productRepo.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting a product: {ex.Message}");
                throw;
            }
        }
    }

}
