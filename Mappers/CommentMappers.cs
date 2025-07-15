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
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            Createdon = commentModel.Createdon,
            StockId = commentModel.StockId,

        };

    }
    public static Comment ToCommentModel(this CreateCommentDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }
    public static void UpdateCommentModel(this Comment existingComment, UpdateCommentDto commentDto)
    {
        existingComment.Title = commentDto.Title;
        existingComment.Content = commentDto.Content;
    }
}
