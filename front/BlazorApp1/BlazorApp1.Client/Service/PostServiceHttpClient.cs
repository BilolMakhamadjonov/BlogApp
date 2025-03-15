using Blog.Application.Models.Post;
using Blog.Application.Service;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Service
{
    public class PostServiceHttpClient : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostResponseModel>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PostResponseModel>>("api/post") ?? new List<PostResponseModel>();
        }

        public async Task<PostResponseModel?> GetPostByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PostResponseModel>($"api/post/{id}");
        }

        public async Task AddPostAsync(PostCreateModel model)
        {
            await _httpClient.PostAsJsonAsync("api/post", model);
        }

        public async Task UpdatePostAsync(PostUpdateModel model)
        {
            await _httpClient.PutAsJsonAsync($"api/post/{model.Id}", model);
        }

        public async Task DeletePostAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/post/{id}");
        }
    }
}
