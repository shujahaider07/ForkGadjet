using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;

namespace Gadgetstore.BusinessLayer
{
    public class DeliveryBusiness : IDeliveryBusiness
    {
        private readonly IDeliveries deliveryRepo;
        public DeliveryBusiness(IDeliveries deliveryRepo)
        {
            this.deliveryRepo = deliveryRepo;

        }
        public async Task AddDelivery(DeliveryVM deliveryVM)
        {
            try
            {
                await deliveryRepo.AddDeliveries(deliveryVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteDelivery(int id)
        {
            try
            {

                await deliveryRepo.deleteDeliveries(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Deliveries> DeliveryById(int id)
        {
            try
            {
                return await deliveryRepo.GetIdByDeliveries(id);
            }
            catch (Exception)
            {

                throw;
            }
        }




        public async Task UpdateDelivery(Deliveries delivery)
        {
            try
            {
                await deliveryRepo.EditDeliveries(delivery);

            }
            catch (Exception)
            {

                throw;
            }
        }

         async Task<IEnumerable<DeliveryVM>> IDeliveryBusiness.GetAllDeliveryVM()
        {
            try
            {
                return await deliveryRepo.ListDeliveriesVM();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
