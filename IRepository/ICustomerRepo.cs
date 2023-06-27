using Entities;
using EntitiesViewModels;

namespace IRepository
{
    public interface ICustomerRepo
    {
        public Task AddCustomer(CustomerVM customerVM);
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomer(int id);
        public Task <Customer> CustomerGetById(int id);
        public Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
