using LibrarySystem.Models;
using LibrarySystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;

        public BooksController(
            IBookService bookService,
            IAuthorService authorService,
            ICategoryService categoryService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["AuthorId"] =
                new SelectList(await _authorService.GetAllAsync(),
                "Id", "Name");

            ViewData["CategoryId"] =
                new SelectList(await _categoryService.GetAllAsync(),
                "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            await _bookService.CreateAsync(book);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            ViewData["AuthorId"] =
                new SelectList(await _authorService.GetAllAsync(),
                "Id", "Name", book.AuthorId);

            ViewData["CategoryId"] =
                new SelectList(await _categoryService.GetAllAsync(),
                "Id", "Name", book.CategoryId);

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(book);

            await _bookService.UpdateAsync(book);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}
