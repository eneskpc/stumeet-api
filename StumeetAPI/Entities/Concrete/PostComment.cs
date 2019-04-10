using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
