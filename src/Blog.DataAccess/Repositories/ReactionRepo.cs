using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.Repositories;

public class ReactionRepo : IReactionRepo
{
    private readonly AppDbContext _context;

    public ReactionRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reaction>> GetByPostIdAsync(int postId)
    {
        return await _context.Reactions
            .Where(r => r.PostId == postId)
            .ToListAsync();
    }

    public async Task AddAsync(Reaction reaction)
    {
        _context.Reactions.Add(reaction);
        await _context.SaveChangesAsync();
    }
}
