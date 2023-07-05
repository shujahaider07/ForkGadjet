using AspNetCoreHero.ToastNotification.Abstractions;
using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Gadgetstore.Controllers
{
    public class CategoryController : Controller
    {
       // private readonly ICategory _category;
        private readonly IcategoryBusiness _categoryBusiness;

        private readonly INotyfService _notyf;
        // private readonly INotyfService _notyf;

        public CategoryController(IcategoryBusiness _categoryBusiness, INotyfService _notyf)
        {
            this._categoryBusiness = _categoryBusiness;
            this._notyf = _notyf;
        }


        [HttpGet]
        public async Task<IActionResult> ListCategory()
        {

            var list =  _categoryBusiness.GetAllCategory();

            return View(list);

        }


        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryVM e)
        {
            e.IsDelete = 0;
            _categoryBusiness.AddCategory(e);
        
            _notyf.Success("Insert Successfull", 5);
            return RedirectToAction("AddCategory");

        }



        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category e)
        {
            if (ModelState.IsValid)
            {
                e.IsDelete = 0;
                await _categoryBusiness.UpdateCategory(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListCategory");

        }

        [HttpGet]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            Category model =  _categoryBusiness.CategoryById(id);
            return View(model);
        }




        [HttpGet]
        public IActionResult Delete(int id, bool? saveChangesError)
        {

            Category pro =  _categoryBusiness.CategoryById(id);
            return View(pro);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                //Category pro = _categoryBusiness.CategoryById(id);
               await _categoryBusiness.DeleteCategory(id);
                _notyf.Success("Delete Successfull", 5);
                return RedirectToAction("ListCategory");
            }
            else
            {
                return RedirectToAction("Delete");
            }


            }





    }
}
