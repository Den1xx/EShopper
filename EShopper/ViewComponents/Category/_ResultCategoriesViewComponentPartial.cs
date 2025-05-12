using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.ViewComponents.Category
{
    public class _ResultCategoriesViewComponentPartial : ViewComponent
    {
        private ICategoryService _categoryService;
        public _ResultCategoriesViewComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}

