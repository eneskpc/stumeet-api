using System;
using System.Collections.Generic;
using Stumeet.Core.Entities;

namespace Stumeet.Entities.Concrete
{
    public partial class DataTypeExtension : IEntity
    {
        public int Id { get; set; }
        public int DataTypeId { get; set; }
        public string TypeExtension { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
