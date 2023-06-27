namespace Gadgetstore.Controllers
{
    using AspNetCoreHero.ToastNotification.Abstractions;
    using DbContextForApplicationLayer;
    using Entities;
    using global::Gadgetstore.BusinessInterface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    namespace Gadgetstore.Controllers
    {
        public class ProductController : Controller
        {

            private readonly INotyfService _notyf;
            private readonly ApplicationDbContext db;
            private readonly IproductBusiness productbusiness;
            private readonly ILogger <ProductController> _logger;


            public ProductController(ILogger<ProductController> logger, IproductBusiness productbusiness, INotyfService _notyf, ApplicationDbContext db)
            {
                this.productbusiness = productbusiness;
                this._notyf = _notyf;
                this.db = db;
                _logger = logger;
            }


            [HttpGet]
            public async Task<IActionResult> Listproduct()
            {
                try
                {
                    var list = await productbusiness.GetAllProductsAsync();
                    return View(list);
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "An error occurred while executing Listproduct action.");
                    return View("Error");
                }
            }


            [HttpGet]
            public async Task<IActionResult> Addproduct()
            {
                try
                {
                    List<Category> categoriesInproduct = await db.Categories.Select(x => new Category { Category_id = x.Category_id, Category_Name = x.Category_Name }).ToListAsync();
                    ViewBag.Category = new SelectList(categoriesInproduct, "Category_id", "Category_Name");
                    return View();
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }


            [HttpPost]
            public async Task<IActionResult> Addproduct(Products e)
            {
                try
                {
                    await productbusiness.AddProductAsync(e);
                    _notyf.Success("Insert Successful", 5);
                    return RedirectToAction("Listproduct");
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }


            [HttpPost]
            public async Task<IActionResult> Updateproduct(Products e)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        await productbusiness.UpdateProductAsync(e);
                    }
                    _notyf.Success("Update Successful", 5);
                    return RedirectToAction("Listproduct");
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }


            [HttpGet]
            public async Task<ActionResult> Updateproduct(int id)
            {
                try
                {
                    Products model = await productbusiness.GetProductByIdAsync(id);

                    List<Category> categoriesInproduct = db.Categories.Select(x => new Category { Category_id = x.Category_id, Category_Name = x.Category_Name }).AsEnumerable().ToList();
                    ViewBag.Category = new SelectList(categoriesInproduct, "Category_id", "Category_Name");


                    return View(model);
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }


            [HttpGet]
            public async Task<IActionResult> Delete(int id, bool? saveChangesError)
            {
                try
                {
                    Products pro = await productbusiness.GetProductByIdAsync(id);
                    return View(pro);
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }


            [HttpPost, ActionName("Delete")]
            public async Task<ActionResult> Delete(int id)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Products pro = await productbusiness.GetProductByIdAsync(id);
                        await productbusiness.DeleteProductAsync(id);
                        _notyf.Success("Delete Successful", 5);
                        return RedirectToAction("Listproduct");
                    }
                    else
                    {
                        return RedirectToAction("Delete");
                    }
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }


        }

    }
}
