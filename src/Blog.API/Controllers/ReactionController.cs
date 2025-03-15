using Blog.Application.Models.Reaction;
using Blog.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReactionController : ControllerBase
{
    private readonly IReactionService _reactionService;

    public ReactionController(IReactionService reactionService)
    {
        _reactionService = reactionService;
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetByPostId(int postId)
    {
        return Ok(await _reactionService.GetReactionsByPostIdAsync(postId));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReactionCreateModel model)
    {
        await _reactionService.AddReactionAsync(model);
        return Ok();
    }
}