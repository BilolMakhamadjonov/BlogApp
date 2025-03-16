using AutoMapper;
using Blog.Application.Models.Comment;
using Blog.Core;

namespace Blog.Application.Mapping;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentResponseModel>();
        CreateMap<CommentCreateModel, Comment>();
        CreateMap<CommentUpdateModel, Comment>();
    }
}