using StumeetAPI.Core.Entities;
using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class DeletedMessage : IEntity
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public Message Message { get; set; }
        public User User { get; set; }
    }
}
