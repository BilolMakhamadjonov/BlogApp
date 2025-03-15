using Blog.Application.Models.Post;

namespace Blog.Application.Service;

public interface IPostService
{
    Task<List<PostResponseModel>> GetAllPostsAsync();
    Task<PostResponseModel?> GetPostByIdAsync(int id);
    Task AddPostAsync(PostCreateModel model);
    Task UpdatePostAsync(PostUpdateModel model);
    Task DeletePostAsync(int id);
}
