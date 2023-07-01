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


        public async Task AddShopping(ShoppingVm e)
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

        public async Task EditShopping(Shopping e)
        {

            try
            {
                var Put = _db.Shoppings.Update(e);
                await _db.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<Shopping> GetIdByShopping(int id)
        {
            return await _db.Shoppings.FindAsync(id);
        }

        public async Task<IEnumerable<ShoppingVm>> ListShoppingVm()
        {
            try
            {
                List<ShoppingVm> p1 = await (from d in _db.Shoppings
                                             join c in _db.Customers on d.Order_id equals c.Id
                                             select new ShoppingVm
                                             {
                                                 First_Name = c.First_Name,
                                                 Order_id = d.Order_id,
                                                 date = DateTime.Now,



                                             }).ToListAsync();


                return p1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        Task IShopping.deleteShopping(int id)
        {
            throw new NotImplementedException();
        }
    }
}
