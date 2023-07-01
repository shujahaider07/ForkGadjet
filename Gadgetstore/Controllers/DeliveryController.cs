using AspNetCoreHero.ToastNotification.Abstractions;
using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gadgetstore.Controllers
{
    public class DeliveryController : Controller
    {
    //    private readonly IDeliveries _delivery;
        private readonly INotyfService _notyf;
        private readonly ApplicationDbContext _db;
        private readonly IDeliveryBusiness deliveryBusiness;


        public DeliveryController(IDeliveryBusiness deliveryBusiness, INotyfService _notyf, ApplicationDbContext _db)
        {
            
            this._notyf = _notyf;
            this._db = _db;
            this.deliveryBusiness = deliveryBusiness;
        }


        [HttpGet]
        public async Task<IActionResult> ListDelivery()
        {

            var list = await deliveryBusiness.GetAllDeliveryVM();
            return View(list);

        }


        [HttpGet]
        public async Task<IActionResult> AddDelivery()
        {

            List<Customer> customers = await _db.Customers.Select(x => new Customer { Id = x.Id, First_Name = x.First_Name }).ToListAsync();
            ViewBag.CustomerName = new SelectList(customers, "Id", "First_Name");

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> AddDelivery(DeliveryVM e)
        {
          
            if (ModelState.IsValid)
            {
                await deliveryBusiness.AddDelivery(e);
            }
            _notyf.Success("Insert Successfull", 5);
            return RedirectToAction("AddDelivery");

        }



        [HttpPost]
        public async Task<IActionResult> UpdateDelivery(Deliveries e)
        {
            if (ModelState.IsValid)
            {
               await deliveryBusiness.UpdateDelivery(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListDelivery");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateDelivery(int id)
        {
            Deliveries model = await deliveryBusiness.DeliveryById(id);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {
            
           await deliveryBusiness.DeleteDelivery(id);
            return View();

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Deliveries pro = await deliveryBusiness.DeliveryById(id);
              await  deliveryBusiness.DeleteDelivery(id);
                _notyf.Success("Delete Successfull", 5);
                return RedirectToAction("ListDelivery");
            }
            else
            {
                return RedirectToAction("Delete");
            }


        }





    }
}
