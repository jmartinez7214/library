using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteBookCommandHandler> _logger;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookToDelete = await _bookRepository.GetByIdAsync(request.Id);

            if (bookToDelete == null)
            {
                _logger.LogError($"Book with the id {request.Id} was not found");
                throw new NotFoundException(nameof(Book), request.Id);
            }

            await _bookRepository.DeleteAsync(bookToDelete);

            _logger.LogInformation($"Book with the id {request.Id} was deleted successfully");

            return Unit.Value;
        }
    }
}
