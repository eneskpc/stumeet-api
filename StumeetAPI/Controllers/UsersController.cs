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
    public class UsersController : Controller
    {
        private IUserService _userManager;
        private IEducationInformationService _educationInformationManager;
        private IWorkInformationService _workInformationManager;
        private IAuthenticationService _authManager;

        public UsersController(IUserService userManager, IEducationInformationService educationInformationManager, IWorkInformationService workInformationManager, IAuthenticationService authManager)
        {
            _userManager = userManager;
            _educationInformationManager = educationInformationManager;
            _workInformationManager = workInformationManager;
            _authManager = authManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var userList = await _userManager.GetAll(u => u.IsDeleted != true);
            if (userList == null)
            {
                return BadRequest();
            }
            return Ok(userList);
        }

        // GET: api/<controller>
        [HttpGet("myfriends")]
        public async Task<ActionResult> GetMyFriends()
        {
            //Auth etmiş kullanıcı ile şart gelecek
            var userList = await _userManager.GetAll(u => u.IsDeleted != true);
            if (userList == null)
            {
                return BadRequest();
            }
            return Ok(userList);
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

        [HttpGet("education-info")]
        public async Task<ActionResult> getUserEducationInfo()
        {
            var errorDetail = await _authManager.CheckUser(Request.Headers["Authorization"]);
            if (errorDetail.StatusCode != 200)
            {
                return Unauthorized(errorDetail);
            }
            User currentUser = errorDetail.Data;
            var userEducationList = await _educationInformationManager.GetAll(u => u.IsDeleted != true && u.UserId == currentUser.Id);
            if (userEducationList == null)
            {
                return BadRequest();
            }
            return Ok(userEducationList);
        }

        [HttpGet("work-info")]
        public async Task<ActionResult> getUserWorkInfo(int userID)
        {
            var userWorkList = await _workInformationManager.GetAll(u => u.IsDeleted != true && u.UserId == userID);
            if (userWorkList == null)
            {
                return BadRequest();
            }
            return Ok(userWorkList);
        }
    }
}
