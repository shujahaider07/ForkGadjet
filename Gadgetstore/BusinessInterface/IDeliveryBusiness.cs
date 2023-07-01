using Entities;
using EntitiesViewModels;

namespace Gadgetstore.BusinessInterface
{
    public interface IDeliveryBusiness
    {
        public Task AddDelivery(DeliveryVM deliveryVM);
        public Task UpdateDelivery(Deliveries delivery);
        public Task DeleteDelivery(int id);
        public Task <Deliveries> DeliveryById(int id);
       
        public Task <IEnumerable<DeliveryVM>> GetAllDeliveryVM();

       
    }
}
