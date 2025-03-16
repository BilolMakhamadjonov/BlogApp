using Blog.Application.Models.Comment;
using Blog.Core;

namespace Blog.Application.Service;

public interface ICommentService
{
    Task<List<CommentResponseModel>> GetByPostIdAsync(int postId);
    Task<CommentResponseModel?> GetByIdAsync(int id);
    Task AddAsync(CommentCreateModel comment);
    Task UpdateAsync(CommentUpdateModel comment);
    Task DeleteAsync(int id);
}
