using AutoMapper;
using Library.Application.Contracts.Persistence;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBooksList
{
    public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<BooksVm>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksListQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BooksVm>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            var bookList = await _bookRepository.GetAllAsync();

            return _mapper.Map<List<BooksVm>>(bookList);
        }
    }
}
