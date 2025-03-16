using Blog.Core.Entity;

namespace Blog.Application.Models.Reaction;

public class ReactionUpdateModel
{
    public int Id { get; set; }
    public StickerType Sticker { get; set; }
}
