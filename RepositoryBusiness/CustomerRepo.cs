using AspNetCore;
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
                        IsDelete = 0,

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
            

            try
            {
                var Customer = await _db.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (Customer != null)
                {
                    Customer.IsDelete = 1;
                    _db.Customers.Update(Customer);
                    await _db.SaveChangesAsync();

                }
                

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

                _db.Customers.Update(customer);
                customer.IsDelete = 0;
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task<IEnumerable<Customer>> ICustomerRepo.GetAllCustomers()
        {
            return await _db.Customers.OrderByDescending(x => x.Id).Where(x => x.IsDelete == 0).ToListAsync();
        }
    }
}