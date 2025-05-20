using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.ViewComponents.Reccommended
{
    public class _ResultRecommendedViewComponentPartial : ViewComponent
    {
        private IProductService _productService;
        public _ResultRecommendedViewComponentPartial(IProductService productService)
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
