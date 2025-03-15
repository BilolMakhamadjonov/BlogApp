using Blog.Application.Models.Post;
using Blog.Core;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Service;

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    public PostService(AppDbContext context) => _context = context;

    public async Task<List<PostResponseModel>> GetAllPostsAsync()
    {
        return await _context.Posts
            .Select(p => new PostResponseModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedAt
            }).ToListAsync();
    }

    public async Task<PostResponseModel?> GetPostByIdAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        return post == null ? null : new PostResponseModel
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        };
    }

    public async Task AddPostAsync(PostCreateModel model)
    {
        var post = new Post
        {
            Title = model.Title,
            Content = model.Content
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePostAsync(PostUpdateModel model)
    {
        var post = await _context.Posts.FindAsync(model.Id);
        if (post == null) return;

        post.Title = model.Title;
        post.Content = model.Content;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePostAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
