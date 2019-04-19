using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StumeetAPI.Business.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StumeetAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userManager;

        public UsersController(IUserService userManager)
        {
            _userManager = userManager;
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
            if(userList == null)
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
    }
}
