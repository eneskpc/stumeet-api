using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DTOs
{
    public class MessageForChatHub
    {
        public int GroupId { get; set; }
        public string MessageContent { get; set; }
    }
}
