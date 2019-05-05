using StumeetAPI.Core.Entities;
using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class EducationInformation : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UniversityId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }
        public University University { get; set; }
    }
}
