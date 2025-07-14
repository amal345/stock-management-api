using System;
using MyWebApi.Dtos.Comment;
using MyWebApi.Models;

namespace MyWebApi.Mappers;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Title = commentModel.Title,
            Content = commentModel.Content,
            Createdon = commentModel.Createdon,
            StockId = commentModel.StockId,
            // Stock = commentModel.Stock?.ToStockDto()
        };
        
    }
}
