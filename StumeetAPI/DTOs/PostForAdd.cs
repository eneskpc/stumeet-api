using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DTOs
{
    public class PostForAdd
    {
        public int UserId { get; set; }
        public string PostContent { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
