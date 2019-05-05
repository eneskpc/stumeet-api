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
        private IAuthenticationService _authManager;

        public ChatHub(IMessageService messageManager, IAuthenticationService authManager)
        {
            _messageManager = messageManager;
            _authManager = authManager;
        }

        public async Task NewMessage(MessageForChatHub message)
        {
            string jwtToken = Context.GetHttpContext().Request.Query["access_token"][0];
            var errorDetail = await _authManager.CheckUser(jwtToken);
            if (errorDetail.StatusCode == 200)
            {
                User currentUser = errorDetail.Data;

                Message recordedMessage = await _messageManager.Add(new Message
                {
                    UserId = currentUser.Id,
                    MessageContent = message.MessageContent,
                    GroupId = message.GroupId,
                    IsDeleted = false,
                    CreationDate = DateTime.Now
                });
                if (recordedMessage != null)
                {
                    recordedMessage.User = currentUser;
                    await Clients.All.SendAsync("messageReceived", recordedMessage);
                }
            }
        }
    }
}
