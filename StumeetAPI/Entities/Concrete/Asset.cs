using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class Asset
    {
        public int Id { get; set; }
        public string SourceUrl { get; set; }
        public string PublicId { get; set; }
        public int DataTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
