using System;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Dtos.Comment;
using MyWebApi.Interfaces;
using MyWebApi.Mappers;
using MyWebApi.Models;

namespace MyWebApi.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
       Comment? comment =await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
    }

    public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto updatedCommentDto)
    {
       Comment? existingComment = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
        if (existingComment == null)
        {
            return null;
        }
       existingComment.UpdateCommentModel(updatedCommentDto);
       await _context.SaveChangesAsync();
       return existingComment;
    }
}
