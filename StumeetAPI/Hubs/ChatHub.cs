﻿using System;
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
    [Authorize]
    public class ChatHub : Hub
    {
        private IMessageService _messageManager;
        private IAuthenticationService _authManager;
        private IUserService _userManager;
        private IMessageGroupService _messageGroupManager;

        public ChatHub(IMessageService messageManager, IAuthenticationService authManager, IUserService userManager, IMessageGroupService messageGroupManager)
        {
            _messageManager = messageManager;
            _authManager = authManager;
            _userManager = userManager;
            _messageGroupManager = messageGroupManager;
        }

        public override async Task OnConnectedAsync()
        {
            User loggedUser = await _userManager.GetByCondition(u => u.Email == Context.User.Identity.Name && u.IsDeleted != true);
            if (loggedUser != null)
            {
                TimeSpan x = loggedUser.LastLoginDate.Value.Subtract(loggedUser.LastLogoutDate.Value);
                if (x.TotalMilliseconds < 0)
                {
                    loggedUser.LastLoginDate = DateTime.Now;
                    if (await _userManager.Update(loggedUser) != null)
                        await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
                }
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            User loggedUser = await _userManager.GetByCondition(u => u.Email == Context.User.Identity.Name && u.IsDeleted != true);
            if (loggedUser != null)
            {
                loggedUser.LastLogoutDate = DateTime.Now;
                if (await _userManager.Update(loggedUser) != null)
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            }
            await base.OnDisconnectedAsync(exception);
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
                    await Clients.Groups((await _messageGroupManager.GetAllMembers(gm => gm.GroupId == message.GroupId && gm.IsDeleted != true))
                        .Select(gm => gm.Email).ToList()).SendAsync("messageReceived", recordedMessage);
                }
            }
        }
    }
}
