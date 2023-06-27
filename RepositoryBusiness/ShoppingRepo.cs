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
    public class ShoppingRepo : IShopping
    {

        private readonly ApplicationDbContext _db;

        public ShoppingRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }


        public async Task<Shopping> AddShopping(Shopping e)
        {
            try
            {

                Shopping Shop = new Shopping();

                Shop.Customer_Id = e.Customer_Id;
                Shop.date = e.date;


                var add = _db.Shoppings.Add(Shop);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return e;

        }

        public void deleteShopping(int id)
        {
            var del = _db.Shoppings.Find(id);
            if (del != null)
            {
                _db.Remove(del);
            }
        }

        public Task<IEnumerable<Shopping>> EditShopping(Shopping e)
        {
            var ID = _db.Shoppings.Where(x => x.Order_id == e.Order_id).AsEnumerable().FirstOrDefault();

            if (ID != null)
            {
                ID.Customer_Id = e.Customer_Id;
                ID.date = e.date;


                _db.Entry(ID).State = EntityState.Modified;
                _db.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Shopping> GetIdByShopping(int id)
        {
            return await _db.Shoppings.FindAsync(id);
        }

        public async Task<IEnumerable<Shopping>> ListShopping()
        {
            return _db.Shoppings.ToList();
        }

        public async Task<IEnumerable<ShoppingVm>> ListShoppingVm()
        {
            return _db.ShoppingVms.FromSqlRaw($"exec sp_bindCustomerNameInShoppingTbl");
        }
    }
}
