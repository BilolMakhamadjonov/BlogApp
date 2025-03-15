namespace Blog.Core.Entity;

public class Reaction
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public StickerType Sticker { get; set; }  // Enum sifatida saqlanadi
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Post Post { get; set; } = null!;
}
