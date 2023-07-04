using BulkyBooksWeb.Models;
using DbExploration.Data;
using Microsoft.AspNetCore.Mvc;


namespace BulkyBooksWeb.Controllers;

public class CategoryController : Controller
{ 
    private readonly ApiDbContext _db;

    [ActivatorUtilitiesConstructor]
    public CategoryController(ApiDbContext db)
    {
        _db = db;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
        IEnumerable<Category> objCatList=_db.Categories.ToList();
        return View(objCatList);
    }

    // GET: 
    public IActionResult Create()
    {
        return View();
    }

    // POST:
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if(obj.Name==obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid) {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Added Successfully!";
            return RedirectToAction("Index");
        }
        return View(obj);   
    }

    // GET: 
    public IActionResult Edit(int? id) 
    {
        if(id==null || id == 0) {
            return NotFound();
        }

        var category = _db.Categories.Find(id);
        if (category == null) {
            return NotFound();
        }

        return View(category);
    }

    // POST:
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Updated Successfully!";

            return RedirectToAction("Index");
        }
        return View(obj);
    }

    // GET: 
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var category = _db.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // POST:
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCategory(int? id)
    {
        var cat = _db.Categories.Find(id);
        if (cat == null) {
            return NotFound();
        }

        _db.Categories.Remove(cat);
        _db.SaveChanges();
        TempData["success"] = "Category Deleted Successfully!";

        return RedirectToAction("Index");
    }
}


