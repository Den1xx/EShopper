using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.ViewComponents.Brand
{
    public class _ResultBrandsViewComponentPartial : ViewComponent
    {
        private IBrandService _brandService;
        public _ResultBrandsViewComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;   
        }
        public IViewComponentResult Invoke()
        {
            return View(_brandService.GetAll());
        }
    }
}
