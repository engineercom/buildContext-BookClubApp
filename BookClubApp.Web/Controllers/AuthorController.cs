using BookClubApp.Business.Services;
using BookClubApp.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Web.Controllers;

public class AuthorController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _authorService.GetAllAsync();
        return View(authors);
    }
    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        await _authorService.AddAsync(author);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author is null)
        {
            return NotFound();
        }

        return View(author);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Author author)
    {
        var getAuthor = await _authorService.GetByIdAsync(author.Id);
        if (getAuthor is null) { return NotFound(); }

        getAuthor.FullName = author.FullName;
        getAuthor.Biography = author.Biography;

        await _authorService.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author is null)
            return NotFound();
        await _authorService.DeleteAsync(author);

        return RedirectToAction(nameof(Index));
    }


}
