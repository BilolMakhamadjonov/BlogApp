using AutoMapper;
using Blog.Application.Models.Comment;
using Blog.Core;
using Blog.DataAccess.Repositories;

namespace Blog.Application.Service;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentResponseModel>> GetByPostIdAsync(int postId)
    {
        var comments = await _commentRepository.GetByPostIdAsync(postId);
        return _mapper.Map<List<CommentResponseModel>>(comments);
    }

    public async Task<CommentResponseModel?> GetByIdAsync(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        return comment != null ? _mapper.Map<CommentResponseModel>(comment) : null;
    }

    public async Task AddAsync(CommentCreateModel model)
    {
        var comment = _mapper.Map<Comment>(model);
        comment.CreatedAt = DateTime.UtcNow;
        await _commentRepository.AddAsync(comment);
    }

    public async Task UpdateAsync(CommentUpdateModel model)
    {
        var existingComment = await _commentRepository.GetByIdAsync(model.Id);
        if (existingComment == null)
        {
            throw new Exception("Comment not found");
        }

        _mapper.Map(model, existingComment);
        await _commentRepository.UpdateAsync(existingComment);
    }

    public async Task DeleteAsync(int id)
    {
        await _commentRepository.DeleteAsync(id);
    }
}