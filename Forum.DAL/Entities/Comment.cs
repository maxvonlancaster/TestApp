using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public byte[] Media { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public User Poster { get; set; }
        public Post Post { get; set; }
    }
}
