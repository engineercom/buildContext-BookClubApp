using BookClubApp.Business.Services;
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
        var authors=await _authorService.GetAllAsync();
        return View(authors);
    }
}
