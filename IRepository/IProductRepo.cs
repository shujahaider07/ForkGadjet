using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IProductRepo
    {
        public Task<IEnumerable<productListVm>> GetAll();
        public Task<Products> GetById(int id);
        public Task Add(Products product);
        public Task Update(Products product);
        public Task Delete(int id);


    }
}
