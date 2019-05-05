using StumeetAPI.Core.Entities;
using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class Authentication : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AuthCode { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }
    }
}
