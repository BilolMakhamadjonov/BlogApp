using Blog.Application.Models.Comment;
using Blog.Core;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Service;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;
    public CommentService(AppDbContext context) => _context = context;

    public async Task<List<CommentResponseModel>> GetAllCommentsAsync()
    {
        return await _context.Comments
            .Select(c => new CommentResponseModel
            {
                Id = c.Id,
                PostId = c.PostId,
                Author = c.Author,
                Text = c.Text,
                CreatedAt = c.CreatedAt
            }).ToListAsync();
    }

    public async Task<CommentResponseModel?> GetCommentByIdAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        return comment == null ? null : new CommentResponseModel
        {
            Id = comment.Id,
            PostId = comment.PostId,
            Author = comment.Author,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt
        };
    }

    public async Task AddCommentAsync(CommentCreateModel model)
    {
        var comment = new Comment
        {
            PostId = model.PostId,
            Author = model.Author,
            Text = model.Text
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCommentAsync(CommentUpdateModel model)
    {
        var comment = await _context.Comments.FindAsync(model.Id);
        if (comment == null) return;

        comment.Author = model.Author;
        comment.Text = model.Text;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
