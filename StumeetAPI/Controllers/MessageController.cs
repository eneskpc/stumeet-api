using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StumeetAPI.Business.Abstract;
using StumeetAPI.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StumeetAPI.Controllers
{
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private IMessageService _messageManager;
        private IAuthenticationService _authManager;

        public MessageController(IMessageService messageManager, IAuthenticationService authManager)
        {
            _messageManager = messageManager;
            _authManager = authManager;
        }

        // GET: api/<controller>
        [HttpGet("list/{groupID}")]
        public async Task<ActionResult> GetMessages(int groupID)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            var messageList = await _messageManager.GetAll(m => m.IsDeleted != true && m.GroupId == groupID);
            if (messageList == null)
            {
                return BadRequest();
            }
            return Ok(messageList);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string GetMessage(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
