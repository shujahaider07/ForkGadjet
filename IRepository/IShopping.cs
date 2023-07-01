using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IShopping
    {
        //public Task<IEnumerable<Shopping>> ListShopping();
        public Task<IEnumerable<ShoppingVm>> ListShoppingVm();
        public Task AddShopping(ShoppingVm e);
        public Task EditShopping(Shopping e);
        public Task<Shopping> GetIdByShopping(int id);

        public Task deleteShopping(int id);
    }
}
