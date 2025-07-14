using System;
using MyWebApi.Models;

namespace MyWebApi.Interfaces;

public interface ICommentRepository
{
     Task<List<Comment>> GetAllAsync();
     Task<Comment> GetByIdAsync(int id);
     
}

