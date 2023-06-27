using Entities;
using EntitiesViewModels;


namespace IBusiness
{
    public interface IProductbusiness
    {

        public Task<IEnumerable<Response>> ListProducts();

        public Task<Response> AddProducts(Products e);
        public Task<IEnumerable<Response>> EditProducts(Products e);
        public Task<Response> GetIdByProducts(int id);

        public void deleteProducts(int id);


    }
}