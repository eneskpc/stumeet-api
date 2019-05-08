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
        [HttpPost]
        public async Task<ActionResult> UpdateEvent([FromBody] Event eventForAdd)
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            eventForAdd.UpdatedDate = DateTime.Now;
            var recordedEvent = await _eventManager.Add(eventForAdd);
            if (recordedEvent == null)
            {
                return NotFound();
            }
            return Ok(recordedEvent);
        }
    }
}
