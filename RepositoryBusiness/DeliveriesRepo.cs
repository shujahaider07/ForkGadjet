using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{
    public class DeliveriesRepo : IDeliveries
    {

        private readonly ApplicationDbContext _db;

        public DeliveriesRepo(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task AddDeliveries(DeliveryVM deliveryVM)
        {
            try
            {
                await _db.Delivery.AddAsync(new Deliveries()
                {

                    Deliveries_id = deliveryVM.Deliveries_id,
                    Customer_id = deliveryVM.Customer_id,
                    Date = deliveryVM.Date,

                });
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task deleteDeliveries(int id)
        {
            try
            {
                var del = await _db.Delivery.FindAsync(id);
                _db.Delivery.Remove(del);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditDeliveries(Deliveries e)
        {
            try
            {
                _db.Delivery.Update(e);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Deliveries> GetIdByDeliveries(int id)
        {
            try
            {

                return await _db.Delivery.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        public async Task <IEnumerable<DeliveryVM>> ListDeliveriesVM()
        {
            try
            {
                List<DeliveryVM> p1 = await (from d in _db.Delivery
                                             join c in _db.Customers on d.Customer_id equals c.Id
                                             select new DeliveryVM
                                             {
                                                 Customer_Name = c.First_Name,
                                                 Deliveries_id = d.Deliveries_id,
                                                 Customer_id = d.Customer_id,


                                             }).ToListAsync();


                return p1;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
