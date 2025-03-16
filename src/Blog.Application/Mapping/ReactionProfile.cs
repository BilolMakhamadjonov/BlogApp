using AutoMapper;
using Blog.Application.Models.Reaction;
using Blog.Core.Entity;

namespace Blog.Application.Mapping;

public class ReactionProfile : Profile
{
    public ReactionProfile()
    {
        CreateMap<Reaction, ReactionResponseModel>();
        CreateMap<ReactionCreateModel, Reaction>();
        CreateMap<ReactionUpdateModel, Reaction>();
    }
}