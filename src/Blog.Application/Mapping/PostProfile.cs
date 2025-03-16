using AutoMapper;
using Blog.Application.Models.Post;
using Blog.Core;

namespace Blog.Application.Mapping;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostResponseModel>();
        CreateMap<PostCreateModel, Post>();
        CreateMap<PostUpdateModel, Post>();
    }
}