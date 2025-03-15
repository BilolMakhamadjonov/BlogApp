namespace Blog.Application.Models.Comment;

public class CommentResponseModel
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
