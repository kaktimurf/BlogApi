using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string PostName { get; set; }
        public string PostTitle { get; set; }
        public string PostExplanation { get; set; }
        public string PostContent { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostDate { get; set; }
        public int ReadingCount { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }

    }
}
