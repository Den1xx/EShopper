using BLL.Abstract;
using ENTITY;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CartController(ICartService cartService, IProductService productService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _productService = productService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
