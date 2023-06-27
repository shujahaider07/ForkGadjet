using Entities;
using EntitiesViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
