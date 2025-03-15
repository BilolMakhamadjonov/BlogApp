using Blog.Core.Entity;

namespace Blog.Application.Models.Reaction;

public class ReactionCreateModel
{
    public int PostId { get; set; }
    public StickerType Sticker { get; set; }
}
