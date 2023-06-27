using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryBusiness
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepo(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task AddCustomer(CustomerVM customerVM)
        {

            using (var ExceptionDb = _db.Database.BeginTransaction())
            {
                try
                {
                    var add = await _db.Customers.AddAsync(new Customer
                    {

                        Age = customerVM.Age,
                        contact = customerVM.contact,
                        Email = customerVM.Email,
                        First_Name = customerVM.First_Name,
                        gender = customerVM.gender,
                        Last_Name = customerVM.Last_Name,

                    });

                    await _db.SaveChangesAsync();

                    await ExceptionDb.CommitAsync();

                }


                catch (Exception)
                {
                    await ExceptionDb.RollbackAsync();
                    throw;
                }


            }
        }




        public async Task<Customer> CustomerGetById(int id)
        {
            try
            {
                return await _db.Customers.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task DeleteCustomer(int id)
        {
            var del = _db.Customers.Find(id);
            _db.Remove(del);
        }



        public async Task UpdateCustomer(Customer customer)
        {
            try
            {

                _db.Customers.Update(customer);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task<IEnumerable<Customer>> ICustomerRepo.GetAllCustomers()
        {
            return await _db.Customers.OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}