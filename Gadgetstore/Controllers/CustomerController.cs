using AspNetCoreHero.ToastNotification.Abstractions;
using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using Gadgetstore.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gadgetstore.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomer _CustomerBusiness;
        private readonly ApplicationDbContext db;
        private readonly INotyfService _notyf;
        private readonly ILogger<CustomerController> logger;



        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext db, ICustomer _CustomerBusiness, INotyfService _notyf)
        {
            this._CustomerBusiness = _CustomerBusiness;
            this._notyf = _notyf;
            this.db = db;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListCustomer()
        {
            try
            {
                var list = await _CustomerBusiness.GetAllCustomer();
                return View(list);
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            try
            {
                List<SelectListItem> Gender = new()
        {
            new SelectListItem { Value = "1", Text = "Male" },
            new SelectListItem { Value = "2", Text = "Female" },
        };

                ViewBag.cities = Gender;
                return View();
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerVM e)
        {
            try
            {
                await _CustomerBusiness.AddCustomer(e);
                _notyf.Success("Insert Successful", 5);
                return RedirectToAction("ListCustomer");
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _CustomerBusiness.UpdateCustomer(e);
                }
                _notyf.Success("Update Successful", 5);
                return RedirectToAction("ListCustomer");
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            try
            {
                Customer model = await _CustomerBusiness.GetAllCustomerById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {
            try
            {
                Customer Csu = await _CustomerBusiness.GetAllCustomerById(id);
                return View(Csu);
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer c = await _CustomerBusiness.GetAllCustomerById(id);

                    await _CustomerBusiness.DeleteCustomer(id);

                    _notyf.Success("Delete Successful", 5);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception or display an error message
                logger.LogError(ex.Message);
                throw;
            }

            return RedirectToAction("ListCustomer");
        }

    }
}
