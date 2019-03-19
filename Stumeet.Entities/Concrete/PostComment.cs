﻿using System;
using System.Collections.Generic;
using Stumeet.Core.Entities;

namespace Stumeet.Entities.Concrete
{
    public partial class PostComment : IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
