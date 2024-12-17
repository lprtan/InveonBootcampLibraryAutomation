using CoreLayer.Dtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mapping
{
    public interface IBookMappingService
    {
        List<BookListDto> MapToBookListDto(IEnumerable<Book> books);
        BookDetailsDto MapToBookDetailsDto(Book book);
    }
}
