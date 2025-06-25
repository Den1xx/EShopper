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

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _cartService.GetOne(i => i.ApplicationUserId == userId).FirstOrDefault();
         
            return View(cart);
        }
        public async Task<IActionResult> AddToCart(int quantity, int productId, int stock = 1)
        {
            var product = _productService.Find(productId);
            var userId = _userManager.GetUserId(User);

            if (product != null)
            {
                var cart = _cartService.GetOne(i => i.ApplicationUserId == userId).FirstOrDefault();

                if (cart != null)
                {
                    CartItem cartItem = new CartItem()
                    {
                        ProductId = product.Id,
                        Price = product.Price,
                        Quantity = quantity * stock,
                        CartId = cart.Id
                    };

                    await _cartService.AddToCartAsync(cartItem);

                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    Cart userCart = new Cart();
                    userCart.ApplicationUserId = userId;
                    _cartService.Create(userCart);

                    userCart = _cartService.GetOne(i => i.ApplicationUserId == userId).FirstOrDefault();

                    if (userCart != null)
                    {
                        CartItem cartItem = new CartItem()
                        {
                            ProductId = product.Id,
                            Price = product.Price,
                            Quantity = quantity,
                            CartId = userCart.Id
                        };

                        await _cartService.AddToCartAsync(cartItem);

                        return RedirectToAction("Index", "Cart");
                    }
                }
            }

            return View();
        }

        public IActionResult DeleteFromCart(int productId)
        {
            if (productId == null)
            {
                TempData["message"] = "Ürün Bulunamadı";
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
