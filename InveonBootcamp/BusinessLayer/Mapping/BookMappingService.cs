using AutoMapper;
using BusinessLayer.Dtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class BookMappingService : IBookMappingService
    {
        private readonly IMapper _mapper;
        public BookMappingService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public BookDetailsDto MapToBookDetailsDto(Book book)
        {
            return _mapper.Map<BookDetailsDto>(book);
        }

        public List<BookListDto> MapToBookListDto(IEnumerable<Book> books)
        {
            return _mapper.Map<List<BookListDto>>(books);
        }
    }
}
