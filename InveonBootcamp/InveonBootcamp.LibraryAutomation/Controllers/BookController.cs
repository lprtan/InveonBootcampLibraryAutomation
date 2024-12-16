using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services.Abstract;
using EntityLayer.Concrete;
using AutoMapper;
using CoreLayer.Mapping;
using CoreLayer.Dtos;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class BookController : Controller
    {
        private readonly IGenericService<Book> _bookService;
        private readonly IBookMappingService _bookMappingService;
        public BookController(IGenericService<Book> bookService, IBookMappingService bookMappingService)
        {
            _bookService = bookService;
            _bookMappingService = bookMappingService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();

            var bookListDto = _bookMappingService.MapToBookListDto(books);

            return View(bookListDto);
        }

        public async Task<IActionResult> AdminBookDetails()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public async Task<IActionResult> Update(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateAsync(id, book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(book);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            var bookDetail = _bookMappingService.MapToBookDetailsDto(book);

            return View(bookDetail);
        }
    }
}
