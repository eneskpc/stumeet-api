﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StumeetAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        IUserService _userManager;

        public AuthController(IUserService userManager)
        {
            _userManager = userManager;
        }

        // POST api/<controller>
        [AllowAnonymous]
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
        [AllowAnonymous]
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
    }
}
