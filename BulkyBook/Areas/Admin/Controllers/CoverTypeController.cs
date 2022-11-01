using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            var CatList = _unitOfWork.covertype.GetAll();
            return View(CatList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(CoverType obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.covertype.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type Added Succesfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CatObj = _unitOfWork.covertype.GetFirstOrDefault(u => u.Id == id);
            if (CatObj == null)
            {
                return NotFound();
            }

            return View(CatObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType Obj)
        {
            if (Obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.covertype.Update(Obj);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type Updated Succesfully";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }
        public IActionResult Delete(int? id)
        {
            var CatObj = _unitOfWork.covertype.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Save();
            return View(CatObj);
        }

        [HttpPost]

        public IActionResult DeleteCoverType(int? id)
        {
            var CatObj = _unitOfWork.covertype.GetFirstOrDefault(u => u.Id == id);
            if (CatObj == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.covertype.Remove(CatObj);
                _unitOfWork.Save();
                TempData["error"] = "Cover Type Deleted Succesfully";
                return RedirectToAction("Index");
            }
            
        }
    }
}
