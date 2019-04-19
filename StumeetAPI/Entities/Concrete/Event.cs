using StumeetAPI.Core.Entities;
using System;
using System.Collections.Generic;

namespace StumeetAPI.Entities.Concrete
{
    public partial class Event : IEntity
    {
        public int Id { get; set; }
        public int EventType { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string OpenAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
