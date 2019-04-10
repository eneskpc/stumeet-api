using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class Message
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
