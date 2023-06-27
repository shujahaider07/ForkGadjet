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

        public void AddDeliveries(DeliveryVM deliveryVM)
        {
            try
            {
                _db.Delivery.Add(new Deliveries()
                {

                    Deliveries_id = deliveryVM.Deliveries_id,
                    Customer_id = deliveryVM.Customer_id,
                    Date = deliveryVM.Date,

                });
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void deleteDeliveries(int id)
        {
            try
            {
                var del = _db.Delivery.Find(id);
                _db.Delivery.Remove(del);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditDeliveries(Deliveries e)
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

        public Deliveries GetIdByDeliveries(int id)
        {
            try
            {

                return _db.Delivery.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Deliveries> ListDeliveries()
        {
            try
            {
                return _db.Delivery.OrderByDescending(x => x.Customer_id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DeliveryVM> ListDeliveriesVM()
        {
            try
            {
                List<DeliveryVM> p1 = (from d in _db.Delivery
                                          join c in _db.Customers on d.Customer_id equals c.Id
                                          select new DeliveryVM
                                          {
                                              Customer_Name = c.First_Name,
                                              Deliveries_id = d.Deliveries_id,


                                          }).ToList();


                return p1;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
