namespace Blog.Application.Models.Comment;

public class CommentCreateModel
{
    public int PostId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
