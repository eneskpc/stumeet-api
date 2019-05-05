using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StumeetAPI.Controllers
{
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private IMessageService _messageManager;
        private IAuthenticationService _authManager;
        private IMessageGroupService _messageGroupManager;

        public MessagesController(IMessageService messageManager, IAuthenticationService authManager, IMessageGroupService messageGroupManager)
        {
            _messageManager = messageManager;
            _authManager = authManager;
            _messageGroupManager = messageGroupManager;
        }

        // GET: api/messages
        [HttpGet("getbyid/{groupID}")]
        public async Task<ActionResult> GetMessages(int groupID)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }

            User currentUser = errorDetail.Data;
            User groupMember =
                await _messageGroupManager.GetMember(gm => gm.UserId == currentUser.Id && gm.GroupId == groupID);
            if (groupMember == null)
            {
                return Unauthorized();
            }

            var x = await _messageManager.GetAll(m => m.IsDeleted != true && m.GroupId == groupID);
            return Ok(new CustomResponse
            {
                ResponseText = "Success",
                StatusCode = 200,
                Data = x
            });
        }

        // GET api/messages/group/5
        [HttpGet("groups")]
        public async Task<ActionResult> GetAllGroup()
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }

            User currentUser = errorDetail.Data;

            return Ok(new CustomResponse
            {
                ResponseText = "Success",
                StatusCode = 200,
                Data = await _messageGroupManager.GetAllMembersReturnGroup(mgm => mgm.IsDeleted != true && mgm.UserId == currentUser.Id)
            });
        }

        // GET api/messages/group
        [HttpGet("group/{id}")]
        public async Task<ActionResult> GetGroup(int id)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }

            User currentUser = errorDetail.Data;
            return Ok(new CustomResponse
            {
                ResponseText = "Success",
                StatusCode = 200,
                Data = await _messageGroupManager.GetAllMembersReturnGroup(mgm => mgm.IsDeleted != true && mgm.UserId == currentUser.Id && mgm.GroupId == id)
            });
        }

    }
}