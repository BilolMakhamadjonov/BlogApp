using Blog.Application.Models.Reaction;

namespace Blog.Application.Service;

public interface IReactionService
{
    Task<List<ReactionResponseModel>> GetReactionsByPostIdAsync(int postId);
    Task AddReactionAsync(ReactionCreateModel model);
}
