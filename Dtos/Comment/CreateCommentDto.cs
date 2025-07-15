using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApi.Dtos.Comment;

namespace MyWebApi.Dtos.Comment
{
    public class CreateCommentDto
    {
        
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    
    }
}
