using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DTOs
{
    public class EventParticipantForAdd
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string InvitationReply { get; set; }
    }
}
