using BookReviewManager.Application.Commands.BookCommands.AddReview;
using BookReviewManager.Application.Commands.BookCommands.CreateBook;
using BookReviewManager.Application.Commands.BookCommands.UpdateBookCover;
using BookReviewManager.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    //[Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetBooksQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // GET api/books/123
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST api/books
        [HttpPost]
        //[Authorize(Roles = "Admin" )]
        public async Task<IActionResult> Post(CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Data },
                command);
        }

        // PUT api/books/123/cover
        [HttpPut("{id}/cover")]
        [Consumes("multipart/form-data")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBookCover(int id,IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido.");

            byte[] imageBytes;

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }

            var result = await _mediator.Send(new UpdateBookCoverCommand(id, imageBytes));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
        // POST api/books/123/reviews
        [HttpPost("{id}/reviews")]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> AddReview(int id, AddReviewCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
