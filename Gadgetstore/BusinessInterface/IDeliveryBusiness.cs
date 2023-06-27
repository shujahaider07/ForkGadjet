using Entities;
using EntitiesViewModels;

namespace Gadgetstore.BusinessInterface
{
    public interface IDeliveryBusiness
    {
        public void AddDelivery(DeliveryVM deliveryVM);
        public void UpdateDelivery(Deliveries delivery);
        public void DeleteDelivery(int id);
        public Deliveries DeliveryById(int id);
        public IEnumerable<Deliveries> GetAllDelivery ();
        public IEnumerable<DeliveryVM> GetAllDeliveryVM ();
       
    }
}
