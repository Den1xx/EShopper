using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.ViewComponents.Product
{
    public class _ResultProductViewComponentPartial : ViewComponent
    {
        private IProductService _productService;
        public _ResultProductViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            var product = _productService.GetAll();
            return View(product);
        }
    }
}
