

using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment ;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Upsert(int? id)
         {
            Product product = new Product();
            ProductViewModel productVM = new()
            {
                product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(U => new SelectListItem
                { Text = U.Name, Value = U.Id.ToString() }

                ),
                CoverTypeList = _unitOfWork.covertype.GetAll().Select(i=>new SelectListItem
                {
                    Text = i.Name, 
                    Value = i.Id.ToString()
                })
            };
            var CoverList = _unitOfWork.covertype.GetAll();
            if(id == null)
            {
                //ViewBag.CategoryList=CategoryList;
                //ViewBag.CoverTypeList=CoverTypeList;
                return View(productVM);
            }
            else
            {
                productVM.product = _unitOfWork.product.GetFirstOrDefault(i => i.Id == id);
                return View(productVM);
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(ProductViewModel Obj, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var upload = Path.Combine(wwwRootPath, @"Images\Product");
                    var extension = Path.GetExtension(file.FileName);

                    if( Obj.product.ImgUrl !=null )
                    {
                        var oldImgPath = Path.Combine(wwwRootPath,Obj.product.ImgUrl.TrimStart('\\')); 
                        if(System.IO.File.Exists(oldImgPath))
                        {
                             System.IO.File.Delete(oldImgPath);
                        }
                    }

                    using (var filestrean = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(filestrean);
                        Obj.product.ImgUrl = @"\Images\Product\"+filename + extension;
                    }
                }
                
                if(Obj.product.Id == 0)
                {
                    _unitOfWork.product.Add(Obj.product);
                }
                else
                {
                    _unitOfWork.product.Update(Obj.product);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Product added Successfully";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }

        //public IActionResult Delete (int? id)
        //{
        //    if(id == null || id==0)
        //    {
        //        return NotFound();
        //    }
        //    var CoverTypeFromDb = _unitOfWork.covertype.GetFirstOrDefault(u=>u.Id ==id);
        //    if(CoverTypeFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(CoverTypeFromDb);
        //}

        [HttpDelete]
        
        public IActionResult Delete (int id)
        {
            var obj = _unitOfWork.product.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            
            
                var oldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImgUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
           
            _unitOfWork.product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deled Successfully !" });
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ProductList = _unitOfWork.product.GetAll(includeProperties:"Category,CoverType");
            return Json(new { data= ProductList } );
        }
        

    }
}
