using BLL.Abstract;
using DAL.Migrations;
using ENTITY;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products =_productService.GetAll();
            return View(products);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, IFormFile[] file)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
