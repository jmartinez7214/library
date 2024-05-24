using AutoMapper;
using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Queries.GetBook;
using Library.Application.Features.Books.Queries.GetBookDetail;
using Library.Application.Features.Books.Queries.GetBooksList;
using Library.Domain;

namespace Library.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookWithCount, BookVm>();
            CreateMap<Book, BookVm>();
            CreateMap<BookVm, Book>();
            CreateMap<Book, BooksVm>();
            CreateMap<BooksVm, Book>();
            CreateMap<BookDetail, BookDetailVm>();
            CreateMap<BookDetailVm, BookDetail>();
            CreateMap<CreateBookCommand, Book>();
        }
    }
}
