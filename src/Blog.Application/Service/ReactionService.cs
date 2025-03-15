using Blog.Application.Models.Reaction;
using Blog.Core.Entity;
using Blog.DataAccess.Repositories;

namespace Blog.Application.Service;

public class ReactionService : IReactionService
{
    private readonly IReactionRepo _reactionRepository;

    public ReactionService(IReactionRepo reactionRepository)
    {
        _reactionRepository = reactionRepository;
    }

    public async Task<List<ReactionResponseModel>> GetReactionsByPostIdAsync(int postId)
    {
        var reactions = await _reactionRepository.GetByPostIdAsync(postId);
        return reactions.Select(r => new ReactionResponseModel
        {
            Id = r.Id,
            Sticker = r.Sticker,
            CreatedAt = r.CreatedAt
        }).ToList();
    }

    public async Task AddReactionAsync(ReactionCreateModel model)
    {
        var reaction = new Reaction
        {
            PostId = model.PostId,
            Sticker = model.Sticker
        };
        await _reactionRepository.AddAsync(reaction);
    }
}
