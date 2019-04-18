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
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        IUserService _userManager;

        protected AuthController(IUserService userManager)
        {
            _userManager = userManager;
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
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserForLogin _user)
        {
            User user = await _userManager.Login(_user);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(_userManager.CreateToken(user));
        }

        // POST api/<controller>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]UserForRegister _user)
        {
            User user = await _userManager.Register(_user);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(_userManager.CreateToken(user));
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
