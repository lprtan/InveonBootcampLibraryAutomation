using BusinessLayer.Dtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IBookService :IGenericService<Book> 
    {
        Task<List<BookListDto>> BookListAsync();
        Task<BookDetailsDto> BookDetailListAsync(int id);
    }
}
