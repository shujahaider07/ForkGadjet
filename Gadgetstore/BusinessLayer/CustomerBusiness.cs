using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;

namespace Gadgetstore.BusinessLayer
{
    public class CustomerBusiness : ICustomer
    {
        private readonly ICustomerRepo _Customer;

        public CustomerBusiness(ICustomerRepo _Customer)
        {
            this._Customer = _Customer;
        }
        public async Task AddCustomer(CustomerVM customer)
        {
            try
            {
               

              await _Customer.AddCustomer(customer);
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                await _Customer.DeleteCustomer(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task< IEnumerable<Customer>> GetAllCustomer()
        {
            try
            {
              return  await _Customer.GetAllCustomers();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task <Customer> GetAllCustomerById(int id)
        {
            try
            {

               return await _Customer.CustomerGetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
              await  _Customer.UpdateCustomer(customer);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
