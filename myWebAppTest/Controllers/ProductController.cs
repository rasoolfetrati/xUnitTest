using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myWebAppTest.Models.Entities;
using myWebAppTest.Models.Service;

namespace myWebAppTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _pservice;
        public ProductController(IProductService pservice)
        {
            _pservice = pservice;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_pservice.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var res = _pservice.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _pservice.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ProductController/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var res = _pservice.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            _pservice.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
