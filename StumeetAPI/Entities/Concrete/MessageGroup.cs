using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class MessageGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
