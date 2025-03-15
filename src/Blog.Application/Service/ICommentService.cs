using Blog.Application.Models.Comment;

namespace Blog.Application.Service;

public interface ICommentService
{
    Task<List<CommentResponseModel>> GetAllCommentsAsync();
    Task<CommentResponseModel?> GetCommentByIdAsync(int id);
    Task AddCommentAsync(CommentCreateModel model);
    Task UpdateCommentAsync(CommentUpdateModel model);
    Task DeleteCommentAsync(int id);
}
