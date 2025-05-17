using System.Diagnostics;
using BLL.Abstract;
using DAL.EFCore;
using EShopper.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
           _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        public IActionResult ProductDetails(int id)
        {
            //var products = _productService.GetOne((p => p.Id == id));
            var products = _productService.Find(id);
            return View(products);
        }
        public IActionResult Products()
        {
            var products2 = _productService.GetAll();
            return View(products2);
        }
        public IActionResult Contact() {
        
            return View();
        }

    }
}
