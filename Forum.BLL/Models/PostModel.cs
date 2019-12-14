using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.BLL.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public byte[] Media { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string Poster { get; set; }
        public string SubForum { get; set; }
        public string Category { get; set; }
    }
}
