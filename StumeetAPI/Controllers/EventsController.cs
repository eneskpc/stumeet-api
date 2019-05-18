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
    public class EventsController : Controller
    {
        private IEventService _eventManager;
        private IEventParticipantService _eventParticipantManager;
        private IEducationInformationService _educationInformationManager;
        private IWorkInformationService _workInformationManager;
        private IAuthenticationService _authManager;

        public EventsController(IEventService eventManager, IEventParticipantService eventParticipantManager, IEducationInformationService educationInformationManager, IWorkInformationService workInformationManager, IAuthenticationService authManager)
        {
            _eventManager = eventManager;
            _eventParticipantManager = eventParticipantManager;
            _educationInformationManager = educationInformationManager;
            _workInformationManager = workInformationManager;
            _authManager = authManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var eventsOfUser = await _eventParticipantManager.GetAll(u => u.UserId == currentUser.Id && u.IsDeleted != true);
            if (eventsOfUser == null)
            {
                return NotFound();
            }
            var eventList = await _eventManager.GetAll(u => u.IsDeleted != true && eventsOfUser.Select(a => a.EventId).Contains(u.Id));
            if (eventList == null)
            {
                return NotFound();
            }
            return Ok(eventList);
        }

        // GET: api/<controller>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEventById(int id)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var eventsOfUser = await _eventParticipantManager.GetAll(u => u.UserId == currentUser.Id && u.IsDeleted != true);
            if (eventsOfUser == null || id == 0)
            {
                return NotFound();
            }
            var eventList = await _eventManager.GetByID(id);
            if (eventList == null)
            {
                return NotFound();
            }
            return Ok(eventList);
        }

        // GET: api/<controller>
        [HttpGet("{id}/participants")]
        public async Task<ActionResult> GetEventParticipants(int id)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var eventParticipantList = await _eventParticipantManager.GetAll(u => u.IsDeleted != true && u.EventId == id);
            if (eventParticipantList == null)
            {
                return BadRequest();
            }
            return Ok(eventParticipantList);
        }

        // POST: api/<controller>
        [HttpPost]
        public async Task<ActionResult> AddEvent([FromBody] EventForAdd eventForAdd)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var recordedEvent = await _eventManager.Add(new Event
            {
                EventType = eventForAdd.EventType,
                EventName = eventForAdd.EventName,
                EventDate = eventForAdd.EventDate,
                OpenAddress = eventForAdd.OpenAddress,
                Latitude = eventForAdd.Latitude,
                Longitude = eventForAdd.Longitude,
                CreationDate = DateTime.Now,
                IsDeleted = false
            });
            if (recordedEvent == null)
            {
                return NotFound();
            }
            return Ok(recordedEvent);
        }

        // POST: api/<controller>
        [HttpPut]
        public async Task<ActionResult> UpdateEvent([FromBody] Event eventForUpdate)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            eventForUpdate.UpdatedDate = DateTime.Now;
            var recordedEvent = await _eventManager.Add(eventForUpdate);
            if (recordedEvent == null)
            {
                return NotFound();
            }
            return Ok(recordedEvent);
        }

        // POST: api/<controller>
        [HttpPost("{id}/participants")]
        public async Task<ActionResult> AddEventParticipant([FromBody] EventParticipantForAdd eventParticipantForAdd)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var recordedEventParticipant = await _eventParticipantManager.Add(new EventParticipant
            {
                EventId = eventParticipantForAdd.EventId,
                UserId = eventParticipantForAdd.UserId,
                InvitationReply = "M",
                CreationDate = DateTime.Now,
                IsDeleted = false
            });
            if (recordedEventParticipant == null)
            {
                return BadRequest();
            }
            return Ok(recordedEventParticipant);
        }

        // POST: api/<controller>
        [HttpPut("{id}/participants")]
        public async Task<ActionResult> UpdateEventParticipant([FromBody] EventParticipant eventParticipantForUpdate)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            if (currentUser.Id != eventParticipantForUpdate.UserId)
            {
                return Unauthorized();
            }
            eventParticipantForUpdate.UpdatedDate = DateTime.Now;
            var recordedEvent = await _eventParticipantManager.Update(eventParticipantForUpdate);
            if (recordedEvent == null)
            {
                return NotFound();
            }
            return Ok(recordedEvent);
        }
    }
}
