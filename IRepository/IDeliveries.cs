using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface IDeliveries
    {

        
        public Task<IEnumerable<DeliveryVM>> ListDeliveriesVM();
        public Task AddDeliveries(DeliveryVM deliveryVM);
        public Task EditDeliveries(Deliveries e);
        public Task<Deliveries> GetIdByDeliveries(int id);

        public Task deleteDeliveries(int id);

        

    }
}
