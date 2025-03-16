using AutoMapper;
using Blog.Application.Models.Reaction;
using Blog.Core.Entity;
using Blog.DataAccess.Repositories;

namespace Blog.Application.Service;

public class ReactionService : IReactionService
{
    private readonly IReactionRepo _reactionRepo;
    private readonly IMapper _mapper;

    public ReactionService(IReactionRepo reactionRepo, IMapper mapper)
    {
        _reactionRepo = reactionRepo;
        _mapper = mapper;
    }

    public async Task<List<ReactionResponseModel>> GetByPostIdAsync(int postId)
    {
        var reactions = await _reactionRepo.GetByPostIdAsync(postId);
        return _mapper.Map<List<ReactionResponseModel>>(reactions);
    }

    public async Task AddAsync(ReactionCreateModel model)
    {
        var reaction = _mapper.Map<Reaction>(model);
        reaction.CreatedAt = DateTime.UtcNow;
        await _reactionRepo.AddAsync(reaction);
    }

    public async Task UpdateAsync(ReactionUpdateModel model)
    {
        var existingReaction = (await _reactionRepo.GetByPostIdAsync(model.Id)).FirstOrDefault();
        if (existingReaction == null)
        {
            throw new Exception("Reaction not found");
        }

        _mapper.Map(model, existingReaction);
        await _reactionRepo.UpdateAsync(existingReaction);
    }
}