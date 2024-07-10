using Book_Store_Data.Repository.Interfaces;
using Book_Store_Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categoriesData = _unitOfWork.categoryRepository.GetAll().ToList();
            return View(categoriesData);

        }
        // Create 
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can't Exactly match The Display Order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.categoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        // Update  [Get]
        public IActionResult Update(int? id)
        {
            if (id == 0 || id is null) return NotFound();
            Category? categoryFromDb = _unitOfWork.categoryRepository.Get(u => u.Id == id);
            if (categoryFromDb is null) return NotFound();
            return View(categoryFromDb);
        }
        // Update  [Post]
        [HttpPost]
        public IActionResult Update(Category category)
        {

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can't Exactly match The Display Order");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.categoryRepository.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Upadated Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        // Delete [Get]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id is null) return NotFound();
            Category? categoryFromDb = _unitOfWork.categoryRepository.Get(u => u.Id == id);
            if (categoryFromDb is null) return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? categoryFromDb = _unitOfWork.categoryRepository.Get(u => u.Id == id);
            if (categoryFromDb is null) return NotFound();
            _unitOfWork.categoryRepository.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category Removed Successfully";
            return RedirectToAction("Index");

        }

    }
}
