namespace Blog.Application.Models.Comment;

public class CommentUpdateModel
{
    public int Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
