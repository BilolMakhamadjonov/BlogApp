using Blog.Application.Models.Reaction;

namespace Blog.Application.Service;

public interface IReactionService
{
    Task<List<ReactionResponseModel>> GetByPostIdAsync(int postId);
    Task AddAsync(ReactionCreateModel model);
    Task UpdateAsync(ReactionUpdateModel model);
}