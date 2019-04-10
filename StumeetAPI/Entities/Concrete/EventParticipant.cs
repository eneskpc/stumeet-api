using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class EventParticipant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
