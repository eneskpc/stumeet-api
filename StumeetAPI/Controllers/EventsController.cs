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
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private IEventService _eventManager;
        private IEventParticipantService _eventParticipantManager;
        private IEducationInformationService _educationInformationManager;
        private IWorkInformationService _workInformationManager;
        private IAuthenticationService _authManager;

        public EventsController(IEventService eventManager, IEducationInformationService educationInformationManager, IWorkInformationService workInformationManager, IAuthenticationService authManager)
        {
            _eventManager = eventManager;
            _educationInformationManager = educationInformationManager;
            _workInformationManager = workInformationManager;
            _authManager = authManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            var eventList = await _eventManager.GetAll(u => u.IsDeleted != true);
            if (eventList == null)
            {
                return BadRequest();
            }
            return Ok(eventList);
        }

        // GET: api/<controller>
        [HttpGet("eventParticipants")]
        public async Task<ActionResult> GetEventParticipants()
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var eventParticipantList = await _eventParticipantManager.GetAll(u => u.IsDeleted != true);
            if (eventParticipantList == null)
            {
                return BadRequest();
            }
            return Ok(eventParticipantList);
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
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
