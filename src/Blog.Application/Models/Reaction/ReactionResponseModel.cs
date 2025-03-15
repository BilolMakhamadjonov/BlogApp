using Blog.Core.Entity;

namespace Blog.Application.Models.Reaction;

public class ReactionResponseModel
{
    public int Id { get; set; }
    public StickerType Sticker { get; set; }
    public DateTime CreatedAt { get; set; }

}
