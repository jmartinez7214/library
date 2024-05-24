using AutoMapper;
using Library.Application.Features.Books.Queries.GetBooksList;
using Library.Application.Mappings;
using Library.Application.UnitTests.Mocks;
using Library.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace Library.Application.UnitTests.Features.Books.Queries
{
    public class GetBooksListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<BookRepository> _bookRepository;

        public GetBooksListQueryHandlerXUnitTests()
        {
            _bookRepository = MockBookRepository.GetBookRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetBookListTest()
        {
            var handler = new GetBooksListQueryHandler(_bookRepository.Object, _mapper);
            var request = new GetBooksListQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<BooksVm>>();
            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
