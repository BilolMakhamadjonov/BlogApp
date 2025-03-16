using Blog.Application.Models.Post;
using Blog.Core;

namespace Blog.Application.Service;

public interface IPostService
{
    Task<List<PostResponseModel>> GetAllAsync();
    Task<PostResponseModel?> GetByIdAsync(int id);
    Task AddAsync(PostCreateModel post);
    Task UpdateAsync(PostUpdateModel post);
    Task DeleteAsync(int id);
}