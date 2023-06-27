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
        public void AddDelivery(DeliveryVM deliveryVM)
        {
            try
            {
                deliveryRepo.AddDeliveries(deliveryVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDelivery(int id)
        {
            try
            {

                deliveryRepo.deleteDeliveries(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Deliveries DeliveryById(int id)
        {
            try
            {
              return deliveryRepo.GetIdByDeliveries(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Deliveries> GetAllDelivery()
        {
            try
            {

                return deliveryRepo.ListDeliveries();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DeliveryVM> GetAllDeliveryVM()
        {
            try
            {
                 return deliveryRepo.ListDeliveriesVM();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDelivery(Deliveries delivery)
        {
            try
            {
                deliveryRepo.EditDeliveries(delivery);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
