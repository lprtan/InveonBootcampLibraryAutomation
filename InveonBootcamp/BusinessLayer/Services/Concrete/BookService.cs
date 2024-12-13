using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class BookService : GenericService<Book> , IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BookListDto>> BookListAsync()
        {
            //var bookList = new List<BookListDto>();

            var books = await _unitOfWork.BookRepository.GetAllAsync();

            var bookListDto = _mapper.Map<List<BookListDto>>(books);

            //foreach (var book in books) 
            //{
            //    var bookListDto = new BookListDto
            //    {
            //        Id = book.Id,
            //        Title = book.Title,
            //        Author = book.Author,
            //        PublicationYear = book.PublicationYear
            //    };

            //    bookList.Add(bookListDto);
            //}

            return bookListDto;
        }

        public async Task<BookDetailsDto> BookDetailListAsync(int id)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(id);

            var bookDetailDto = _mapper.Map<BookDetailsDto>(book);

            return bookDetailDto;
            //return new BookDetailsDto
            //{
            //    Id = book.Id,
            //    Title = book.Title,
            //    Author = book.Author,
            //    PublicationYear = book.PublicationYear,
            //    ISBN = book.ISBN,
            //    Genre = book.Genre,
            //    Publisher = book.Publisher,
            //    PageCount = book.PageCount,
            //    Language = book.Language,
            //    Summary = book.Summary,
            //    AvailableCopies = book.AvailableCopies
            //};
        }
    }
}
