using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentConfirm { get; set; }
        public int CommentLike { get; set; }

    }
}
