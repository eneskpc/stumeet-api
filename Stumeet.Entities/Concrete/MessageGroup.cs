using System;
using System.Collections.Generic;
using Stumeet.Core.Entities;

namespace Stumeet.Entities.Concrete
{
    public partial class MessageGroup : IEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
