using Book_Store_Data;
using Book_Store_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataDbContext _dbContext;
        public CategoryController(DataDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var categoriesData = _dbContext.Categories.ToList();
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
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        // Update 
        public IActionResult Update(int? id)
        {
            if (id == 0 || id is null) return NotFound();
            Category? categoryFromDb = _dbContext.Categories.Find(id);
            if (categoryFromDb is null) return NotFound();
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can't Exactly match The Display Order");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category Upadated Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        // Delete 
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id is null) return NotFound();
            Category? categoryFromDb = _dbContext.Categories.Find(id);
            if (categoryFromDb is null) return NotFound();
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? categoryFromDb = _dbContext.Categories.Find(id);
            if (categoryFromDb is null) return NotFound();
            _dbContext.Categories.Remove(categoryFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Category Removed Successfully";
            return RedirectToAction("Index");

        }

    }
}
