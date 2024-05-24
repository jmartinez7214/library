using AutoFixture;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Library.Application.UnitTests.Mocks
{
    public static class MockBookRepository
    {
        public static Mock<BookRepository> GetBookRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var books = fixture.CreateMany<Book>().ToList();

            books.Add(fixture.Build<Book>()
                .Create()
                );

            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: $"LibraryDbContext-{Guid.NewGuid()}")
                .Options;

            var libraryDbContextFake = new LibraryDbContext(options);
            libraryDbContextFake.Books!.AddRange(books);
            libraryDbContextFake.SaveChanges();

            var mockRepository = new Mock<BookRepository>(libraryDbContextFake);

            return mockRepository;
        }
    }
}
