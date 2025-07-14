using System;

namespace MyWebApi.Models;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Createdon { get; set; } = DateTime.UtcNow;
    public int? StockId { get; set; }
    //Navigation property
    public Stock? Stock { get; set; }

}

