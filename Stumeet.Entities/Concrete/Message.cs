using System;
using System.Collections.Generic;
using Stumeet.Core.Entities;

namespace Stumeet.Entities.Concrete
{
    public partial class Message : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
