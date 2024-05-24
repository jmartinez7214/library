using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Commands.DeleteBook;
using Library.Application.Features.Books.Commands.UpdateBook;
using Library.Application.Features.Books.Queries.GetBook;
using Library.Application.Features.Books.Queries.GetBookDetail;
using Library.Application.Features.Books.Queries.GetBooksList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetBooks")]
        [ProducesResponseType(typeof(IEnumerable<BooksVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BooksVm>>> GetBooks()
        {
            var query = new GetBooksListQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        [ProducesResponseType(typeof(BookVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BookVm>> GetBook(int id)
        {
            var query = new GetBookQuery(id);
            var bookDetail = await _mediator.Send(query);
            return Ok(bookDetail);
        }

        [HttpGet("detail/{id}", Name = "GetBookDetail")]
        [ProducesResponseType(typeof(BookDetailVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BookDetailVm>> GetBookDetail(int id, [FromQuery] QueryParameters parameters)
        {
            var query = new GetBookDetailQuery(id, parameters.Page);
            var bookDetail = await _mediator.Send(query);
            return Ok(bookDetail);
        }

        [HttpPost(Name = "CreateBook")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateBook([FromBody]CreateBookCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
    public class QueryParameters
    {
        public int Page { get; set; }
    }
}
