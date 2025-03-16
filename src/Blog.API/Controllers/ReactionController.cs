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
        var reactions = await _reactionService.GetByPostIdAsync(postId);
        return Ok(reactions);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ReactionCreateModel model)
    {
        await _reactionService.AddAsync(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(ReactionUpdateModel model)
    {
        await _reactionService.UpdateAsync(model);
        return Ok();
    }
}