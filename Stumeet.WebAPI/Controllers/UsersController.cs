using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stumeet.Business.Abstract;
using Stumeet.Entities.Concrete;
using Stumeet.WebAPI.DTOs;

namespace Stumeet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userManager;

        public UsersController(IUserService userManager)
        {
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _userManager.GetAll();
            if (users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userManager.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserForRegister user)
        {
            User newUser = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                BirthDate = user.BirthDate,
                Email = user.Email,
                PasswordHash = CreateStringHash(user.Password),
                PasswordSalt = CreateStringHash(""),
                PhoneNumber = user.PhoneNumber,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };
            User anotherUser = await _userManager.Add(newUser);
            if (anotherUser == null)
            {
                return BadRequest();
            }

            return Ok(anotherUser);
        }

        private byte[] CreateStringHash(string password)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserForRegister user)
        {
            User user2 = await _userManager.GetByID(id);
            if (user2 == null)
            {
                return NotFound();
            }

            user2.Name = user.Name;
            user2.Surname = user.Surname;
            user2.BirthDate = user.BirthDate;
            user2.Email = user.Email;
            user2.PasswordHash = CreateStringHash(user.Password);
            user2.PasswordSalt = CreateStringHash("");
            user2.PhoneNumber = user.PhoneNumber;
            user2.UpdatedDate = DateTime.Now;
            user2.IsDeleted = false;

            User anotherUser = await _userManager.Update(user2);

            if (anotherUser == null)
                return BadRequest();

            return Ok(anotherUser);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            User user2 = await _userManager.GetByID(id);
            if (user2 == null)
            {
                return NotFound();
            }

            user2.UpdatedDate = DateTime.Now;
            user2.IsDeleted = false;

            User anotherUser = await _userManager.Update(user2);

            if (anotherUser == null)
                return BadRequest();

            return Ok(anotherUser);
        }
    }
}
