using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IDeliveries
    {

        public IEnumerable<Deliveries> ListDeliveries();
        public IEnumerable<DeliveryVM> ListDeliveriesVM();
        public void AddDeliveries(DeliveryVM deliveryVM);
        public void EditDeliveries(Deliveries e);
        public Deliveries GetIdByDeliveries(int id);

        public void deleteDeliveries(int id);

        

    }
}
