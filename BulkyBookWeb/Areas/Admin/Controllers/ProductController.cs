using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverType = _unitOfWork.CoverTypes.GetAll();
            return View(objCoverType);
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            if (id == null || id == 0)
            {
                // create product

                return View(product);
            }
            else
            {
                // update product
            }

            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypes.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverTypesFromDb = _unitOfWork.CoverTypes.GetFirstOrDefault(u => u.Id == id);

            if (coverTypesFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypesFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverTypes.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverTypes.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType Deleted Successfully";
            return RedirectToAction("Index");


        }
    }
}
