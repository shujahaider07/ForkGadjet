using AspNetCoreHero.ToastNotification.Abstractions;
using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gadgetstore.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IShopping _Shopping;
        private readonly INotyfService _notyf;
        private readonly ApplicationDbContext db;

        public ShoppingController(IShopping _Shopping, INotyfService _notyf, ApplicationDbContext db)
        {
            this._Shopping = _Shopping;
            this._notyf = _notyf;
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> ListShopping()
        {

            var list = await _Shopping.ListShoppingVm();

            return View(list);

        }


        [HttpGet]
        public async Task<IActionResult> AddShopping()
        {


            List<Customer> customers = db.Customers.Select(x => new Customer { Id = x.Id, First_Name = x.First_Name }).AsEnumerable().ToList();
            ViewBag.Customername = new SelectList(customers,"Id" , "First_Name");


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> AddShopping(ShoppingVm e)
        {
            await _Shopping.AddShopping(e);
            _notyf.Success("Insert Successfull", 5);
            return RedirectToAction("AddShopping");

        }



        [HttpPost]
        public async Task<IActionResult> UpdateShopping(Shopping e)
        {
            if (ModelState.IsValid)
            {
                _Shopping.EditShopping(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListShopping");

        }

        [HttpGet]
        public async Task<ActionResult> Updateproduct(int id)
        {
            Shopping model = await _Shopping.GetIdByShopping(id);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            Shopping pro = await _Shopping.GetIdByShopping(id);
            return View(pro);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Shopping pro = await _Shopping.GetIdByShopping(id);
                _Shopping.deleteShopping(id);
                _notyf.Success("Delete Successfull", 5);
                return RedirectToAction("ListShopping");
            }
            else
            {
                return RedirectToAction("Delete");
            }


        }




    }
}
