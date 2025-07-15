using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Dtos.Comment;
using MyWebApi.Interfaces;
using MyWebApi.Mappers;

namespace MyWebApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentRepository.GetAllAsync();
            if (comments == null || !comments.Any())
            {
                return NotFound("No comments found.");
            }
            return Ok(comments.Select(comment => comment.ToCommentDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound($"Comment with ID {id} not found.");
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            if (!await _stockRepository.isStockExists(stockId))
            {
                return NotFound($"Stock with ID {stockId} not found.");
            }
            var comment = commentDto.ToCommentModel(stockId);
            await _commentRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateCommentDto updatedCommentDto)
        {
            var updatedComment = await _commentRepository.UpdateAsync(id, updatedCommentDto);
            if (updatedComment == null)
            {
                return NotFound($"Comment with ID {id} not found.");
            }
            return Ok(updatedComment.ToCommentDto());
        } 
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return NoContent();
        }
    }
}

