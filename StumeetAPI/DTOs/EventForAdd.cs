using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DTOs
{
    public class EventForAdd
    {
        public int EventType { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string OpenAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
