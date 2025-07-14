using System;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Interfaces;
using MyWebApi.Models;

namespace MyWebApi.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
    }
  
}
