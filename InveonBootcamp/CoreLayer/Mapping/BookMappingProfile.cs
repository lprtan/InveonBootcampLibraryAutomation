using AutoMapper;
using CoreLayer.Dtos;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookListDto>();
            CreateMap<Book, BookDetailsDto>();
        }
    }
}
