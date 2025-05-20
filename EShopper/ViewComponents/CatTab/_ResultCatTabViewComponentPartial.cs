using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.ViewComponents.CatTab
{
    public class _ResultCatTabViewComponentPartial : ViewComponent
    {
        private IProductService _productService;
        public _ResultCatTabViewComponentPartial(IProductService productService)
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
