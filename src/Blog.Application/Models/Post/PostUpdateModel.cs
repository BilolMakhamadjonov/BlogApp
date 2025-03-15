﻿namespace Blog.Application.Models.Post;

public class PostUpdateModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
