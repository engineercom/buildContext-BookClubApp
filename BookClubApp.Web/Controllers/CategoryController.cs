using BookClubApp.Business.Services;
using BookClubApp.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _categoryService.GetAllAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        await _categoryService.AddAsync(category);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category is null)
        {
            return NotFound();
        }

        return View(category);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Category category)
    {
        if (!ModelState.IsValid)

        {
            return View(category);
        }

        var getCategory = await _categoryService.GetByIdAsync(category.Id);

        if (getCategory is null)
            return NotFound();

        getCategory.Name = category.Name;
        await _categoryService.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category is null)
            return NotFound();
        
        await _categoryService.DeleteAsync(category);

        return RedirectToAction("Index");
    }

}
