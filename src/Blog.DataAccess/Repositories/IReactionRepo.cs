using Blog.Core.Entity;

namespace Blog.DataAccess.Repositories;

public interface IReactionRepo
{
    Task<List<Reaction>> GetByPostIdAsync(int postId);
    Task AddAsync(Reaction reaction);
    Task UpdateAsync(Reaction reaction);
}
