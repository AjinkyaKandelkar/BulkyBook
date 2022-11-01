using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            var CatList = _unitOfWork.Category.GetAll();
            return View(CatList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Order cannot be same");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Added Succesfully";
                return RedirectToAction("Index");

            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CatObj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (CatObj == null)
            {
                return NotFound();
            }

            return View(CatObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cat)
        {
            if (cat == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(cat);
                _unitOfWork.Save();
                TempData["Success"] = "Category Updated Succesfully";
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        public  IActionResult Delete(int? id)
        {
            var CatObj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Save();
            return View(CatObj);
        }

        [HttpPost]

        public IActionResult DeleteCategory(int? id)
        {
            var CatObj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (CatObj == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Category.Remove(CatObj);
                _unitOfWork.Save();
                TempData["error"] = "Category Deleted Succesfully";
                return RedirectToAction("Index");
            }
           
        }
    }
}
