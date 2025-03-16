using AutoMapper;
using Blog.Application.Models.Post;
using Blog.Core;
using Blog.DataAccess.Repositories;

namespace Blog.Application.Service;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostResponseModel>> GetAllAsync()
    {
        var posts = await _postRepository.GetAllAsync();
        return _mapper.Map<List<PostResponseModel>>(posts);
    }

    public async Task<PostResponseModel?> GetByIdAsync(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        return post != null ? _mapper.Map<PostResponseModel>(post) : null;
    }

    public async Task AddAsync(PostCreateModel model)
    {
        var post = _mapper.Map<Post>(model);
        post.CreatedAt = DateTime.UtcNow;
        await _postRepository.AddAsync(post);
    }

    public async Task UpdateAsync(PostUpdateModel model)
    {
        var existingPost = await _postRepository.GetByIdAsync(model.Id);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }

        _mapper.Map(model, existingPost);
        await _postRepository.UpdateAsync(existingPost);
    }

    public async Task DeleteAsync(int id)
    {
        await _postRepository.DeleteAsync(id);
    }
}
