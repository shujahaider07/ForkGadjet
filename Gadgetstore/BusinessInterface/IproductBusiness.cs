using Entities;
using EntitiesViewModels;

namespace Gadgetstore.BusinessInterface
{
    public interface IproductBusiness
    {
      
            Task<IEnumerable<productListVm>> GetAllProductsAsync();
            Task<Products> GetProductByIdAsync(int id);
            Task AddProductAsync(Products product);
            Task UpdateProductAsync(Products products);
            Task DeleteProductAsync(int id);
        

    }
}
