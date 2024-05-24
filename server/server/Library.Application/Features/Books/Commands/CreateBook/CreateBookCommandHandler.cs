using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<CreateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = _mapper.Map<Book>(request);
            var newBook = await _bookRepository.AddAsync(bookEntity);

            _logger.LogInformation($"Book {newBook.Id} was created successfully.");

            return newBook.Id;
        }
    }
}
