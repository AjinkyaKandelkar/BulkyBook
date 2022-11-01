

using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Upsert(int? id)
         {
            Company company = new ();
           
            if(id == null)
            {
               
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(i => i.Id == id);
                return View(company);
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Company Obj)
        {
            if(ModelState.IsValid)
            {
               
                if(Obj.Id == 0)
                {
                    _unitOfWork.Company.Add(Obj);
                }
                else
                {
                    _unitOfWork.Company.Update(Obj);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Company added Successfully";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }

        [HttpDelete]
        
        public IActionResult Delete (int id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
          
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully !" });
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var CompanyList = _unitOfWork.Company.GetAll();
            return Json(new { data= CompanyList } );
        }
        

    }
}
