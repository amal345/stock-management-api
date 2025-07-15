using System;
using MyWebApi.Dtos.Comment;
using MyWebApi.Models;

namespace MyWebApi.Interfaces;

public interface ICommentRepository
{
     Task<List<Comment>> GetAllAsync();
     Task<Comment?> GetByIdAsync(int id);
     Task<Comment> CreateAsync(Comment commentModel);
     Task<Comment?> UpdateAsync(int id, UpdateCommentDto updatedCommentDto);
     Task<Comment?> DeleteAsync(int id);
}

