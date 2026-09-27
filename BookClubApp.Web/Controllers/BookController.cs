using BookClubApp.Business.Services;
using BookClubApp.Entity.Entities;
using BookClubApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;

namespace BookClubApp.Web.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly ICategoryService _categoryService;

    public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
    {
        _bookService = bookService;
        _authorService = authorService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetAllParamsAsync(b=>b.Author,b=>b.Categories);
        return View(books);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await FillAuthorsAndCategoriesAsync();

        return View();
    }
    private async Task FillAuthorsAndCategoriesAsync()
    {

        var authors = await _authorService.GetAllAsync();
        var categories = await _categoryService.GetAllAsync();

        ViewBag.Authors = new SelectList(authors, "Id", "FullName");
        ViewBag.Categories = new MultiSelectList(categories, "Id", "Name");
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookCreateViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            await FillAuthorsAndCategoriesAsync();
            return View(vm);
        }
        var book = new Book
        {

            Title = vm.Title,
            Description = vm.Description,
            PublishedDate = vm.PublishedDate,
            IsActive =true,
            AuthorId = vm.AuthorId

        };
        var categories = await _categoryService.GetAllAsync();

        if (vm.SelectedCategoryIds!=null&&vm.SelectedCategoryIds.Any())
        {
            var selectedCategories = categories.Where(c => vm.SelectedCategoryIds.Contains(c.Id)).ToList();
            book.Categories= selectedCategories;
        }

        await _bookService.AddAsync(book);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetbyIdParamsAsync(id,b=>b.Author,b=>b.Categories);
        if (book is null) return NotFound();
       
        //Kategori Listesi
        var selectedCategories = book.Categories.Select(c => c.Id) ?? new List<int>();

        await FillEditAction(book.AuthorId, selectedCategories);

        var vm = new BookEditViewModel { 
        
        Id=book.Id,
        Title=book.Title,
        Description=book.Description,
        AuthorId=book.AuthorId

        };

        return View(vm);
    }
    private async Task FillEditAction(int authorId,IEnumerable<int> selectedCategories)
    {
        //Yazar Listesi
        var authors = await _authorService.GetAllAsync();
        ViewBag.Authors = new SelectList(authors, "Id", "FullName", authorId);

        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new MultiSelectList(categories, "Id", "Name", selectedCategories);


    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(BookEditViewModel vm)
    {
        var book = await _bookService.GetbyIdParamsAsync(vm.Id,b=>b.Author,b=>b.Categories);
        if (book is null)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            var selectedCategories = book.Categories.Select(c => c.Id) ?? new List<int>();

            await FillEditAction(book.AuthorId, selectedCategories);
            return View(vm);
        }
        book.Title = vm.Title;
        book.Description = vm.Description;
        book.AuthorId = vm.AuthorId;

        var categories = await _categoryService.GetAllAsync();

        if (vm.SelectedCategoryIds!=null&&vm.SelectedCategoryIds.Any())
        {
            book.Categories.Clear();
            var selectedCategories = categories.Where(c => vm.SelectedCategoryIds.Contains(c.Id)).ToList();
            book.Categories = selectedCategories;

        }
        await _bookService.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetbyIdParamsAsync(id,b=>b.Author,b=>b.Categories);
        if (book is null)
        {
            return NotFound();
        }

        await _bookService.DeleteAsync(book);

        return RedirectToAction("Index");
    }
   }
    


