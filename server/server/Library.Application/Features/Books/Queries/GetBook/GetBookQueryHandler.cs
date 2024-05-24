using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Domain;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBook
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookVm>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookDetailRepository _bookDetailRepository;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IBookRepository bookRepository, IBookDetailRepository bookDetailRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookDetailRepository = bookDetailRepository;
            _mapper = mapper;
        }

        public async Task<BookVm> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request._Id);
            var bookDetails = await _bookDetailRepository.GetAsync(x => x.BookId == book.Id);

            BookWithCount bookWithCount = new()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                BookDetails = book.BookDetails,
                Count = bookDetails.Count
            };

            return _mapper.Map<BookVm>(bookWithCount);
        }
    }

    public class BookWithCount : Book {
        public int? Count { get; set; }
    }
}
