using Blog.Application.Models.Comment;
using Blog.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    public CommentController(ICommentService commentService) => _commentService = commentService;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _commentService.GetAllCommentsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        return comment == null ? NotFound() : Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentCreateModel model)
    {
        await _commentService.AddCommentAsync(model);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CommentUpdateModel model)
    {
        if (id != model.Id) return BadRequest();
        await _commentService.UpdateCommentAsync(model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}
