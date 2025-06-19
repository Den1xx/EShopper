using AutoMapper;
using BLL.Abstract;
using DAL.DTOs.ProductDto;
using DAL.Migrations;
using ENTITY;
using EShopper.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom;

namespace EShopper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public readonly IMapper _mapper;
        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Brands = _brandService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCreateDTO productCreateDTO, IFormFile[] files)
        {
            ModelState.Remove("Comments");
            ModelState.Remove("Categories");
            ModelState.Remove("Brand");
            if (ModelState.IsValid)
            {
                Product p = _mapper.Map<Product>(productCreateDTO);
                if (files != null)
                {
                    foreach (IFormFile item in files)
                    {
                        p.Images.Add(new Image() { Url = await ImageOperations.UploadImageAsync(item) });
                    }
                }
                p.CreatedDate = DateTime.Now;
                _productService.Create(p);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(productCreateDTO);
        }
        //public IActionResult Delete(Product entity)
        //{
        //    var product = _productService.Find(entity.Id);
        //    _productService.Delete(product);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int productId)
        //{
        //    _productService.Delete(productId);

        //    return RedirectToAction("Index");
        //}

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Bir ürün seçiniz.";
                return RedirectToAction("Index");
            }
            var products = _productService.Find(id.Value);

            if (products == null)
            {
                TempData["message"] = "Seçilen ürün bulunamadı.";
                return RedirectToAction("Index");
            }

            var product = _mapper.Map<ProductUpdateDTO>(products);
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Brands = _brandService.GetAll();
            return View(product);

        }
        //[HttpPost]
        //public async Task<ActionResult> Update(ProductUpdateDTO updateProduct, IFormFile[] files, int[] ImageId)
        //{
        //    ModelState.Remove("Comments");
        //    ModelState.Remove("Categories");
        //    ModelState.Remove("Brand");
        //    if (ModelState.IsValid)
        //    {
        //        Product p = _mapper.Map<Product>(updateProduct);
        //        if (files != null)
        //        {
        //            foreach (IFormFile item in files)
        //            {
        //                p.Images.Add(new Image() { Url = await ImageOperations.UploadImageAsync(item) });
        //            }
        //        }
        //        p.CreatedDate = DateTime.Now;
        //        _productService.Create(p);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Categories = _categoryService.GetAll();
        //    ViewBag.Categories = _brandService.GetAll();
        //    return View(updateProduct);
        //}
        [HttpPost]
        public async Task<ActionResult> Update(ProductUpdateDTO updateProduct, IFormFile[] files, int[] ImageId)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.Find(updateProduct.Id);
                var oldImages = new List<Image>();
                updateProduct.Images = product.Images;

                if (files != null)
                {
                    foreach (var imageId in ImageId)
                    {
                        var Img = product.Images.Where(i => i.Id == imageId).FirstOrDefault();
                        oldImages.Add(Img);
                        ImageOperations.DeleteImage(Img.Url);
                        updateProduct.Images.Remove(Img);
                    }


                    foreach (IFormFile item in files)
                    {
                        updateProduct.Images.Add(new Image() { Url = await ImageOperations.UploadImageAsync(item) });

                    }
                }
                updateProduct.ModifiedDate = DateTime.Now;


                product = _mapper.Map<Product>(updateProduct);

                //_productService.Update(product, oldImages);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(updateProduct);
        }
    }

}
