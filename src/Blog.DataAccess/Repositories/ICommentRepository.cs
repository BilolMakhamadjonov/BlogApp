using Blog.Core;

namespace Blog.DataAccess.Repositories;

public interface ICommentRepository
{
    Task<List<Comment>> GetByPostIdAsync(int postId);
    Task<Comment?> GetByIdAsync(int id);
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(int id);
}
