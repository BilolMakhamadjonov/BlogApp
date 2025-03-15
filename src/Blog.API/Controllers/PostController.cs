using Blog.Application.Models.Post;
using Blog.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAllPostsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateModel model)
        {
            await _postService.AddPostAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostUpdateModel model)
        {
            if (id != model.Id) return BadRequest();
            await _postService.UpdatePostAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }

}
