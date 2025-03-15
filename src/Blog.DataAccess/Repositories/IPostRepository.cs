using Blog.Core;
using Blog.Core.Entity;

namespace Blog.DataAccess.Repositories;

public interface IPostRepository
{
    Task<List<Post>> GetAllAsync();
    Task<Post?> GetByIdAsync(int id);
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
}
