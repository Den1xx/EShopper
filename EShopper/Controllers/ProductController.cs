using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products =_productService.GetAll();
            return View(products);
        }
    }
}
