using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;

namespace StumeetAPI.Hubs
{
    public class ChatHub : Hub
    {
        private IMessageService _messageManager;
        public ChatHub(IMessageService messageManager)
        {
            _messageManager = messageManager;
        }
        public async Task NewMessage(MessageForChatHub message)
        {
            Console.Write(Context.User?.FindFirst(ClaimTypes.Email)?.Value);
            Message recordedMessage = await _messageManager.Add(new Message
            {
                UserId = message.UserId,
                MessageContent = message.MessageContent,
                GroupId = message.GroupId,
                IsDeleted = false,
                CreationDate = DateTime.Now
            });
            if (recordedMessage != null)
                await Clients.All.SendAsync("messageReceived", recordedMessage);
        }
    }
}
