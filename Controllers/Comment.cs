using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Interfaces;
using MyWebApi.Mappers;

namespace MyWebApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class Comment : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public Comment(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
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
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound($"Comment with ID {id} not found.");
            }
            return Ok(comment.ToCommentDto());
        }
    }
}
