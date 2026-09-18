using BookClubApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllParamsAsync(b=>b.Author,b=>b.Categories);
            return View(books);
        }
    }
}
