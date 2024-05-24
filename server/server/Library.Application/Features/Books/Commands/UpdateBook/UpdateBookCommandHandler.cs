using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = await _bookRepository.GetByIdAsync(request.Id);

            if (bookToUpdate == null)
            {
                _logger.LogError($"Book with the id {request.Id} was not found");
                throw new NotFoundException(nameof(Book), request.Id);
            }

            _mapper.Map(request, bookToUpdate, typeof(UpdateBookCommand), typeof(Book));

            await _bookRepository.UpdateAsync(bookToUpdate);

            _logger.LogInformation($"Book with the id {request.Id} was updated successfully");

            return Unit.Value;
        }
    }
}
