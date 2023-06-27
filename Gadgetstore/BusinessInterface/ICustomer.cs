using Entities;
using EntitiesViewModels;

namespace Gadgetstore.BusinessInterface
{
    public interface ICustomer
    {
        public Task AddCustomer(CustomerVM customervm);
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomer(int id);
        public Task<IEnumerable<Customer>> GetAllCustomer();
        public Task <Customer> GetAllCustomerById(int id);

    }
}
