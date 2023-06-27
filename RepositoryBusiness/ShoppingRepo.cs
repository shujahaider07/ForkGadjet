using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{
    public class ShoppingRepo : IShopping
    {

        private readonly ApplicationDbContext _db;

        public ShoppingRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }


        public async Task AddShopping(Shopping e)
        {
            try
            {
                await _db.Shoppings.AddAsync(new Shopping
                {
                    Customer_Id = e.Customer_Id,
                    date = DateTime.Now,
                    Order_id = e.Order_id,


                });

                await _db.SaveChangesAsync();
              

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

           
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
