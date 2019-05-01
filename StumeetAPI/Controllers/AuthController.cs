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
    public class AuthController : Controller
    {
        IUserService _userManager;

        public AuthController(IUserService userManager)
        {
            _userManager = userManager;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/login
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
            return Ok(new UserToken
            {
                Token = _userManager.CreateToken(user)
            });
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
            return Ok();
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
