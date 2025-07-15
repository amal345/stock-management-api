using System;
using MyWebApi.Dtos.Stock;

namespace MyWebApi.Dtos.Comment;

public class CommentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Createdon { get; set; } = DateTime.UtcNow;
    public int? StockId { get; set; }
    // public StockDtos? Stock { get; set; } = new StockDtos();
}
