using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Domain;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDetailVm>
    {
        private readonly IBookDetailRepository _bookDetailRepository;
        private readonly IMapper _mapper;

        public GetBookDetailQueryHandler(IBookDetailRepository bookDetailRepository, IMapper mapper)
        {
            _bookDetailRepository = bookDetailRepository;
            _mapper = mapper;
        }

        public async Task<BookDetailVm> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            var bookDetail = await _bookDetailRepository.GetByIdAndPageAsync(request._Id, request._Page);
            //var bookDetail = await _asyncRepository.GetAsync(u => u.BookId == request._Id);

            return _mapper.Map<BookDetailVm>(bookDetail);
        }
    }
}
