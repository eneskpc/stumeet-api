using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class DataType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
